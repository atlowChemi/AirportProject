<template>
    <div class="history__record">
        <p class="history__record-name">{{ flightName }}</p>
        <p class="history__record-enter">{{ enter }}</p>
        <p class="history__record-leave">{{ leave }}</p>
    </div>
</template>

<script lang="ts">
import { defineComponent, computed } from 'vue';
import { FlightHistory } from '@/models';
import { timeService } from '@/services';

const component = defineComponent({
    props: {
        history: {
            type: Object as () => FlightHistory,
            required: true,
        },
    },
    setup(props) {
        const flightName = computed(() => {
            const flight = props.history.flight;
            const shortId = flight.id.substring(0, 4).toUpperCase();
            return `${flight.to}-${shortId}`;
        });
        const enter = computed(() =>
            props.history.enterStationTime
                ? timeService.showDateStringReadable(
                      props.history.enterStationTime,
                  )
                : 'TBA',
        );
        const leave = computed(() =>
            props.history.leaveStationTime
                ? timeService.showDateStringReadable(
                      props.history.leaveStationTime,
                  )
                : 'TBA',
        );
        return { flightName, enter, leave };
    },
});
export default component;
</script>

<style lang="scss" scoped>
.history__record {
    display: grid;
    grid-template-columns: 6rem repeat(2, 1fr);
    align-items: center;
    height: $recordHeight;
    transition: color 200ms linear;
    p {
        margin: 0;
    }
    &:not(:first-of-type) {
        border-bottom: 1px solid $primary;
    }
}
</style>
