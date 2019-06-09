import {
    AccountResponse,
    AccountLoginRequest,
    AccountLoginResponse,
} from '~/types/rest';
import { ActionTree, MutationTree } from 'vuex/types/index';
import { RootState } from '.';

export interface UserState {
    user?: AccountResponse;
}

export const state = (): UserState => ({
    user: undefined,
});

export const actions: ActionTree<UserState, RootState> = {
    async login({ commit }, payload: AccountLoginRequest) {
        const data = await this.$axios.$post<AccountLoginResponse>(
            '/account/login',
            payload,
        );
        this.$axios.setToken(data.token, 'Bearer');
        const user = await this.$axios.get<AccountResponse>('/account/me');
        commit('setUser', user);
        this.$router.push('/home');
    },
};

export const mutations: MutationTree<UserState> = {
    setUser(state, user: AccountResponse) {
        state.user = user;
    },
};
