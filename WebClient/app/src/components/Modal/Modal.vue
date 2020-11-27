<template>
    <div class="modal__wrapper">
        <div class="modal__wrapper-backdrop"></div>
        <div class="modal__wrapper-modal">
            <div class="modal__wrapper-modal__top">
                <div class="modal__wrapper-modal__top-title">
                    <slot name="header">
                        <p>{{ title }}</p>
                    </slot>
                </div>
                <div class="modal__wrapper-modal__top-close" @click="close">
                    &times;
                </div>
            </div>
            <div class="modal__wrapper-modal__content">
                <slot name="default">
                    <span>Nothing to show :(</span>
                </slot>
            </div>
            <div class="modal__wrapper-modal__actions">
                <slot name="actions" />
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

const component = defineComponent({
    props: {
        close: {
            type: Function,
            required: true,
        },
        title: {
            type: String,
        },
    },
});

export default component;
</script>

<style lang="scss" scoped>
.modal__wrapper {
    position: fixed;
    top: 0;
    left: 0;
    height: 100%;
    width: 100%;
    z-index: 5;
    &-backdrop {
        background: rgba($primary, 0.4);
        backdrop-filter: blur(0.25rem);
        height: 100%;
    }
    &-modal {
        position: fixed;
        top: 6rem;
        left: 50%;
        transform: translateX(-50%);
        min-width: 55%;
        background: $light;
        border-radius: $modalRadius;
        box-shadow: 0 0 1rem $modalRadius $shadowGray;
        &__top {
            display: flex;
            align-items: center;
            height: $modalSectionHeight;
            border-bottom: 1px solid $lightGray;
            padding-left: $modalPadding;
            &-title {
                flex: 1;
                text-align: left;
                text-transform: uppercase;
                font-size: 1.2rem;
                font-weight: bold;
                letter-spacing: 0.12rem;
                p {
                    margin: 0;
                }
            }
            &-close {
                font-size: 2.7rem;
                cursor: pointer;
                display: flex;
                align-items: center;
                justify-content: center;
                width: $modalSectionHeight;
                height: $modalSectionHeight;
                color: rgba($color: $primary, $alpha: 0.3);
                border-left: 1px solid $lightGray;
                transition: all 250ms;
                &:hover {
                    color: $primary;
                }
            }
        }
        &__content {
            padding: 0 $modalPadding;
            min-height: $modalSectionHeight;
        }
        &__actions {
            height: $modalSectionHeight;
        }
    }
}
</style>
