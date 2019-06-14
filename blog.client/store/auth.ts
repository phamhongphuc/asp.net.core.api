import { ActionTree, MutationTree } from 'vuex/types/index';
import {
    AccountResponse,
    IAccountCreateRequest,
    IAccountLoginRequest,
    IAccountLoginResponse,
} from '~/types/rest';
import Cookies from 'js-cookie';
import { RootState } from '.';

export interface AuthState {
    profile?: AccountResponse;
    token: string | false;
}

export const state = (): AuthState => ({ token: false });

export const mutations: MutationTree<AuthState> = {
    setProfile(state, user: AccountResponse) {
        state.profile = user;
    },

    setToken(state, token: string) {
        state.token = token;
    },
};

export const actions: ActionTree<AuthState, RootState> = {
    setToken({ commit }, token: string) {
        Cookies.set('token', token);
        this.$axios.setToken(token, 'Bearer');
        commit('setToken', token);
    },

    async getProfile({ commit }) {
        const user = await this.$axios.get<AccountResponse>('/account/me');
        commit('setProfile', user.data);
    },

    async serverGetUserProfile({ dispatch }, token?: string) {
        if (typeof token !== 'string') return false;

        try {
            dispatch('setToken', token); // Server only
            await dispatch('getProfile');
        } catch (e) {
            return false;
        }
        return true;
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

    async register(context, payload: IAccountCreateRequest) {
        await this.$axios.$post<IAccountCreateRequest>(
            '/account/register',
            payload,
        );
        this.$router.push('/login');
    },

    async logout({ commit }) {
        commit('setProfile', undefined);
        Cookies.remove('token');
        this.$axios.setToken(false);
        this.$router.push('/login');
    },
};
