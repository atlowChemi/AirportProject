<template>
    <div>
        <flight-table title="Landing" :flights="landingFlights" />
        <flight-table title="Takeoff" :flights="takeoffFlights" />
    </div>
</template>

<script lang="ts">
import { defineComponent, computed } from 'vue';
import FlightTable from '@/components/FlightTable.vue';
import { FlightDirection } from '@/models/FlightDirection';
import { data } from '@/services';

const component = defineComponent({
    components: { FlightTable },
    setup() {
        const landingFlights = computed(() =>
            data.flights
                .filter(f => f.direction == FlightDirection.Landing)
                .sort(
                    (a, b) =>
                        Date.parse(a.plannedTime) - Date.parse(b.plannedTime),
                ),
        );
        const takeoffFlights = computed(() =>
            data.flights
                .filter(f => f.direction == FlightDirection.Takeoff)
                .sort(
                    (a, b) =>
                        Date.parse(a.plannedTime) - Date.parse(b.plannedTime),
                ),
        );
        return { landingFlights, takeoffFlights };
    },
});

export default component;
</script>
