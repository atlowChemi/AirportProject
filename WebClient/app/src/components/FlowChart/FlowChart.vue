<template>
    <div
        ref="root"
        class="flowchart-container"
        @mousemove="handleMove"
        @mouseup="handleUp"
        @mousedown="handleDown"
    >
        <transition-group name="fade">
            <FlowChartFlight
                v-for="flight in data.movingFlights"
                :key="flight.id"
                :flight="flight"
            />
        </transition-group>
        <svg>
            <FlowchartLink
                :link-data="link"
                v-for="link in lines"
                :key="`link${link.id}`"
            />
        </svg>
        <FlowchartNode
            v-for="node in nodes"
            :key="`node${node.id}`"
            :node="node"
            :options="nodeOptions"
            @nodeSelected="nodeSelected(node.id, $event)"
        />
    </div>
</template>

<script lang="ts">
import { defineComponent, onMounted } from 'vue';
import FlowchartLink from '@/components/FlowChart/FlowChartLink.vue';
import FlowchartNode from '@/components/FlowChart/FlowChartNode.vue';
import FlowChartFlight from '@/components/FlowChart/FlowChartFlight.vue';
import { flowChartService, data } from '@/services';

const component = defineComponent({
    components: { FlowchartLink, FlowchartNode, FlowChartFlight },
    emits: ['node-click', 'canvas-click'],
    setup() {
        addEventListener('resize', flowChartService.initializeChart);
        removeEventListener('resize', flowChartService.initializeChart);
        onMounted(() => flowChartService.initializeChart());
        return {
            data,
            ...flowChartService,
            initializeChart: undefined,
            getNodeLocation: undefined,
        };
    },
});

export default component;
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.flowchart-container {
    margin: 0;
    position: relative;
    overflow: hidden;
    height: $maximalTableContentsHeight;
    svg {
        width: 100%;
        height: 100%;
    }
}
</style>
