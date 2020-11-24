<template>
    <!-- <div id="nav">
    <router-link to="/">Home</router-link> |
    <router-link to="/about">About</router-link>
  </div>
  <router-view /> -->
    <h1>Welcome To {{ name }} Airport</h1>
    <div class="airport-grid">
        <div>Show stations here</div>
        <flight-tables />
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { name, registerAndGetFlights } from '@/services';
import FlightTables from './views/FlightTables.vue';

const component = defineComponent({
    components: { FlightTables },
    setup() {
        registerAndGetFlights();
        return { name };
    },
});

export default component;
</script>

<style lang="scss">
* {
    box-sizing: border-box;
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
    color: #2c3e50;
    padding: 0.2rem;
}

#nav {
    padding: 30px;

    a {
        font-weight: bold;
        color: #2c3e50;

        &.router-link-exact-active {
            color: #42b983;
        }
    }
}
</style>

<style lang="scss" scoped>
.airport-grid {
    display: grid;
    grid-template-columns: 1fr 1fr;
    column-gap: 0.5rem;
}
</style>
