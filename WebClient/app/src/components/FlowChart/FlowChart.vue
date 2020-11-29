<template>
    <div
        ref="root"
        class="flowchart-container"
        @mousemove="handleMove"
        @mouseup="handleUp"
        @mousedown="handleDown"
    >
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
import { flowChartService } from '@/services';

const component = defineComponent({
    components: { FlowchartLink, FlowchartNode },
    emits: ['node-click', 'canvas-click'],
    setup() {
        addEventListener('resize', flowChartService.initializeChart);
        removeEventListener('resize', flowChartService.initializeChart);
        onMounted(() => flowChartService.initializeChart());
        return {
            ...flowChartService,
            initializeChart: undefined,
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
    svg {
        width: 100%;
        height: calc(#{$maximalTableContentsHeight} - 0.25rem);
    }
}
</style>
