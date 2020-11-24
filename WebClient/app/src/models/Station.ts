import { guid } from './';

export type Station = {
    id: guid;
    controlTowerId: guid;
    name: string;
};
