import { Flight } from '@/models/Flight';
import { name, data } from './';
import { install, invokeChatHub, registerChatHubListener } from './HubService';

export const registerAndGetFlights = async () => {
    await install(`${process.env.VUE_APP_SERVER}/FlightHub`);
    data.flights = await invokeChatHub<Flight[]>(
        'RegisterToControlTowerAndGetData',
        name,
    );
    registerChatHubListener('FutureFlightAdded', (flight: Flight) => {
        data.flights.push(flight);
    });
};
