import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import StationTable from '@/components/Stations/StationTable.vue';

const routes: Array<RouteRecordRaw> = [
    {
        path: '/',
        name: 'ListView',
        component: StationTable,
    },
    {
        path: '/flow',
        name: 'FlowView',
        component: StationTable,
    },
];

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,
});

export default router;
