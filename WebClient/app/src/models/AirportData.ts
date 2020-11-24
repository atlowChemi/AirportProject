import {
    Flight,
    Station,
    StationRelation,
    StationControlTowerRelation,
    ControlTower,
} from './';

export type AirportData = {
    flights: Flight[];
    stations: Station[];
    stationRelations: StationRelation[];
    firstStations: StationControlTowerRelation[];
    controlTower: ControlTower;
};
