<template>
    <div class="flight__record" :class="{ delayed: isLate }">
        <p class="flight__record-from">{{ flight.from }}</p>
        <p class="flight__record-planned">{{ planned }}</p>
        <p class="flight__record-time">
            {{ hours }}:{{ minutes }}:{{ seconds }}
        </p>
        <p class="flight__record-to">{{ flight.to }}</p>
    </div>
</template>

<script lang="ts">
import { defineComponent, computed } from 'vue';
import { Flight } from '@/models/Flight';
import { timeService } from '@/services';

const component = defineComponent({
    props: {
        flight: {
            type: Object as () => Flight,
            required: true,
        },
    },
    setup(props) {
        const planned = computed(() =>
            timeService.showDateStringAsTime(props.flight.plannedTime),
        );
        const [hours, minutes, seconds, isLate] = timeService.createCountDown(
            props.flight.plannedTime,
        );

        return { seconds, minutes, hours, isLate, planned };
    },
});

export default component;
</script>

<style lang="scss" scoped>
.flight__record {
    display: grid;
    grid-template-columns: 4rem repeat(2, 1fr) 4rem;
    align-items: center;
    height: $recordHeight;
    transition: color 200ms linear;
    p {
        margin: 0;
    }
    &:not(:last-of-type) {
        border-bottom: 1px solid $primary;
    }
    &.delayed {
        color: $error;
    }
}
</style>
