<template>
    <div class="toggle" :class="`mode${numeralMode}`" @click="toggle">
        <div class="toggle__bubble"></div>
        <icon :name="mode1" :class="{ selected: !mode }" />
        <icon :name="mode2" :class="{ selected: mode }" />
    </div>
</template>

<script lang="ts">
import { defineComponent, ref, computed } from 'vue';
import Icon from '@/components/Icons/Icon.vue';

const component = defineComponent({
    components: { Icon },
    props: {
        mode1: {
            type: String,
            required: true,
        },
        mode2: {
            type: String,
            required: true,
        },
    },
    setup(_, { emit }) {
        const mode = ref(false);
        const numeralMode = computed(() => (mode.value ? 2 : 1));
        const toggle = () => {
            mode.value = !mode.value;
            emit('update:mode', numeralMode.value);
        };
        return { mode, numeralMode, toggle };
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
