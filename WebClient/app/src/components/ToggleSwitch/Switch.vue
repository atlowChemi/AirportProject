<template>
    <div class="toggle" :class="`mode${mode}`" @click="toggle">
        <div class="toggle__bubble"></div>
        <icon :name="mode1" :class="{ selected: mode === 1 }" />
        <icon :name="mode2" :class="{ selected: mode === 2 }" />
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import Icon from '@/components/Icons/Icon.vue';

const component = defineComponent({
    components: { Icon },
    emits: ['update:mode'],
    props: {
        mode: {
            type: Number,
            default: 1,
        },
        mode1: {
            type: String,
            required: true,
        },
        mode2: {
            type: String,
            required: true,
        },
    },
    setup(props, { emit }) {
        const toggle = () => {
            const newMode = props.mode === 1 ? 2 : 1;
            emit('update:mode', newMode);
        };
        return { toggle };
    },
});

export default component;
</script>

<style lang="scss">
.toggle {
    height: $toggleHeight;
    width: $toggleWidth;
    display: flex;
    justify-content: space-around;
    position: absolute;
    right: $pagePadding;
    padding: $togglePadding;
    background: $secondary;
    background: linear-gradient(
        0,
        $secondary,
        rgba($color: $secondary, $alpha: 1)
    );
    border-radius: $toggleRadius;
    background-clip: padding-box;
    overflow: hidden;
    cursor: pointer;
    svg {
        width: $toggleIcons;
        z-index: 2;
        transition: fill $toggleDuration;
        &.selected {
            fill: $light;
        }
    }
    &__bubble {
        position: absolute;
        width: calc(#{$toggleWidth} / 2);
        height: $toggleHeight;
        border-radius: $toggleRadius;
        background-clip: padding-box;
        background: $primaryLight;
        background: $buttonBG;
        box-shadow: 0 0.25rem 0.4rem 0 $primary;
        z-index: 1;
        transition: transform $toggleDuration;
        .mode1 & {
            transform: translateX(-50%);
        }
        .mode2 & {
            transform: translateX(50%);
        }
    }
}
</style>
