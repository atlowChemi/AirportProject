import { HasId } from './HasId';

export interface FlowChartNodeModel extends HasId {
    x: number;
    y: number;
    name: string;
}
