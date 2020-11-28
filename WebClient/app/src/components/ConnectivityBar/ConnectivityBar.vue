<template>
    <div class="connectivity__bar" :class="{ error, attempt, success }">
        <span v-if="error">
            An unhadled issue has terminated the connection with the server.
        </span>
        <span v-else-if="attempt">
            Attempting to connect to server.
        </span>
        <span v-else-if="success">
            Successfully initialized connection with server.
        </span>
    </div>
</template>

<script lang="ts">
import { defineComponent, computed } from 'vue';
import { ConnectionState } from '@/models';

const component = defineComponent({
    props: {
        state: {
            type: String as () => ConnectionState,
            required: true,
        },
    },
    setup(props) {
        const error = computed(() => props.state === 'disconnected');
        const attempt = computed(() => props.state === 'connecting');
        const success = computed(() => props.state === 'connected');
        return { error, attempt, success };
    },
});
export default component;
</script>

<style lang="scss" scoped>
.connectivity__bar {
    position: sticky;
    bottom: 0;
    z-index: 20;
    margin: 0 -#{$pagePadding};
    height: $recordHeight;
    font-size: 1.2rem;
    display: flex;
    align-items: center;
    justify-content: center;
    color: $light;
    text-shadow: 0 0 0.5rem $dark;
    box-shadow: 0 0px 0.4rem $dark;
    &.error {
        background: $error;
    }
    &.attempt {
        text-shadow: 0 0 0.5rem $light;
        background: $primary;
    }
    &.success {
        background: $good;
    }
}
</style>
