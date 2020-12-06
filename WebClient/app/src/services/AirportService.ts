import { AirportData, Flight, FlightDirection, Guid, Station } from '@/models';
import { readonly, ref, watch } from 'vue';
import { flightService } from './FlightService';

export const name = process.env.VUE_APP_AIRPORT;
const _data = ref<AirportData>({
    controlTower: { id: Guid.empty, name: '' },
    flights: [],
    stations: [],
    firstStations: [],
    stationRelations: [],
    landingFlights: [],
    takeoffFlights: [],
    movingFlights: [],
});

watch(
    () => _data.value.flights,
    val => {
        const [landing, takeoff] = val
            .filter(f => f.isWaiting)
            .sort(
                (a, b) => Date.parse(a.plannedTime) - Date.parse(b.plannedTime),
            )
            .reduce<[Flight[], Flight[]]>(
                ([lnd, tkf], f) =>
                    f.direction === FlightDirection.Landing
                        ? [[...lnd, f], tkf]
                        : [lnd, [...tkf, f]],
                [[], []],
            );
        _data.value.landingFlights = landing;
        _data.value.takeoffFlights = takeoff;
    },
    { deep: true },
);

export const data = readonly(_data);

export const setData = (data: AirportData) => {
    _data.value = data;
    _data.value.movingFlights = [];
};

export const addFlight = (flight: Flight) => _data.value.flights.push(flight);
export const addMovingFlight = (flight: Flight) =>
    _data.value.movingFlights.push(flight);

export const removeFlight = (flight: Flight) =>
    (_data.value.flights = _data.value.flights.filter(f => f.id !== flight.id));
export const removeMovingFlight = (flight: Flight) =>
    (_data.value.movingFlights = _data.value.movingFlights.filter(
        f => f.id !== flight.id,
    ));

const moveFlightToStation = (flight: Flight, station: Station) => {
    let flightInd = _data.value.movingFlights.findIndex(f => f.id == flight.id);
    const stationInd = _data.value.stations.findIndex(s => s.id == station.id);
    if (flightInd < 0) {
        flightInd = addMovingFlight(flight) - 1;
    }
    if (flightInd >= 0) {
        _data.value.movingFlights[flightInd].isWaiting = false;
        _data.value.movingFlights[flightInd].stationId = station.id;
    }
    if (stationInd >= 0) {
        _data.value.stations[stationInd].currentFlight = flight;
    }
};
const removeFlightFromStation = (flight: Flight, station: Station) => {
    const flightInd = _data.value.movingFlights.findIndex(
        f => f.id == flight.id,
    );
    const stationInd = _data.value.stations.findIndex(s => s.id == station.id);
    if (flightInd >= 0) {
        _data.value.movingFlights[flightInd].stationId = undefined;
    }
    if (stationInd >= 0) {
        _data.value.stations[stationInd].currentFlight = undefined;
    }
};
const moveFlightToFirstStation = (flight: Flight, station: Station) => {
    removeFlight(flight);
    addMovingFlight(flight);
    moveFlightToStation(flight, station);
};

export const moveFlight = (
    flight: Flight,
    from: Station | null,
    to: Station | null,
) => {
    if ((!from && to) || (from && from === to)) {
        //Flight time arrived and it moved to first station, or it was pre-fetched and was now stationed on itself.
        moveFlightToFirstStation(flight, to);
    } else if (from && to) {
        //Flight moved between two stations.
        removeFlightFromStation(flight, from);
        moveFlightToStation(flight, to);
    } else if (from && !to) {
        //Flight moved from last station and lost in the dark.
        removeMovingFlight(flight);
        removeFlightFromStation(flight, from);
    }
};

flightService.registerAndGetFlights();
flightService.listenToFlightChanges();
