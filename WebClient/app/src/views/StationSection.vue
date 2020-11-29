<template>
    <Table
        title="Stations"
        :headers="tableHeaders"
        :has-headers="Boolean(data.stations.length) && isTableView"
        full-page
    >
        <template #table-title>
            <Switch
                v-model:mode="mode"
                mode1="list"
                mode2="flow"
                @update:mode="modeChanged"
            />
        </template>
        <template #default v-if="data.stations.length"><slot /></template>
    </Table>
</template>

<script lang="ts">
import { defineComponent, computed, ref } from 'vue';
import { useRouter, useRoute } from 'vue-router';
import { data } from '@/services/AirportService';
import Switch from '@/components/ToggleSwitch/Switch.vue';
import Table from '@/components/Tables/Table.vue';

const component = defineComponent({
    components: { Table, Switch },
    setup() {
        const router = useRouter();
        const route = useRoute();

        const isTableView = computed(() => route.name === 'ListView');
        const mode = ref(route.name === 'ListView' ? 1 : 2);
        const modeChanged = (mode: number) => {
            const name = mode == 1 ? 'ListView' : 'FlowView';
            router.push({ name });
        };
        const tableHeaders = {
            columns: '1fr 2fr 4rem',
            data: ['name', 'state', 'more'],
        };
        return { mode, modeChanged, tableHeaders, isTableView, data };
    },
});

export default component;
</script>
