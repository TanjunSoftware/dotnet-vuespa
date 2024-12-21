<template>
    <div>
        <button
            :disabled="disabled"
            class="hover:shadow-form w-full rounded-md bg-blue-400 transition hover:bg-blue-300 hover:scale-105 py-3 px-8 text-center text-base font-semibold text-white outline-none">
            {{ text }}
        </button>
    </div>
</template>

<script setup lang="ts">
defineProps<{
    text: string;
    disabled?: boolean;
}>();
</script>