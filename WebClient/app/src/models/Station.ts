import { guid } from './';
import { Flight } from './Flight';

export interface Station {
    id: guid;
    controlTowerId: guid;
    name: string;
    currentFlight?: Flight;
}
