import { FlightDirection, guid } from './';

export type Flight = {
    airplaneId: number;
    controlTowerId: number;
    direction: FlightDirection;
    from: string;
    to: string;
    history: never[];
    id: guid;
    plannedTime: string;
};
