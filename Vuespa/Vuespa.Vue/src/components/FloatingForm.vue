<template>
    <div class="relative z-10 flex flex-col justify-center items-center h-full pt-8">
        <div
            class="mx-auto w-full max-w-[550px] bg-slate-100 p-4 m-4 rounded-md drop-shadow-[0_1.2px_1.2px_rgba(0,0,0,0.8)]">
            <h1 class="pb-8">
                <slot name="header"></slot>
            </h1>
            <div v-if="errorMessage"
                class="text-red-500 text-center mb-8 p-4 bg-red-100 rounded-md border-red-200 border-2">
                {{ errorMessage }}
            </div>
            <div v-if="successMessage"
                class="text-green-500 text-center mb-8 p-4 bg-green-100 rounded-md border-green-200 border-2">
                {{ successMessage }}
            </div>
            <form onsubmit="return false;">
                <slot name="form"></slot>
            </form>
            <div v-if="$slots.footer" class="mt-5 text-center flex flex-col">
                <slot name="footer"></slot>
            </div>
        </div>
    </div>
</template> 

<script setup lang="ts">
defineProps<{
    errorMessage?: string | undefined,
    successMessage?: string | undefined
}>();
</script>