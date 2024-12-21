<template>
    <template v-if="loggedIn">
        <a class="cursor-pointer" v-on:click="logout">Logout<IconLogout class="inline"/></a>
    </template>
</template>

<script setup lang="ts">
import { computed } from 'vue';
import IconLogout from '~icons/line-md/logout';
import { useUserStore } from '../stores/userStore';

const userStore = useUserStore();
const loggedIn = computed(() => userStore.loggedIn);

async function logout() {
    await userStore.logout();
}
</script>