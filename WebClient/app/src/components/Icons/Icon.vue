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
    </svg>
</template>

<script lang="ts">
import { defineComponent, computed } from 'vue';

const component = defineComponent({
    props: {
        name: {
            type: String as () => 'flow' | 'list',
            required: true,
        },
    },
    setup(props) {
        const viewBox = computed(() => {
            if (props.name === 'flow') {
                return '0 0 41 32';
            } else if (props.name === 'list') {
                return '0 0 14 12';
            } else {
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
