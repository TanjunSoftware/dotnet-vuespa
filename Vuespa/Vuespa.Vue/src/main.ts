import { createApp } from 'vue';
import './style.css';
import App from './App.vue';
import router from './router';
import { createPinia } from 'pinia';
import piniaPluginPersistedstate from 'pinia-plugin-persistedstate';
import axios from 'axios';

const pinia = createPinia();
pinia.use(piniaPluginPersistedstate);
axios.defaults.withCredentials = true;

createApp(App)
    .use(pinia)
    .use(router)
    .mount('#app');
