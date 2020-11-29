import { FlowChartLinkModel } from '@/models';

const getOffsetRect: (
    element: HTMLElement,
) => { top: number; left: number } = element => {
    const box = element.getBoundingClientRect();

    const scrollTop = window.pageYOffset;
    const scrollLeft = window.pageXOffset;

    const top = box.top + scrollTop;
    const left = box.left + scrollLeft;

    return { top: Math.round(top), left: Math.round(left) };
};

const getMousePosition: (
    element: HTMLElement,
    event: MouseEvent,
) => [number, number] = (element, event) => {
    const mouseX =
        event.pageX || event.clientX + document.documentElement.scrollLeft;
    const mouseY =
        event.pageY || event.clientY + document.documentElement.scrollTop;

    const offset = getOffsetRect(element);
    const x = mouseX - offset.left;
    const y = mouseY - offset.top;

    return [x, y];
};

const calculateCenterPoint: (link: FlowChartLinkModel) => [number, number] = ({
    start: [startX, startY],
    end: [endX, endY],
}) => {
    // caculate arrow position: the center point between start and end
    const dx = (endX - startX) / 2;
    const dy = (endY - startY) / 2;
    return [startX + dx, startY + dy];
};

const calculateRotation = ({
    start: [startX, startY],
    end: [endX, endY],
}: FlowChartLinkModel) => {
    // caculate arrow rotation
    const angle = -Math.atan2(endX - startX, endY - startY);
    const degree = (angle * 180) / Math.PI;
    return degree < 0 ? degree + 360 : degree;
};

const createLinkLine = ({
    start: [startX, startY],
    end: [endX, endY],
}: FlowChartLinkModel) => {
    const y1 = startY + 50,
        y2 = endY - 50;
    return `M ${startX}, ${startY} C ${startX}, ${y1}, ${endX}, ${y2}, ${endX}, ${endY}`;
};

const linkArrowTransform = (link: FlowChartLinkModel) => {
    const [arrowX, arrowY] = calculateCenterPoint(link);
    const degree = calculateRotation(link);
    return `translate(${arrowX}px, ${arrowY}px) rotate(${degree}deg)`;
};

export const positionService = {
    getOffsetRect,
    getMousePosition,
    calculateCenterPoint,
    calculateRotation,
    createLinkLine,
    linkArrowTransform,
};
