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
            ></FlowchartLink>
        </svg>
        <FlowchartNode
            v-for="node in nodes"
            :key="`node${node.id}`"
            :node="node"
            :options="nodeOptions"
            @nodeSelected="nodeSelected(node.id, $event)"
        >
        </FlowchartNode>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import FlowchartLink from '@/components/FlowChart/FlowChartLink.vue';
import FlowchartNode from '@/components/FlowChart/FlowChartNode.vue';
import { flowChartService } from '@/services';

const component = defineComponent({
    components: { FlowchartLink, FlowchartNode },
    emits: ['node-click', 'canvas-click'],
    setup() {
        flowChartService.initializeChart();
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
    background: $lightGray;
    position: relative;
    overflow: hidden;
    svg {
        width: 100%;
        height: calc(#{$maximalTableContentsHeight} - 0.25rem);
        cursor: grab;
    }
}
</style>
