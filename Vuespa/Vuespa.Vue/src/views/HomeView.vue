<template>
    <div class="p-8">
        <h1>Home</h1>
        <p>This is your HomeView.vue</p>
        <p v-if="email">You are logged in as {{ email }}</p>
    </div>
</template>

<script setup lang="ts">
import { computed } from 'vue';
import { useUserStore } from '../stores/userStore';

const userStore = useUserStore();
const email = computed(() => userStore.getUserInfo()?.email);
</script>