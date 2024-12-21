<template>
    <FloatingForm :errorMessage="error" :successMessage="successMessage">
        <template #header>
            Forgot Password
        </template>
        <template #form>
            <TextInput @update:value="(v) => email = v" label="Email Address" id="email" placeholder="Email address" type="email" autofocus />
            <WideButton :disabled="disabled" text="Send Reset Email" @click="submitResetPassword" />
        </template>
    </FloatingForm>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import FloatingForm from '../../components/FloatingForm.vue';
import TextInput from '../../components/TextInput.vue';
import WideButton from '../../components/WideButton.vue';
import { authApi } from '../../api/auth';

const email = ref("");
const disabled = ref(false);

const error = ref<string>();
const successMessage = ref<string>();

async function submitResetPassword() {
    disabled.value = true;
    const success = await authApi.forgotPassword(email.value);
    if (success) {
        error.value = undefined;
        successMessage.value = "Reset email sent";
    } else {
        successMessage.value = undefined;
        error.value = "Failed to send reset email. Try again later.";
    }
    disabled.value = false;
}
</script>