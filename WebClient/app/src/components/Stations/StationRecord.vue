<template>
    <div class="station__record" :class="{ available: !station.currentFlight }">
        <p class="station__record-name">{{ station.name }}</p>
        <p class="station__record-state">
            {{ station.currentFlight ? 'Occupied' : 'Available' }}
        </p>
        <div class="station__record-to" @click="toggle">
            <div class="station__record-to__bubble"></div>
            <Icon name="more" />
            <teleport to="#app" v-if="showInfo">
                <Modal
                    v-if="showInfo"
                    :close="() => (showInfo = false)"
                    :title="station.name"
                >
                    <template #default>
                        <StationInfo :station="station" />
                    </template>
                </Modal>
            </teleport>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { Station } from '@/models';
import Icon from '@/components/Icons/Icon.vue';
import Modal from '@/components/Modal/Modal.vue';
import StationInfo from '@/components/Stations/StationInfo.vue';

const component = defineComponent({
    components: { Icon, Modal, StationInfo },
    props: {
        station: {
            type: Object as () => Station,
            required: true,
        },
    },
    setup() {
        const showInfo = ref(false);
        const toggle = () => (showInfo.value = !showInfo.value);
        return { showInfo, toggle };
    },
});

export default component;
</script>

<style lang="scss" scoped>
.station__record {
    display: grid;
    grid-template-columns: 1fr 2fr 4rem;
    align-items: center;
    height: $recordHeight;
    transition: color 200ms linear;
    p {
        margin: 0;
    }
    &-to {
        height: 2.5rem;
        width: 2.5rem;
        position: relative;
        display: flex;
        align-items: center;
        justify-content: center;
        border-radius: 50%;
        background: transparent;
        cursor: pointer;
        overflow: hidden;
        &__bubble {
            background: linear-gradient(
                rgba($secondary, 0.4),
                rgba($primaryLight, 0.4)
            );
            width: 100%;
            height: 100%;
            position: absolute;
            opacity: 0;
            transition: opacity 350ms;
            &:hover {
                opacity: 1;
            }
        }
        svg {
            height: 1.5rem;
            width: 1.4rem;
        }
    }
    &:not(:last-of-type) {
        border-bottom: 1px solid $primary;
    }
    &.available {
        color: $good;
    }
    &:not(.available) {
        color: $error;
    }
}
</style>
