import { HasId, guid, Flight } from './';

export interface Station extends HasId {
    controlTowerId: guid;
    name: string;
    currentFlight?: Flight;
}
