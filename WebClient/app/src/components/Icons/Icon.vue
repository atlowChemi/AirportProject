<template>
    <svg xmlns="http://www.w3.org/2000/svg" :viewBox="viewBox">
        <path
            v-if="name === 'flow'"
            d="M13.324 13.714h4.962v-9.143h9.533c0.941-2.663 3.481-4.571 6.467-4.571 3.787 0 6.857 3.070 6.857 6.857s-3.070 6.857-6.857 6.857c-2.986 0-5.526-1.908-6.467-4.571h-4.962v13.714h4.962c0.941-2.663 3.481-4.571 6.467-4.571 3.787 0 6.857 3.070 6.857 6.857s-3.070 6.857-6.857 6.857c-2.986 0-5.526-1.908-6.467-4.571h-9.533v-9.143h-4.962c-0.941 2.663-3.481 4.571-6.467 4.571-3.787 0-6.857-3.070-6.857-6.857s3.070-6.857 6.857-6.857c2.986 0 5.526 1.908 6.467 4.571zM6.857 18.286c1.262 0 2.286-1.023 2.286-2.286s-1.023-2.286-2.286-2.286c-1.262 0-2.286 1.023-2.286 2.286s1.023 2.286 2.286 2.286zM34.286 9.143c1.262 0 2.286-1.023 2.286-2.286s-1.023-2.286-2.286-2.286c-1.262 0-2.286 1.023-2.286 2.286s1.023 2.286 2.286 2.286zM34.286 27.429c1.262 0 2.286-1.023 2.286-2.286s-1.023-2.286-2.286-2.286c-1.262 0-2.286 1.023-2.286 2.286s1.023 2.286 2.286 2.286z"
        />
        <path
            v-else-if="name === 'list'"
            d="M27,24 L27,26 L13,26 L13,24 L27,24 Z M27,19 L27,21 L13,21 L13,19 L27,19 Z M27,14 L27,16 L13,16 L13,14 L27,14 Z"
        ></path>
        <path
            v-else-if="name === 'more'"
            d="M204,102c28.05,0,51-22.95,51-51S232.05,0,204,0s-51,22.95-51,51S175.95,102,204,102z M204,153c-28.05,0-51,22.95-51,51    s22.95,51,51,51s51-22.95,51-51S232.05,153,204,153z M204,306c-28.05,0-51,22.95-51,51s22.95,51,51,51s51-22.95,51-51    S232.05,306,204,306z"
        ></path>
        <path
            v-else-if="name === 'flight'"
            d="M21 16v-2l-8-5V3.5c0-.83-.67-1.5-1.5-1.5S10 2.67 10 3.5V9l-8 5v2l8-2.5V19l-2 1.5V22l3.5-1 3.5 1v-1.5L13 19v-5.5l8 2.5z"
        />
    </svg>
</template>

<script lang="ts">
import { defineComponent, computed } from 'vue';

const component = defineComponent({
    props: {
        name: {
            type: String as () => 'flow' | 'list' | 'more' | 'flight',
            required: true,
        },
    },
    setup(props) {
        const viewBox = computed(() => {
            switch (props.name) {
                case 'flow':
                    return '0 0 41 32';
                case 'list':
                    return '0 0 14 12';
                case 'more':
                    return '0 0 408 408';
                case 'flight':
                    return '0 0 24 24';
                default:
                    return '0 0 0 0';
            }
        });
        const pathTransform = computed(() => {
            if (props.name === 'list') {
                return 'translate(-100%, -120%)';
            } else {
                return 'unset';
            }
        });
        return { viewBox, pathTransform };
    },
});

export default component;
</script>

<style lang="scss" scoped vars="{ pathTransform }">
svg {
    height: 100%;
    path {
        transform: var(--pathTransform);
    }
}
</style>
