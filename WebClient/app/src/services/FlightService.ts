import { name } from './';
import { install, invokeChatHub, registerChatHubListener } from './HubService';

export const registerAndGetFlights = async () => {
    await install(`${process.env.VUE_APP_SERVER}/FlightHub`);
    invokeChatHub('RegisterToControlTowerAndGetData', name).then(console.log);
};
