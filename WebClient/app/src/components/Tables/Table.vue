<template>
    <div class="table" :class="{ 'full-page': fullPage }">
        <div class="table__title">
            <div class="table__title-verbal">{{ title }}</div>
            <slot name="table-title" />
        </div>
        <div class="table__contents">
            <TableHeaders v-if="showTitle" v-bind="{ ...headers }" />
            <slot name="default">
                <span class="table__contents-empty">
                    No entries available.
                </span>
            </slot>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent, computed } from 'vue';
import TableHeaders from '@/components/Tables/TableHeaders.vue';

const component = defineComponent({
    components: { TableHeaders },
    props: {
        title: {
            type: String,
            required: true,
        },
        fullPage: {
            type: Boolean,
            default: false,
        },
        hasHeaders: {
            type: Boolean,
            default: true,
        },
        headers: {
            type: Object as () => { data: string[]; columns: string },
            default: () => ({ data: [], columns: '' }),
        },
    },
    setup(props, { slots }) {
        const showTitle = computed(
            () => props.hasHeaders && Boolean(slots.default),
        );
        return { showTitle };
    },
});

export default component;
</script>

<style lang="scss" scoped>
.table {
    margin: $tableMargin 0;
    padding: $tablePadding;
    color: $light;
    background-color: $primary;
    border: $tableBorderWidth solid $primary;
    &.full-page {
        max-height: calc(100% - #{$tableMargin});
        overflow: hidden;
    }
    &__title {
        display: flex;
        height: $titleHeight;
        justify-content: center;
        align-items: center;
        margin: 0;
        font-weight: 800;
        position: relative;
        padding-bottom: $tablePadding;
    }
    &__contents {
        color: $primary;
        background: $light;
        overflow-y: auto;
        max-height: calc(#{$recordHeight} * 4.5);
        .full-page & {
            max-height: $maximalTableContentsHeight;
        }
        &-empty {
            height: $recordHeight;
            display: flex;
            justify-content: center;
            align-items: center;
        }
    }
}
</style>
