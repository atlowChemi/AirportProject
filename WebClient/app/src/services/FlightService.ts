import { AirportData, Flight } from '@/models';
import { name, data } from './';
import { install, invokeChatHub, registerChatHubListener } from './HubService';

export const registerAndGetFlights = async () => {
    await install(`${process.env.VUE_APP_SERVER}/FlightHub`);

    const airportData = await invokeChatHub<AirportData>(
        'RegisterToControlTowerAndGetData',
        name,
    );
    data.flights = airportData.flights;
    registerChatHubListener('FutureFlightAdded', (flight: Flight) => {
        data.flights.push(flight);
    });
};
