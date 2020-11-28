<template>
    <div class="pagination">
        <transition-group name="list">
            <button
                :disabled="disabled"
                key="first"
                v-if="currentPage > 2"
                @click="moveTo(1)"
            >
                1
            </button>
            <button disabled v-if="currentPage > 3" key="morePrev">...</button>
            <button
                :disabled="disabled"
                key="prev"
                v-if="currentPage > 1"
                @click="moveTo(prevPage)"
            >
                {{ prevPage }}
            </button>
            <button disabled class="current" key="current">
                {{ currentPage }}
            </button>
            <button
                :disabled="disabled"
                key="next"
                v-if="currentPage < maximalPage"
                @click="moveTo(nextPage)"
            >
                {{ nextPage }}
            </button>
            <button
                disabled
                v-if="currentPage < maximalPage - 2"
                key="moreNext"
            >
                ...
            </button>
            <button
                :disabled="disabled"
                key="last"
                v-if="currentPage < maximalPage - 3"
                @click="moveTo(maximalPage)"
            >
                {{ maximalPage }}
            </button>
        </transition-group>
    </div>
</template>

<script lang="ts">
import { defineComponent, computed } from 'vue';

const component = defineComponent({
    props: {
        currentPage: {
            type: Number,
            reqired: true,
            default: 1,
        },
        maximalPage: {
            type: Number,
            reqired: true,
            default: 1,
        },
        disabled: {
            type: Boolean,
            default: false,
        },
    },
    emits: ['moved-to'],
    setup(props, { emit }) {
        const prevPage = computed(() => props.currentPage - 1);
        const nextPage = computed(() => props.currentPage + 1);
        const moveTo = (page: number) => emit('moved-to', page);
        return { prevPage, nextPage, moveTo };
    },
});

export default component;
</script>

<style lang="scss" scoped>
.pagination {
    height: $recordHeight;
    margin: $tableMargin 0;
    display: flex;
    align-items: center;
    justify-content: center;
    button {
        height: $toggleHeight;
        width: $toggleHeight;
        font-size: 1.2rem;
        background: rgba($lightGray, 0.5);
        outline: none;
        border: 1px solid $primary;
        border-top-width: 2px;
        border-bottom-width: 2px;
        color: $primary;
        transition: all 250ms ease-in;
        cursor: pointer;
        &:hover {
            transform: scale(1.1);
            box-shadow: 0 0 $pagePadding $dark;
        }
        &:disabled {
            cursor: default;
        }
        &.current {
            background: $primary;
            color: $light;
        }
        &:first-of-type {
            border-top-left-radius: 0.5rem;
            border-bottom-left-radius: 0.5rem;
            border-left-width: 2px;
        }
        &:last-of-type {
            border-top-right-radius: 0.5rem;
            border-bottom-right-radius: 0.5rem;
            border-right-width: 2px;
        }
    }
}
</style>
