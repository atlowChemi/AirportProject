import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import StationTable from '@/components/Stations/StationTable.vue';
const flowChart = () => import('@/components/FlowChart/FlowChart.vue');

const routes: Array<RouteRecordRaw> = [
    {
        path: '/flow',
        name: 'FlowView',
        component: flowChart,
    },
    {
        path: '/:pathMatch(.*)*',
        name: 'ListView',
        component: StationTable,
    },
    {
        path: '/:pathMatch(.*)*',
        name: 'ListView',
        component: StationTable,
    },
];

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,
});

export default router;
