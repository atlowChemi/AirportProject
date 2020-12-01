<template>
    <div class="table__header">
        <p v-for="(item, index) in data" :key="index">{{ item }}</p>
    </div>
</template>

<script lang="ts">
import { defineComponent, useCssVars } from 'vue';

const component = defineComponent({
    props: {
        data: {
            type: Array as () => string[],
            required: true,
        },
        columns: {
            type: String,
            required: true,
        },
    },
    setup(props) {
        useCssVars(() => ({ columns: props.columns }));
    },
});

export default component;
</script>

<style lang="scss">
.table__header {
    display: grid;
    grid-template-columns: var(--columns);
    align-items: center;
    height: $recordHeight;
    position: sticky;
    top: 0;
    border-bottom: 1px solid $primary;
    background: $light;
    z-index: 2;
    p {
        margin: 0;
        font-weight: bold;
        text-transform: capitalize;
    }
}
</style>
