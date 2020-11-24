import { FlightDirection } from './FlightDirection';
import { guid } from './Guid';

export type Flight = {
    airplaneId: number;
    direction: FlightDirection;
    from: string;
    to: string;
    history: never[];
    id: guid;
    plannedTime: string;
};
