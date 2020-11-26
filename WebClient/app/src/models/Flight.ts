import { FlightDirection, guid, HasId } from './';

export interface Flight extends HasId {
    airplaneId: number;
    controlTowerId: number;
    direction: FlightDirection;
    from: string;
    to: string;
    history: never[];
    plannedTime: string;
    stationId?: guid;
    isWaiting: boolean;
}
