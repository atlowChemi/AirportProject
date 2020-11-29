import { FlightDirection } from './FlightDirection';
import { HasId } from './HasId';

export interface FlowChartLinkModel extends HasId {
    start: [number, number];
    end: [number, number];
    direction: FlightDirection;
}
