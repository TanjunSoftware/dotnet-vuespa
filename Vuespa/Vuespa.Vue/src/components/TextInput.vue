<template>
    <div class="mb-5">
        <label :for="id" class="mb-3 block text-base font-medium">
            {{ label }}
        </label>
        <input v-model="input" :autofocus="autofocus" :type="type" :name="id" :id="id" :placeholder="placeholder"
            class="w-full rounded-md border border-[#e0e0e0] bg-white py-3 px-6 text-base font-medium text-[#6B7280] outline-none focus:border-[#6A64F1] focus:shadow-md" />
    </div>
</template>

<script setup lang="ts">
import { computed } from 'vue';

type Props = {
    autofocus?: boolean;
    id: string;
    label: string;
    placeholder: string;
    type: string;
    value?: string;
};

const props = withDefaults(defineProps<Props>(), {
    autofocus: false,
    value: "",
});

const emit = defineEmits({
  "update:value": (v: string) => typeof v === "string",
});

const input = computed({
  get: () => props.value,
  set: (v) => emit("update:value", v),
});
</script>