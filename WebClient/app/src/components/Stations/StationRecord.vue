<template>
    <div class="station__record" :class="{ available: !station.currentFlight }">
        <p class="station__record-name">{{ station.name }}</p>
        <p class="station__record-state">
            {{ station.currentFlight ? 'Occupied' : 'Available' }}
        </p>
        <div class="station__record-to" @click="log">
            <icon name="more" />
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { Station } from '@/models';
import Icon from '@/components/Icons/Icon.vue';

const component = defineComponent({
    components: { Icon },
    props: {
        station: {
            type: Object as () => Station,
            required: true,
        },
    },
    setup() {
        const log = (e: MouseEvent) => console.log(e);
        return { log };
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
    &-to {
        height: 2.5rem;
        width: 2.5rem;
        display: flex;
        align-items: center;
        justify-content: center;
        border-radius: 50%;
        background: transparent;
        cursor: pointer;
        &:hover {
            background: linear-gradient(
                rgba($secondary, 0.4),
                rgba($primaryLight, 0.4)
            );
        }
        svg {
            height: 1.5rem;
            width: 1.4rem;
        }
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
