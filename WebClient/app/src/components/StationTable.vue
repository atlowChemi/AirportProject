<template>
    <span class="station__table-stations__empty" v-if="!data.stations.length">
        No stations found!
    </span>
    <template v-else>
        <table-headers
            :columns="'1fr 2fr 4rem'"
            :data="['name', 'state', 'more']"
        />
        <station-record
            v-for="station in data.stations"
            :key="station.id"
            :station="station"
        />
    </template>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import StationRecord from '@/components/StationRecord.vue';
import TableHeaders from '@/components/TableHeaders.vue';
import { data } from '@/services';

const component = defineComponent({
    components: { StationRecord, TableHeaders },
    setup() {
        return { data };
    },
});

export default component;
</script>
