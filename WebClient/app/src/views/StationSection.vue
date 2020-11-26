<template>
    <div class="station__table">
        <p class="station__table-title">Stations</p>
        <div class="station__table-stations">
            <slot />
        </div>
    </div>
</template>

<style lang="scss" scoped>
@include tabelify(station, true);
</style>
