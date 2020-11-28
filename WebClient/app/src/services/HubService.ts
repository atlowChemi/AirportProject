import { ConnectionState } from '@/models';
import {
    HubConnection,
    HubConnectionBuilder,
    LogLevel,
} from '@microsoft/signalr';
import { ref } from 'vue';

let connection: HubConnection;

//#region Connection state
const connectionState = ref<ConnectionState>('connecting');

const connectionChanged = (newState: ConnectionState) => {
    connectionState.value = newState;
    if (newState === 'connected') {
        setTimeout(() => {
            //Only if value is still connected - remove state.
            if (connectionState.value === 'connected') {
                connectionState.value = '';
            }
        }, 1500);
    }
};
//#endregion

// async function start() {
//     try {
//         await connection.start();
//     } catch (err) {
//         console.error('Failed to connect with hub', err);
//         return new Promise<void>((resolve, reject) =>
//             setTimeout(async () => {
//                 try {
//                     await start();
//                     resolve();
//                 } catch (error) {
//                     reject();
//                 }
//             }, 5000),
//         );
//     }
// }

// eslint-disable-next-line @typescript-eslint/no-explicit-any
type CallbackFn = (...args: any[]) => void;

// eslint-disable-next-line @typescript-eslint/no-explicit-any
const invokeFlightHub = async <T = any>(
    methodName: string,
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    ...args: any[]
) => connection.invoke<T>(methodName, ...args);

const registerFlightHubListener = (methodName: string, callback: CallbackFn) =>
    connection.on(methodName, callback);

const unregisterFlightHubListener = (
    methodName: string,
    callback?: CallbackFn,
) =>
    callback
        ? connection.off(methodName, callback)
        : connection.off(methodName);

const install = async (url: string) => {
    if (!connection) {
        connection = new HubConnectionBuilder()
            .withUrl(url)
            .configureLogging(LogLevel.Information)
            .withAutomaticReconnect()
            .build();
        connection.onclose(() => connectionChanged('disconnected'));
        connection.onreconnecting(() => connectionChanged('connecting'));
        connection.onreconnected(() => connectionChanged('connected'));
        const connectionPromise = connection.start();
        connectionPromise
            .then(() => connectionChanged('connected'))
            .catch(() => connectionChanged('disconnected'));
        return connectionPromise;
    }
    return;
};

export const hubService = {
    connectionState,
    invokeFlightHub,
    registerFlightHubListener,
    unregisterFlightHubListener,
    install,
};
