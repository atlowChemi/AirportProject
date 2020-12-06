import { constants } from '@/constants';
import {
    AirportData,
    Flight,
    FlightHistory,
    guid,
    PaginatedData,
    Station,
} from '@/models';
import axios from 'axios';
import { name, addFlight, setData } from './';
import { moveFlight } from './AirportService';
import { hubService } from './HubService';

const { SERVER_URL, HUB_NAME, API_PREFIX } = constants.server;
const HUB_URL = `${SERVER_URL}/${HUB_NAME}`;
const API_URL = `${SERVER_URL}/${API_PREFIX}`;

const registerAndGetFlights = async () => {
    await hubService.install(HUB_URL);

    const hubRegistration = hubService.invokeFlightHub(
        'RegisterToControlTower',
        name,
    );

    const getAirportData = axios.get<AirportData>(
        `${API_URL}/controlTower/${name}`,
    );
    try {
        const [airportData] = await Promise.all([
            getAirportData,
            hubRegistration,
        ]);
        setData(airportData.data);
    } catch (error) {
        console.warn(error);
        console.error('Something went wrong with the fetch request.', error);
    }
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

    let paginatedStationHistory: PaginatedData<FlightHistory>;

    try {
        const history = await axios.get<PaginatedData<FlightHistory>>(
            `${API_URL}/history?${urlParams}`,
        );
        paginatedStationHistory = history.data;
        paginatedStationHistory.maxPage = Math.ceil(
            history.data.total / PAGINATION_LIMIT,
        );
    } catch (error) {
        console.warn(error);
        console.error(
            `Something went wrong with the fetch request. return with ${500} status code.`,
        );
        paginatedStationHistory = {
            total: 0,
            maxPage: 1,
            elements: [],
        };
    }
    return paginatedStationHistory;
};

export const flightService = {
    registerAndGetFlights,
    listenToFlightChanges,
    getStationFlightHistory,
};
