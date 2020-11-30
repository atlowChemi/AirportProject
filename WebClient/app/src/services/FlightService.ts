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

const { SERVER_URL, HUB_NAME, API_PREFIX } = constants.server;
const HUB_URL = `${SERVER_URL}/${HUB_NAME}`;
const API_URL = `${SERVER_URL}/${API_PREFIX}`;

const registerAndGetFlights = async () => {
    await hubService.install(HUB_URL);

    const hubRegistration = hubService.invokeFlightHub<AirportData>(
        'RegisterToControlTower',
        name,
    );

    const getAirportData = fetch(`${API_URL}/${name}`);

    const [airportData] = await Promise.all([getAirportData, hubRegistration]);

    setData(await airportData.json());
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
    const { PAGINATION_LIMIT } = constants.global;
    const startFrom = `${(page - 1) * PAGINATION_LIMIT}`;

    const urlParams = new URLSearchParams({
        stationId,
        startFrom,
        paginationLimit: `${PAGINATION_LIMIT}`,
    });

    const history = await fetch(`${API_URL}/history?` + urlParams);

    const paginatedStationHistory: PaginatedData<FlightHistory> = await history.json();
    paginatedStationHistory.maxPage = Math.ceil(
        paginatedStationHistory.total / PAGINATION_LIMIT,
    );
    return paginatedStationHistory;
};

export const flightService = {
    registerAndGetFlights,
    listenToFlightChanges,
    getStationFlightHistory,
};
