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
    height: 2.5rem;
    width: 6rem;
    display: flex;
    justify-content: space-around;
    position: absolute;
    right: $pagePadding;
    background: $secondary;
    background: linear-gradient(
        0,
        $secondary,
        rgba($color: $secondary, $alpha: 1)
    );
    border-radius: 1.25rem;
    overflow: hidden;
    cursor: pointer;
    svg {
        width: 1.4rem;
        z-index: 2;
        transition: fill 250ms;
        &.selected {
            fill: $light;
        }
    }
    &__bubble {
        position: absolute;
        width: 3rem;
        height: 2.5rem;
        border-radius: 1.25rem;
        background: $primaryLight;
        background: linear-gradient(224.46deg, $primaryLight, $primaryLight2);
        box-shadow: 0 0.25rem 0.4rem 0 $primary;
        z-index: 1;
        transition: transform 250ms;
        .mode1 & {
            transform: translateX(-50%);
        }
        .mode2 & {
            transform: translateX(50%);
        }
    }
}
</style>
