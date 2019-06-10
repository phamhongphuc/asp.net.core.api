import { ActionTree, MutationTree } from 'vuex/types/index';
import {
    AccountResponse,
    IAccountCreateRequest,
    IAccountLoginRequest,
    IAccountLoginResponse,
} from '~/types/rest';
import { RootState } from '.';

export interface UserState {
    user?: AccountResponse;
}

export const state = (): UserState => ({
    user: undefined,
});

export const actions: ActionTree<UserState, RootState> = {
    async login({ commit }, payload: IAccountLoginRequest) {
        const data = await this.$axios.$post<IAccountLoginResponse>(
            '/account/login',
            payload,
        );
        this.$axios.setToken(data.token, 'Bearer');
        const user = await this.$axios.get<AccountResponse>('/account/me');
        commit('setUser', user);
        this.$router.push('/home');
    },

    async register(context, payload: IAccountCreateRequest) {
        await this.$axios.$post<IAccountCreateRequest>(
            '/account/register',
            payload,
        );
        this.$router.push('/login');
    },

    async logout() {
        this.$axios.setToken(false);
    },
};

export const mutations: MutationTree<UserState> = {
    setUser(state, user: AccountResponse) {
        state.user = user;
    },
};
