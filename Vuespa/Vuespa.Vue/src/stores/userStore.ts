import { defineStore } from "pinia";
import { authApi, UserInfo } from "../api/auth";

type UserState = {
    loggedIn: boolean;
    userInfo: UserInfo | null;
}

export const useUserStore = defineStore('user', {
    persist: true,
    state: (): UserState => ({
        loggedIn: false,
        userInfo: null,
    }),
    actions: {
        async login(email: string, password: string) : Promise<boolean> {
            const success = await authApi.login(email, password);
            if (success) {
                this.userInfo = await authApi.userInfo();
                this.loggedIn = true;
            }

            return success;
        },
        async logout(): Promise<void> {
            await authApi.logout();
            this.loggedIn = false;
            this.userInfo = null;
        },
        getUserInfo(): UserInfo | null {
            return this.userInfo;
        },
    },
});