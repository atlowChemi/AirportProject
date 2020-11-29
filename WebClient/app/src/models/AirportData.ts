import {
    ControlTower,
    Flight,
    Station,
    StationControlTowerRelation,
    StationRelation,
} from './';

export type AirportData = {
    stations: Station[];
    stationRelations: StationRelation[];
    firstStations: StationControlTowerRelation[];
    controlTower: ControlTower;
    flights: Flight[];

    takeoffFlights: Flight[];
    landingFlights: Flight[];

    movingFlights: Flight[];
};
