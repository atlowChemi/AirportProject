<template>
    <div class="flight__record" :class="{ delayed: isLate }">
        <p class="flight__record-from">{{ flight.from }}</p>
        <p class="flight__record-time">
            {{ hours }}:{{ minutes }}:{{ seconds }}
        </p>
        <p class="flight__record-to">{{ flight.to }}</p>
    </div>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted, computed } from 'vue';
import { Flight } from '@/models/Flight';

const component = defineComponent({
    props: {
        flight: {
            type: Object as () => Flight,
            required: true,
        },
    },
    setup(props) {
        const timeLeft = ref(
            Date.parse(props.flight.plannedTime) - new Date().getTime(),
        );
        const isLate = ref(false);
        const formatTime = (value: number) =>
            value < 10 ? `0${value}` : `${value}`;
        const countdown = () => {
            timeLeft.value =
                Date.parse(props.flight.plannedTime) - new Date().getTime();
            isLate.value = timeLeft.value <= 0;
            setTimeout(countdown, 1000);
        };
        const seconds = computed(() => {
            const method = timeLeft.value > 0 ? Math.floor : Math.ceil;
            return formatTime(Math.abs(method((timeLeft.value / 1000) % 60)));
        });
        const minutes = computed(() => {
            const method = timeLeft.value > 0 ? Math.floor : Math.ceil;
            return formatTime(
                Math.abs(method((timeLeft.value / 1000 / 60) % 60)),
            );
        });
        const hours = computed(() => {
            const method = timeLeft.value > 0 ? Math.floor : Math.ceil;
            return formatTime(
                Math.abs(method((timeLeft.value / (1000 * 60 * 60)) % 24)),
            );
        });

        onMounted(() => setTimeout(countdown, 1000));

        return { seconds, minutes, hours, isLate };
    },
});

export default component;
</script>

<style lang="scss" scoped>
.flight__record {
    display: grid;
    grid-template-columns: 4rem 1fr 4rem;
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
