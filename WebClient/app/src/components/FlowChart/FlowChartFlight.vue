<template>
    <div class="flight">
        <Icon name="flight" />
    </div>
</template>

<script lang="ts">
import { defineComponent, ref, watch } from 'vue';
import { Flight, Guid } from '@/models';
import { flowChartService } from '@/services';
import Icon from '@/components/Icons/Icon.vue';

const component = defineComponent({
    components: { Icon },
    props: {
        flight: {
            type: Object as () => Flight,
            required: true,
        },
    },
    setup(props) {
        const xPos = ref(0);
        const yPos = ref(0);
        const angle = ref(0);
        watch(
            () => props.flight.stationId,
            () => {
                const [x = 0, y = 0] = flowChartService.getNodeLocation(
                    props.flight.stationId ?? Guid.empty,
                );

                let theta = Math.atan2(y - yPos.value, x - xPos.value);
                theta *= 180 / Math.PI;

                xPos.value = x;
                yPos.value = y;
                angle.value = theta;
                setTimeout(() => (angle.value = 0), 800);
            },
            { immediate: true },
        );
        return { xPos, yPos, angle };
    },
});

export default component;
</script>

<style
    lang="scss"
    scoped
    vars="{ xPos: `${xPos}px`, yPos: `${yPos}px`, angle: `${angle}deg` }"
>
.flight {
    height: 3rem;
    width: 3rem;
    position: absolute;
    top: calc(var(--yPos) + #{$chartNameSize} + calc(#{$chartNodeSize} / 2));
    left: calc(var(--xPos) + calc(#{$chartNodeSize} / 2));
    z-index: 3;
    transform: translate(-50%, -50%) rotate(calc(var(--angle) + 90deg));
    transition: all 800ms ease-in, transform 150ms ease-in-out;
}
</style>
