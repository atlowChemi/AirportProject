import { FlightDirection, guid } from './';

export type StationRelation = {
    direction: FlightDirection;
    stationFromId: guid;
    stationToId: guid;
};
