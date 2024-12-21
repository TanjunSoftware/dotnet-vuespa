import { createRouter, createWebHistory } from "vue-router";
import HomeView from "./views/HomeView.vue";
import AboutView from "./views/AboutView.vue";
import LoginView from "./views/Account/LoginView.vue";
import ForgotPasswordView from "./views/Account/ForgotPasswordView.vue";
import CreateAccountView from "./views/Account/CreateAccountView.vue";
import ResetPasswordView from "./views/Account/ResetPasswordView.vue";

const routes = [
    { path: "/", component: HomeView },
    { path: "/about", component: AboutView },
    { path: "/login", component: LoginView },
    { path: "/forgot-password", component: ForgotPasswordView },
    { path: "/reset-password", component: ResetPasswordView},
    { path: "/create-account", component: CreateAccountView },
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;