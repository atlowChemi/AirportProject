<template>
    <div class="flight__table">
        <p class="flight__table-title">{{ title }}</p>
        <div class="flight__table-flights">
            <span class="flight__table-flights__empty" v-if="!flights.length">
                No flights
            </span>
            <template v-else>
                <TableHeaders
                    :data="['from', 'ETA', 'time left', 'to']"
                    :columns="'4rem repeat(2, 1fr) 4rem'"
                />
                <transition-group name="list">
                    <FlightRecord
                        v-for="flight in flights"
                        :key="flight.id"
                        :flight="flight"
                    />
                </transition-group>
            </template>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { Flight } from '@/models/Flight';
import FlightRecord from '@/components/Flights/FlightRecord.vue';
import TableHeaders from '@/components/Tables/TableHeaders.vue';

const component = defineComponent({
    components: { FlightRecord, TableHeaders },
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
});

export default component;
</script>

<style lang="scss" scoped>
@include tabelify(flight);
</style>
