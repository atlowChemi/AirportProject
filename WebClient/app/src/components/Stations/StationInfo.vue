<template>
    <p>
        Current state:
        {{ station.currentFlight ? 'Occupied' : 'Available' }}
    </p>

    <Table title="Station History" :headers="tableHeader">
        <template v-if="flightHistory.data.elements.length">
            <FlightHistoryRecord
                v-for="history in flightHistory.data.elements"
                :key="history.id"
                :history="history"
            />
        </template>
    </Table>

    <Pagination
        :current-page="currentPage"
        :maximal-page="flightHistory.data.maxPage"
        @moved-to="loadFlightHistoryData($event)"
    />
</template>

<script lang="ts">
import { defineComponent, reactive, ref } from 'vue';
import { Station, PaginatedData, FlightHistory } from '@/models';
import { flightService } from '@/services';
import FlightHistoryRecord from '@/components/FlightHistory/FlightHistoryRecord.vue';
import Pagination from '@/components/Pagination/Pagination.vue';
import Table from '@/components/Tables/Table.vue';

const component = defineComponent({
    components: { FlightHistoryRecord, Pagination, Table },
    props: {
        station: {
            type: Object as () => Station,
            required: true,
        },
    },
    setup(props) {
        const flightHistory = reactive<{ data: PaginatedData<FlightHistory> }>({
            data: {
                elements: [],
                total: 1,
                maxPage: 1,
            },
        });
        const currentPage = ref(1);

        const tableHeader = {
            data: ['Name', 'entered', 'left'],
            columns: '6rem repeat(2, 1fr)',
        };

        const loadFlightHistoryData = async (page = 1) => {
            currentPage.value = page;
            flightHistory.data = await flightService.getStationFlightHistory(
                props.station.id,
                page,
            );
        };

        loadFlightHistoryData();

        return {
            flightHistory,
            currentPage,
            loadFlightHistoryData,
            tableHeader,
        };
    },
});

export default component;
</script>

<style lang="scss" scoped>
p {
    text-align: left;
}
</style>
