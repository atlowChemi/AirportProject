<template>
    <transition-group name="list">
        <FlightRecord
            v-for="flight in flights"
            :key="flight.id"
            :flight="flight"
        />
    </transition-group>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { Flight } from '@/models/Flight';
import FlightRecord from '@/components/Flights/FlightRecord.vue';

const component = defineComponent({
    components: { FlightRecord },
    props: {
        flights: {
            type: Array as () => Flight[],
            required: true,
        },
    },
});

export default component;
</script>
