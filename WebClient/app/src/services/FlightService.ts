import { constants } from '@/constants';
import {
    AirportData,
    Flight,
    FlightHistory,
    guid,
    PaginatedData,
    Station,
} from '@/models';
import { name, addFlight, setData } from './';
import { moveFlight } from './AirportService';
import { hubService } from './HubService';

const HUB_URL = `${process.env.VUE_APP_SERVER}/FlightHub`;

const registerAndGetFlights = async () => {
    await hubService.install(HUB_URL);

    const airportData = await hubService.invokeFlightHub<AirportData>(
        'RegisterToControlTowerAndGetData',
        name,
    );
    setData(airportData);
    hubService.registerFlightHubListener(
        'FutureFlightAdded',
        (flight: Flight) => {
            addFlight(flight);
        },
    );
};

const listenToFlightChanges = async () => {
    await hubService.install(HUB_URL);

    hubService.registerFlightHubListener(
        'FlightMoved',
        (flight: Flight, from: Station | null, to: Station | null) => {
            moveFlight(flight, from, to);
        },
    );
};

const getStationFlightHistory = async (stationId: guid, page = 1) => {
    await hubService.install(HUB_URL);
    const start = (page - 1) * constants.PAGINATION_LIMIT;
    const paginatedStationHistory = await hubService.invokeFlightHub<
        PaginatedData<FlightHistory>
    >('GetStationFlightHistory', stationId, start, constants.PAGINATION_LIMIT);
    paginatedStationHistory.maxPage = Math.ceil(
        paginatedStationHistory.total / constants.PAGINATION_LIMIT,
    );
    return paginatedStationHistory;
};

export const flightService = {
    registerAndGetFlights,
    listenToFlightChanges,
    getStationFlightHistory,
};
