const prettifyDate = (number: number) =>
    number > 9 ? `${number}` : `0${number}`;
const amPmify = (hour: number) => (hour >= 12 ? 'PM' : 'AM');

const showDateStringAsTime = (date: string) => {
    const dateObj = new Date(date);
    const time = [
        dateObj.getHours(),
        dateObj.getMinutes(),
        dateObj.getSeconds(),
    ];
    const ampm = amPmify(time[0]);
    time[0] = time[0] % 12;
    time[0] = time[0] ? time[0] : 12;
    const [hours, minutes, seconds] = time.map(prettifyDate);
    return `${hours}:${minutes}:${seconds} ${ampm}`;
};

export const timeService = { showDateStringAsTime };
