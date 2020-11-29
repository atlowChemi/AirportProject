import { FlightDirection } from './FlightDirection';
import { guid } from './guid_type';
import { HasId } from './HasId';

export interface FlowChartFlightLink extends HasId {
    from: guid;
    to: guid;
    direction: FlightDirection;
}
