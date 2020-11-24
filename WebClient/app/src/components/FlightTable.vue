<template>
    <div class="flight__table">
        <p class="flight__table-title">{{ title }}</p>
        <div class="flight__table-flights">
            <span class="flight__table-flights__empty" v-if="!flights.length">
                No flights
            </span>
            <template v-else>
                <flight-record
                    v-for="flight in flights"
                    :key="flight.id"
                    :flight="flight"
                />
            </template>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { Flight } from '@/models/Flight';
import FlightRecord from '@/components/FlightRecord.vue';

const component = defineComponent({
    props: {
        title: {
            type: String,
            required: true,
        },
        flights: {
            type: Array as () => Flight[],
            required: true,
        },
    },
    components: { FlightRecord },
});

export default component;
</script>

<style lang="scss" scoped>
.flight__table {
    margin: 0.4rem 0;
    padding: 0.1rem;
    color: $light;
    background-color: $primary;
    border: 0.1rem solid $primary;
    &-title {
        margin: 0;
        padding: 0.5rem 0;
        font-weight: 800;
    }
    &-flights {
        color: $primary;
        background: $light;
        overflow-y: auto;
        max-height: calc(#{$recordHeight} * 4.5);
        &__empty {
            height: $recordHeight;
            display: flex;
            justify-content: center;
            align-items: center;
        }
    }
}
</style>
