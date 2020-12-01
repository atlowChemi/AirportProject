<template>
    <g :class="{ [linkData.direction]: true }">
        <path :d="dAttr" class="line"></path>
        <path class="head" d="M -1 -1 L 0 1 L 1 -1 z"></path>
    </g>
</template>

<script lang="ts">
import { computed, defineComponent, useCssVars } from 'vue';
import { FlowChartLinkModel, FlightDirection } from '@/models';
import { positionService } from '@/services';

const component = defineComponent({
    name: 'FlowchartLink',
    props: {
        linkData: {
            type: Object as () => FlowChartLinkModel,
            required: true,
        },
    },
    setup(props) {
        const arrowTransform = computed(() =>
            positionService.linkArrowTransform(props.linkData),
        );
        const dAttr = computed(() =>
            positionService.createLinkLine(props.linkData),
        );
        const color = computed(() =>
            props.linkData.direction == FlightDirection.Landing
                ? '#12b304'
                : '#d40d0d',
        );

        useCssVars(() => ({
            color: color.value,
            arrowTransform: arrowTransform.value,
        }));

        return {
            arrowTransform,
            dAttr,
            color,
        };
    },
});

export default component;
</script>

<style scoped lang="scss">
g {
    fill: none;
    stroke: var(--color);
    path {
        transform-origin: 0 0;
        &.head {
            stroke-width: 5.73205;
            transform: var(--arrowTransform);
        }
        &.line {
            stroke-width: 2.73205;
        }
    }
}
</style>
