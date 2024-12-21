import axios from "axios";

type ApiResponse = {
    type: string;
    title: string;
    status: number;
    detail: string;
}

export type UserInfo = ApiResponse & {
    email: string;
};

export type AuthApi = {
    login(email: string, password: string): Promise<boolean>;
    logout(): Promise<boolean>;
    userInfo(): Promise<UserInfo>;
    forgotPassword(emailAddress: string): Promise<boolean>;
    resetPassword(email: string, password: string, resetCode: string): Promise<boolean>;
    createAccount(emailAddress: string, password: string): Promise<boolean>;
};

export const authApi: AuthApi = {
    async login(email, password) {
        try {
            await axios.post<ApiResponse>("/api/auth/login?useCookies=true", { email, password });
        } catch (err) {
            return false;
        }

        return true;
    },
    async logout() {
        return await axios.post("/api/auth/logout", {});
    },
    async userInfo() {
        const { data } = await axios.get<UserInfo>("/api/auth/manage/info")
        return data;
    },
    async forgotPassword(email) {
        try {
            await axios.post<ApiResponse>("/api/auth/forgotPassword", { email })
        } catch (err) {
            return false;
        };

        return true;
    },
    async resetPassword(email, password, resetCode) {
        try {
            await axios.post<ApiResponse>("/api/auth/resetPassword", { email, newPassword: password, resetCode });
        } catch (err) {
            return false;
        }

        return true;
    },
    async createAccount(email: string, password: string) {
        try {
            await axios.post<ApiResponse>("/api/auth/register", { email, password });
        } catch (err) {
            return false;
        }

        return true;
    }
}