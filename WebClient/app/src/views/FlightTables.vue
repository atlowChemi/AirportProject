<template>
    <div>
        <flight-table title="Landing" />
        <flight-table title="Takeoff" />
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import FlightTable from '@/components/FlightTable.vue';

const component = defineComponent({
    components: { FlightTable },
});

export default component;
</script>
