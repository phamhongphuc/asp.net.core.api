import { ActionTree, MutationTree } from 'vuex/types/index';
import { RootState } from '.';

export interface UserState {}

export const state = (): UserState => ({});

export const actions: ActionTree<UserState, RootState> = {};

export const mutations: MutationTree<UserState> = {};
