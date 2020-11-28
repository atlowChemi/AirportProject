<template>
    <div>
        <Table title="Landing" :headers="tableHeaders">
            <template #default v-if="data.landingFlights.length">
                <FlightTable :flights="data.landingFlights" />
            </template>
        </Table>
        <Table title="Takeoff" :headers="tableHeaders">
            <template #default v-if="data.takeoffFlights.length">
                <FlightTable :flights="data.landingFlights" />
            </template>
        </Table>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import Table from '@/components/Tables/Table.vue';
import FlightTable from '@/components/Flights/FlightTable.vue';
import { data } from '@/services';

const component = defineComponent({
    components: { FlightTable, Table },
    setup() {
        const tableHeaders = {
            columns: '4rem repeat(2, 1fr) 4rem',
            data: ['from', 'ETA', 'time left', 'to'],
        };
        return { data, tableHeaders };
    },
});

export default component;
</script>
