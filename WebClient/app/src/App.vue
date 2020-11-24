<template>
    <h1>Welcome To {{ name }} Airport</h1>
    <div class="airport-grid">
        <div>Show stations here</div>
        <flight-tables />
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { name } from '@/services';
import FlightTables from './views/FlightTables.vue';

const component = defineComponent({
    components: { FlightTables },
    setup() {
        return { name };
    },
});

export default component;
</script>

<style lang="scss">
* {
    box-sizing: border-box;
}
::-webkit-scrollbar {
    width: 0.4rem;
    &-track {
        background: $secondary;
    }
    &-thumb {
        background: $primary;
        &:hover {
            background: $primaryLight;
        }
    }
}
html,
body {
    margin: 0;
    padding: 0;
    height: 100%;
    overflow: hidden;
}
#app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: $primary;
    padding: 0.2rem;
}
</style>

<style lang="scss" scoped>
.airport-grid {
    display: grid;
    grid-template-columns: 1fr 1fr;
    column-gap: 0.5rem;
}
</style>
