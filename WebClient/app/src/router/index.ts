import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import StationTable from '@/components/Stations/StationTable.vue';
import FlowChart from '@/components/FlowChart/FlowChart.vue';

const routes: Array<RouteRecordRaw> = [
    {
        path: '/',
        name: 'ListView',
        component: StationTable,
    },
    {
        path: '/flow',
        name: 'FlowView',
        component: FlowChart,
    },
];

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,
});

export default router;
