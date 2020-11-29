<template>
    <div
        class="node"
        @mousedown.prevent="handleMousedown"
        :class="{ selected: options.selected === node.id }"
    >
        <div class="node__port node__port-input"></div>
        <div class="node__main">
            <div class="node__main-name" :title="node.name">
                {{ node.name }}
            </div>
            <div class="node__main-flight"></div>
        </div>
        <div class="node__port node__port-output"></div>
    </div>
</template>

<script lang="ts">
import { computed, defineComponent } from 'vue';
import { FlowChartNodeModel, Guid, FlowChartNodeOptions } from '@/models';

const component = defineComponent({
    name: 'FlowchartNode',
    props: {
        node: {
            type: Object as () => FlowChartNodeModel,
            default: () => ({
                id: Guid.newGuid(),
                x: 0,
                y: 0,
                name: 'Default',
            }),
        },
        options: {
            type: Object as () => FlowChartNodeOptions,
            default: () => ({
                centerX: 1024,
                centerY: 140,
                selected: Guid.empty,
            }),
        },
    },
    setup(props, { emit }) {
        const nodeTop = computed(
            () => `${props.options.centerY + props.node.y}px`,
        );
        const nodeLeft = computed(
            () => `${props.options.centerX + props.node.x}px`,
        );
        const handleMousedown = (e: MouseEvent) => {
            const target = (e.target || e.srcElement) as HTMLElement;
            if (!target.classList.contains('node-port')) {
                emit('node-selected', e);
            }
        };

        return {
            nodeTop,
            nodeLeft,
            handleMousedown,
        };
    },
});
export default component;
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss" vars="{ nodeTop, nodeLeft }">
.node {
    width: $chartNodeSize;
    height: calc(#{$chartNodeSize} + #{$chartNameSize});
    position: absolute;
    background: $grayBg;
    z-index: 1;
    opacity: 0.9;
    top: var(--nodeTop);
    left: var(--nodeLeft);
    cursor: move;
    &__main {
        &-name {
            background: $primary;
            color: $light;
            font-size: $chartFontSize;
            padding: $chartNamePadding;
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
        }
    }
    &__port {
        position: absolute;
        width: #{$portSize}px;
        height: #{$portSize}px;
        left: 50%;
        transform: translate(-50%);
        border: 1px solid $lightGray;
        border-radius: 50%;
        background: $light;
        &-input {
            top: #{-2 + $portSize/-2}px;
        }
        &-output {
            bottom: #{-2 + $portSize/-2}px;
        }
    }
    &.selected {
        transform: scale(1.1);
        box-shadow: 0 0 3px 2px $primary;
    }
}
</style>
