import { AirportData, Flight, Guid } from '@/models';
import { reactive, readonly } from 'vue';
import { registerAndGetFlights, listenToFlightChanges } from './FlightService';

export const name = process.env.VUE_APP_AIRPORT;
const _data = reactive<AirportData>({
    flights: [],
    controlTower: { id: Guid.empty, name: '' },
    stations: [],
    firstStations: [],
    stationRelations: [],
});

export const data = readonly(_data);

export const setData = (data: AirportData) => {
    _data.controlTower = data.controlTower;
    _data.firstStations = data.firstStations;
    _data.flights = data.flights;
    _data.stationRelations = data.stationRelations;
    _data.stations = data.stations;
};

export const addFlight = (flight: Flight) => _data.flights.push(flight);

export const removeFlight = (flight: Flight) =>
    (_data.flights = _data.flights.filter(f => f.id !== flight.id));

registerAndGetFlights();
listenToFlightChanges();
