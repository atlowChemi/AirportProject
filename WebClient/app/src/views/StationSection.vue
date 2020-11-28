<template>
    <Table
        title="Stations"
        :headers="tableHeaders"
        full-page
        :hasHeaders="isTableView"
    >
        <template #table-title>
            <Switch mode1="list" mode2="flow" @update:mode="modeChanged" />
        </template>
        <template #default v-if="data.stations.length"><slot /></template>
    </Table>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useRouter } from 'vue-router';
import { data } from '@/services/AirportService';
import Switch from '@/components/ToggleSwitch/Switch.vue';
import Table from '@/components/Tables/Table.vue';

const component = defineComponent({
    components: { Table, Switch },
    setup() {
        const router = useRouter();
        const isTableView = ref(true);
        const modeChanged = (mode: number) => {
            const name = mode == 1 ? 'ListView' : 'FlowView';
            isTableView.value = name === 'ListView';
            router.push({ name });
        };
        const tableHeaders = {
            columns: '1fr 2fr 4rem',
            data: ['name', 'state', 'more'],
        };
        return { modeChanged, tableHeaders, isTableView, data };
    },
});

export default component;
</script>
