<template>
    <div>
        <flight-table title="Landing" :flights="flights[0]" />
        <flight-table title="Takeoff" :flights="flights[1]" />
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import FlightTable from '@/components/FlightTable.vue';
import { flights } from '@/services';

const component = defineComponent({
    components: { FlightTable },
    setup() {
        return { flights };
    },
});

export default component;
</script>
