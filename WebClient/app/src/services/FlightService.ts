import { AirportData, Flight, Station } from '@/models';
import { name, addFlight, setData } from './';
import { moveFlight } from './AirportService';
import { install, invokeChatHub, registerChatHubListener } from './HubService';

const HUB_URL = `${process.env.VUE_APP_SERVER}/FlightHub`;

export const registerAndGetFlights = async () => {
    await install(HUB_URL);

    const airportData = await invokeChatHub<AirportData>(
        'RegisterToControlTowerAndGetData',
        name,
    );
    setData(airportData);
    registerChatHubListener('FutureFlightAdded', (flight: Flight) => {
        addFlight(flight);
    });
};

export const listenToFlightChanges = async () => {
    await install(HUB_URL);

    registerChatHubListener(
        'FlightMoved',
        (flight: Flight, from: Station | null, to: Station | null) => {
            moveFlight(flight, from, to);
        },
    );
};
