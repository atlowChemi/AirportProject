<template>
    <div
        class="node"
        @mousedown.prevent="handleMousedown"
        @dblclick="log"
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
    <teleport to="#app" v-if="showInfo">
        <Modal
            v-if="showInfo"
            :close="() => (showInfo = false)"
            :title="station?.name || ''"
        >
            <template #default>
                <StationInfo :station="station" />
            </template>
        </Modal>
    </teleport>
</template>

<script lang="ts">
import { computed, defineComponent, ref, useCssVars } from 'vue';
import { FlowChartNodeModel, Guid, FlowChartNodeOptions } from '@/models';
import { data } from '@/services';

import Modal from '@/components/Modal/Modal.vue';
import StationInfo from '@/components/Stations/StationInfo.vue';

const component = defineComponent({
    components: { Modal, StationInfo },
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
    emits: ['nodeselected'],
    setup(props, { emit }) {
        const showInfo = ref(false);
        const station = computed(() =>
            data.value.stations.find(s => s.id === props.node.id),
        );
        const nodeTop = computed(
            () => `${props.options.centerY + props.node.y}px`,
        );
        const nodeLeft = computed(
            () => `${props.options.centerX + props.node.x}px`,
        );

        useCssVars(() => ({
            nodeTop: nodeTop.value,
            nodeLeft: nodeLeft.value,
        }));
        const handleMousedown = (e: MouseEvent) => {
            const target = (e.target || e.srcElement) as HTMLElement;
            if (!target.classList.contains('node-port')) {
                emit('nodeselected', e);
            }
        };
        const log = () => (showInfo.value = true);

        return {
            nodeTop,
            nodeLeft,
            handleMousedown,
            log,
            showInfo,
            station,
        };
    },
});
export default component;
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
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
