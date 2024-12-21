<template>
    <FloatingForm :errorMessage="error">
        <template #header>
            Login
        </template>
        <template #form>
            <TextInput @update:value="(v) => email = v" label="Email" id="email" placeholder="Email Address" type="text"
                autofocus />
            <TextInput @update:value="(v) => password = v" :value=password label="Password" name="password" id="password" placeholder="Password" type="password" />
            <WideButton :disabled="disabled" text="Sign In" @click="submitLogin" />
        </template>
        <template #footer>
            <router-link to="/forgot-password">Forgot Password?</router-link>
            <router-link to="/create-account">Create an Account</router-link>
        </template>
    </FloatingForm>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import FloatingForm from '../../components/FloatingForm.vue';
import TextInput from '../../components/TextInput.vue';
import WideButton from '../../components/WideButton.vue';
import { useUserStore } from '../../stores/userStore';
import router from '../../router';

const userStore = useUserStore();

const email = ref("");
const password = ref("");
const disabled = ref(false);
const error = ref<string>();

async function submitLogin() {
    disabled.value = true;
    const success = await userStore.login(email.value, password.value);
    if (success) {
        error.value = undefined;
        router.push("/");
    } else {
        error.value = "Invalid email or password";
    }
    disabled.value = false;
}
</script>