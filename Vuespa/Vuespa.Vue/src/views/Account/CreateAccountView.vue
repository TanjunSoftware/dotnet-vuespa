<template>
    <FloatingForm :errorMessage="error" :successMessage="success">
        <template #header>
            Create Account
        </template>
        <template #form>
            <TextInput @update:value="(v) => email = v" label="Email Address" id="email" placeholder="Email address"
                type="email" />
            <TextInput @update:value="(v) => password = v" :value=password label="Password" name="password"
                id="password" placeholder="Password" type="password" />
            <TextInput @update:value="(v) => confirmPassword = v" :value="confirmPassword" label="Confirm Password"
                id="confirmPassword" placeholder="Confirm Password" type="password" />
            <WideButton :disabled="disabled" text="Create Account" @click="submitCreateAccount" />
        </template>
        <template #footer>
            <router-link to="/login">Already have an account? Login</router-link>
        </template>
    </FloatingForm>
</template>

<script setup lang="ts">
import FloatingForm from '../../components/FloatingForm.vue';
import TextInput from '../../components/TextInput.vue';
import WideButton from '../../components/WideButton.vue';
import { authApi } from '../../api/auth';
import { ref, watch } from 'vue';

const email = ref("");
const password = ref("");
const confirmPassword = ref("");
const disabled = ref(false);
const error = ref<string>();
const success = ref<string>();

watch([password, confirmPassword], () => {
    if (password.value !== confirmPassword.value) {
        disabled.value = true;
    } else {
        disabled.value = false;
    }
});

async function submitCreateAccount() {
    disabled.value = true;
    const response = await authApi.createAccount(email.value, password.value);
    if (response) {
        error.value = undefined;
        success.value = "Account created. Check your email for an activation link.";
    } else {
        success.value = undefined;
        error.value = "Failed to create account.";
    }
    disabled.value = false;
}
</script>