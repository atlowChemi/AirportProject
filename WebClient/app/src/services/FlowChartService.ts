import { constants } from '@/constants';
import {
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
const getClientDimensions = () => {
    const {
        CLIENT_HEIGHT_FALLBACK,
        CLIENT_WIDTH_FALLBACK,
    } = constants.flowCharts;
    const { clientWidth, clientHeight } = root.value ?? {
        clientWidth: CLIENT_WIDTH_FALLBACK,
        clientHeight: CLIENT_HEIGHT_FALLBACK,
    };
    return { clientWidth, clientHeight };
};
const getPortPosition: (
    type: 'top' | 'bottom',
    x: number,
    y: number,
) => [number, number] = (type, x, y) => {
    if (type === 'top') {
        return [x + 40, y];
    } else if (type === 'bottom') {
        return [x + 40, y + 107.2];
    } else {
        return [0, 0];
    }
};
const buildControlTowerRelations = () => {
    return data.value.firstStations.map<FlowChartLinkModel>(fs => {
        const toNode = findNodeWithID(fs.stationToId);
        const { clientWidth, clientHeight } = getClientDimensions();
        let x = (toNode?.x || 0) > clientWidth / 2 ? clientWidth : scene.x;
        let y = (toNode?.y || 0) > clientHeight / 2 ? clientHeight : scene.y;
        const [startX, startY] = [x, y];
        x = scene.x + (toNode?.x || 0);
        y = scene.y + (toNode?.y || 0);
        const [endX, endY] = getPortPosition('top', x, y);
        return {
            id: Guid.newGuid(),
            start: [startX, startY],
            end: [endX, endY],
            direction: fs.direction,
        };
    });
};
const buildStationRelations = () => {
    return data.value.stationRelations.map<FlowChartLinkModel>(sr => {
        const fromNode = findNodeWithID(sr.stationFromId);
        const toNode = findNodeWithID(sr.stationToId);

        let x = scene.x + (fromNode?.x || 0);
        let y = scene.y + (fromNode?.y || 0);
        const [startX, startY] = getPortPosition('bottom', x, y);
        x = scene.x + (toNode?.x || 0);
        y = scene.y + (toNode?.y || 0);
        const [endX, endY] = getPortPosition('top', x, y);

        return {
            id: Guid.newGuid(),
            start: [startX, startY],
            end: [endX, endY],
            direction: sr.direction,
        };
    });
};

const moveSelectedNode = (dx: number, dy: number) => {
    const index = nodes.findIndex(item => item.id === action.dragging);

    if (index >= 0) {
        nodes[index].x += dx;
        nodes[index].y += dy;
    }
};
const lines = computed(() => {
    const firstStations = buildControlTowerRelations();
    const stationRelations = buildStationRelations();
    return [...firstStations, ...stationRelations];
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

const calculateMaximalSizes = () => {
    const { clientHeight, clientWidth } = getClientDimensions();
    const maximalColCount = Math.ceil(clientWidth / 80);
    const maximalRowCount = Math.ceil(clientHeight / 120);
    const colWidth = clientWidth / (maximalColCount + 1);
    const rowHeight = clientHeight / (maximalRowCount + 1);

    return [maximalColCount, colWidth, rowHeight];
};

const buildStationNodes = () => {
    const [maxCols, colWidth, rowHeight] = calculateMaximalSizes();
    const lastLocation = {
        currentInRow: 0,
        x: colWidth,
        y: rowHeight,
    };
    return data.value.stations.map<FlowChartNodeModel>(s => {
        const item = {
            id: s.id,
            name: s.name,
            x: lastLocation.x,
            y: lastLocation.y,
        };
        lastLocation.x += colWidth * 2;
        if (++lastLocation.currentInRow >= maxCols / 2) {
            lastLocation.y += rowHeight * 2;
            lastLocation.x = colWidth;
            lastLocation.currentInRow = 0;
        }
        return item;
    });
};

const initializeChart = () => {
    nodes.length = 0;
    nodes.push(...buildStationNodes());
};

const getNodeLocation = (id: guid) => {
    const node = findNodeWithID(id);
    return [node?.x, node?.y];
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
    getNodeLocation,
};
