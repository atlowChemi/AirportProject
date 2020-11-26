<template>
    <div class="station__record" :class="{ available: !station.currentFlight }">
        <p class="station__record-name">{{ station.name }}</p>
        <p class="station__record-state">
            {{ station.currentFlight ? 'Occupied' : 'Available' }}
        </p>
        <p class="station__record-to">more</p>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { Station } from '@/models';

const component = defineComponent({
    props: {
        station: {
            type: Object as () => Station,
            required: true,
        },
    },
    setup() {
        return {};
    },
});

export default component;
</script>

<style lang="scss" scoped>
.station__record {
    display: grid;
    grid-template-columns: 1fr 2fr 4rem;
    align-items: center;
    height: $recordHeight;
    transition: color 200ms linear;
    p {
        margin: 0;
    }
    &:not(:last-of-type) {
        border-bottom: 1px solid $primary;
    }
    &.available {
        color: $good;
    }
    &:not(.available) {
        color: $error;
    }
}
</style>
