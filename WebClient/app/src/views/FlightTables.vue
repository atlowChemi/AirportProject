<template>
    <div>
        <flight-table title="Landing" :flights="data.landingFlights" />
        <flight-table title="Takeoff" :flights="data.takeoffFlights" />
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import FlightTable from '@/components/FlightTable.vue';
import { data } from '@/services';

const component = defineComponent({
    components: { FlightTable },
    setup() {
        return { data };
    },
});

export default component;
</script>
