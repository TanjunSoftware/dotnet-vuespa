import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';
import Icons from 'unplugin-icons/vite';

// https://vite.dev/config/
export default defineConfig({
    plugins: [
        vue(),
        Icons()
    ],
    server: {
        port: 4242,
        proxy: {
            '/api': {
                target: 'http://localhost:5120',
                changeOrigin: true,
                // rewrite: (path) => path.replace(/^\/api/, '')
            }
        }
    }
});
