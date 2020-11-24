import {
    HubConnection,
    HubConnectionBuilder,
    LogLevel,
} from '@microsoft/signalr';
let connection: HubConnection;

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
export const invokeChatHub = async <T = any>(
    methodName: string,
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    ...args: any[]
) => connection.invoke<T>(methodName, ...args);

export const registerChatHubListener = (
    methodName: string,
    callback: CallbackFn,
) => connection.on(methodName, callback);

export const unregisterChatHubListener = (
    methodName: string,
    callback?: CallbackFn,
) =>
    callback
        ? connection.off(methodName, callback)
        : connection.off(methodName);

export const install = async (url: string) => {
    if (!connection) {
        connection = new HubConnectionBuilder()
            .withUrl(url)
            .configureLogging(LogLevel.Information)
            .withAutomaticReconnect()
            .build();
        // connection.onclose(() => start());
        return connection.start();
    }
    return;
};
