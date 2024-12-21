<template>
    <FloatingForm :errorMessage="error" :successMessage="success">
        <template #header>
            Reset Password
        </template>
        <template #form>
            <TextInput @update:value="(v) => email = v" label="Email" id="password" placeholder="Password" type="text" />
            <TextInput @update:value="(v) => password = v" :value="password" label="Password" id="password" placeholder="Password" type="password" />
            <TextInput @update:value="(v) => confirmPassword = v" :value="confirmPassword" label="Confirm Password" id="confirmPassword" placeholder="Confirm Password" type="password" />
            <WideButton :disabled="disabled" text="Reset Password" @click="submitResetPassword" />
        </template>
    </FloatingForm>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue';
import FloatingForm from '../../components/FloatingForm.vue';
import TextInput from '../../components/TextInput.vue';
import WideButton from '../../components/WideButton.vue';
import { authApi } from '../../api/auth';
import { useRoute } from 'vue-router';

const error = ref("");
const success = ref("");
const email = ref("");
const password = ref("");
const confirmPassword = ref("");
const disabled = ref(true);
const route = useRoute();
const resetCode = route.query.code as string;

watch([password, confirmPassword], () => {
    if (password.value !== confirmPassword.value) {
        disabled.value = true;
    } else {
        disabled.value = false;
    }
});

async function submitResetPassword() {
    disabled.value = true;
    const response = await authApi.resetPassword(email.value, password.value, resetCode);
    if (response) {
        success.value = "Password reset";
        error.value = "";
    } else {
        success.value = "";
        error.value = "Failed to reset password";
        disabled.value = false;
    }
}
</script>