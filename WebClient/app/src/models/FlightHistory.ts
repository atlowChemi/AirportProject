import { HasId, Flight, Station } from './';
export interface FlightHistory extends HasId {
    flight: Flight;
    station: Station;
    enterStationTime: string;
    leaveStationTime: string;
}
