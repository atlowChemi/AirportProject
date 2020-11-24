import { FlightDirection, guid } from './';

export type StationControlTowerRelation = {
    direction: FlightDirection;
    stationToId: guid;
    controlTowerId: guid;
};
