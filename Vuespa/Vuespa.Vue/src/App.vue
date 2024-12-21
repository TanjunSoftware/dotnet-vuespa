<template>
    <div id="top-bar" class="flex place-items-center p-4 bg-slate-300 border-b-2 border-slate-400">
        <h1 id="logo">Vuespa</h1>
        <div id="divider" class="flex-grow"></div>
        <nav class="space-x-4">
            <router-link to="/">Home</router-link>
            <router-link to="/about">About</router-link>
            <template v-if="loggedIn">
                <LogoutLink />
            </template>
            <template v-else>
                <router-link to="/login">Login<IconLogin class="inline"/></router-link>
            </template>
        </nav>
    </div>
    <main>
        <RouterView />
    </main>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router';
import { useUserStore } from './stores/userStore';
import { computed } from 'vue';
import IconLogin from '~icons/line-md/login';
import LogoutLink from './components/LogoutLink.vue';

const userStore = useUserStore();
const loggedIn = computed(() => userStore.loggedIn);
</script>

<style>
body {
    font-family: "Open Sans", serif;
}

#logo {
    font-family: "Edu AU VIC WA NT Hand", cursive;
}

h1 {
    font-optical-sizing: auto;
    font-style: normal;
    font-size: 1.5rem;
}

a {
    color: rgb(30 64 175 / var(--tw-text-opacity, 1));
    text-decoration: underline;
}

a:hover {
    color: rgb(60 94 205 / var(--tw-text-opacity, 1));
}
</style>