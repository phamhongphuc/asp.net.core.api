import { ActionTree, MutationTree } from 'vuex/types/index';
import {
    AccountResponse,
    IAccountCreateRequest,
    IAccountLoginRequest,
    IAccountLoginResponse,
} from '~/types/rest';
import Cookies from 'js-cookie';
import { RootState } from '.';

export interface UserState {
    profile?: AccountResponse;
}

export const state = (): UserState => ({
    profile: undefined,
});

export const actions: ActionTree<UserState, RootState> = {
    setToken(context, token: string) {
        Cookies.set('token', token);
        this.$axios.setToken(token, 'Bearer');
    },

    async login({ dispatch }, payload: IAccountLoginRequest) {
        const data = await this.$axios.$post<IAccountLoginResponse>(
            '/account/login',
            payload,
        );

        await dispatch('setToken', data.token);
        await dispatch('getProfile');
        this.$router.push('/');
    },

    async getProfile({ commit }) {
        const user = await this.$axios.get<AccountResponse>('/account/me');
        commit('setProfile', user);
    },

    async register(context, payload: IAccountCreateRequest) {
        await this.$axios.$post<IAccountCreateRequest>(
            '/account/register',
            payload,
        );
        this.$router.push('/login');
    },

    async serverGetUserProfile({ dispatch }, token?: string) {
        if (typeof token !== 'string') return false;

        try {
            dispatch('setToken', token);
            dispatch('getProfile');
        } catch (e) {
            return false;
        }
        return true;
    },

    async logout({ commit }) {
        commit('setProfile', undefined);
        Cookies.remove('token');
        this.$axios.setToken(false);
        this.$router.push('/login');
    },
};

export const mutations: MutationTree<UserState> = {
    setProfile(state, user: AccountResponse) {
        state.profile = user;
    },
};
