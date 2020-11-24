<template>
    <div class="flight__table">
        <p class="flight__table-title">{{ title }}</p>
        <div class="flight__table-flights">
            <span>No flights</span>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

const component = defineComponent({
    props: {
        title: {
            type: String,
            required: true,
        },
        flights: {
            type: Array,
            // required: true,
            default: () => [],
        },
    },
});

export default component;
</script>

<style lang="scss" scoped>
.flight__table {
    margin: 0.4rem 0;
    padding: 0.1rem;
    color: white;
    background-color: #121838;
    border: 0.1rem solid #121838;
    &-title {
        margin: 0;
        padding: 0.5rem 0;
    }
    &-flights {
        color: black;
        background: white;
    }
}
</style>
