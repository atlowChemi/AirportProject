<template>
    <template v-if="data.stations.length">
        <transition-group name="list">
            <StationRecord
                v-for="station in data.stations"
                :key="station.id"
                :station="station"
            />
        </transition-group>
    </template>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import StationRecord from '@/components/Stations/StationRecord.vue';
import { data } from '@/services';

const component = defineComponent({
    components: { StationRecord },
    setup() {
        return { data };
    },
});

export default component;
</script>
