import { computed, ComputedRef, Ref, ref } from 'vue';

const prettifyDate = (number: number) =>
    (number = Math.abs(number)) > 9 ? `${number}` : `0${number}`;
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

const getTimeLeftTillDate = (date: string) =>
    Date.parse(date) - new Date().getTime();

const createCountDown: (
    date: string,
) => [
    ComputedRef<string>,
    ComputedRef<string>,
    ComputedRef<string>,
    Ref<boolean>,
] = date => {
    const timeLeft = ref(getTimeLeftTillDate(date));
    const isLate = ref(false);

    const countdown = () => {
        timeLeft.value = getTimeLeftTillDate(date);
        isLate.value = timeLeft.value <= 0;
        setTimeout(countdown, 1000);
    };

    const floorOrCiel = computed(() =>
        timeLeft.value > 0 ? Math.floor : Math.ceil,
    );

    const seconds = computed(() => {
        const seconds = floorOrCiel.value((timeLeft.value / 1000) % 60);
        return prettifyDate(seconds);
    });
    const minutes = computed(() => {
        const minutes = floorOrCiel.value((timeLeft.value / 1000 / 60) % 60);
        return prettifyDate(minutes);
    });
    const hours = computed(() => {
        const seconds = floorOrCiel.value(
            (timeLeft.value / (1000 * 60 * 60)) % 24,
        );
        return prettifyDate(seconds);
    });
    countdown();
    return [hours, minutes, seconds, isLate];
};

export const timeService = { showDateStringAsTime, createCountDown };
