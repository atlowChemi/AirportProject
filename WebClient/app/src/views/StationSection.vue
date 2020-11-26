<template>
    <div class="station__table">
        <p class="station__table-title">
            Stations
            <Switch mode1="list" mode2="flow" @update:mode="modeChanged" />
        </p>
        <div class="station__table-stations">
            <slot />
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { useRouter } from 'vue-router';
import Switch from '@/components/ToggleSwitch/Switch.vue';

const component = defineComponent({
    components: { Switch },
    setup() {
        const router = useRouter();
        const modeChanged = (mode: number) => {
            const name = mode == 1 ? 'ListView' : 'FlowView';
            router.push({ name });
        };
        return { modeChanged };
    },
});

export default component;
</script>

<style lang="scss" scoped>
@include tabelify(station, true);
</style>
