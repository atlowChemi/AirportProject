import { constants } from '@/constants';
import {
    FlowChartFlightLink,
    FlowChartLinkModel,
    FlowChartNodeModel,
    FlowChartNodeOptions,
    Guid,
    guid,
} from '@/models';
import { computed, reactive, ref } from 'vue';
import { data } from './AirportService';
import { positionService } from './PositionService';

const { CENTER_X, CENTER_Y } = constants.flowCharts;
const scene = reactive({ x: CENTER_X, y: CENTER_Y });
const nodes = reactive<FlowChartNodeModel[]>([]);
const links = reactive<FlowChartFlightLink[]>([]);
const root = ref<HTMLDivElement | null>(null);
const action = reactive<{
    scrolling: boolean;
    dragging: guid | null;
    selected: guid;
}>({
    scrolling: false,
    dragging: '',
    selected: '',
});
const mouse = reactive({
    x: 0,
    y: 0,
    lastX: 0,
    lastY: 0,
});
const nodeOptions = computed<FlowChartNodeOptions>(() => ({
    centerY: scene.y,
    centerX: scene.x,
    selected: action.selected,
}));

const findNodeWithID = (id: guid) => nodes.find(i => id === i.id);
const getPortPosition: (
    type: 'top' | 'bottom',
    x: number,
    y: number,
) => [number, number] = (type, x, y) => {
    if (type === 'top') {
        return [x + 40, y];
    } else if (type === 'bottom') {
        return [x + 40, y + 80];
    } else {
        return [0, 0];
    }
};
const moveSelectedNode = (dx: number, dy: number) => {
    const index = nodes.findIndex(item => item.id === action.dragging);

    if (index >= 0) {
        nodes[index].x += dx;
        nodes[index].y += dy;
    }
};
const lines = computed<FlowChartLinkModel[]>(() => {
    return links.map(link => {
        const fromNode = findNodeWithID(link.from);
        const toNode = findNodeWithID(link.to);

        let x = scene.x + (fromNode?.x || 0);
        let y = scene.y + (fromNode?.y || 0);
        const [cx, cy] = getPortPosition('bottom', x, y);
        x = scene.x + (toNode?.x || 0);
        y = scene.y + (toNode?.y || 0);
        const [ex, ey] = getPortPosition('top', x, y);
        return {
            start: [cx, cy],
            end: [ex, ey],
            id: link.id,
            direction: link.direction,
        };
    });
});
const nodeSelected = (id: guid, e: MouseEvent) => {
    action.dragging = id;
    action.selected = id;
    mouse.lastX = (e.pageX || e.clientX) + document.documentElement.scrollLeft;
    mouse.lastY = (e.pageY || e.clientY) + document.documentElement.scrollTop;
};
const handleMove = (e: MouseEvent) => {
    if (action.dragging !== Guid.empty) {
        mouse.x = e.pageX || e.clientX + document.documentElement.scrollLeft;
        mouse.y = e.pageY || e.clientY + document.documentElement.scrollTop;
        const diffX = mouse.x - mouse.lastX;
        const diffY = mouse.y - mouse.lastY;

        mouse.lastX = mouse.x;
        mouse.lastY = mouse.y;
        moveSelectedNode(diffX, diffY);
    }
    if (action.scrolling && root.value) {
        [mouse.x, mouse.y] = positionService.getMousePosition(root.value, e);
        const diffX = mouse.x - mouse.lastX;
        const diffY = mouse.y - mouse.lastY;

        mouse.lastX = mouse.x;
        mouse.lastY = mouse.y;

        scene.x += diffX;
        scene.y += diffY;
    }
};
const handleUp = () => {
    action.dragging = Guid.empty;
    action.scrolling = false;
};
const handleDown = (e: MouseEvent) => {
    const target = (e.target || e.srcElement) as HTMLElement;
    if (
        (target === root.value || target.matches('svg, svg *')) &&
        e.which === 1 &&
        root.value
    ) {
        action.scrolling = true;
        [mouse.lastX, mouse.lastY] = positionService.getMousePosition(
            root.value,
            e,
        );
        action.selected = Guid.empty; // deselectAll
    }
};

const initializeChart = () => {
    const tmp = data.value.stations.map<FlowChartNodeModel>(s => ({
        id: s.id,
        name: s.name,
        x: 0,
        y: 0,
    }));
    nodes.push(...tmp);
};

export const flowChartService = {
    root,
    lines,
    nodes,
    nodeOptions,
    handleMove,
    handleUp,
    handleDown,
    nodeSelected,
    initializeChart,
};
