import { ActionTree, MutationTree } from 'vuex/types/index';
import { IPostCreateRequest, IPostUpdateRequest } from '~/types/rest';
import { RootState } from '.';

export interface PostState {}

export const state = (): PostState => ({});

export const actions: ActionTree<PostState, RootState> = {
    create(context, request: IPostCreateRequest) {
        return this.$axios.$post<IPostCreateRequest>('/post', request);
    },

    update(context, request: IPostUpdateRequest) {
        return this.$axios.$put('/post', request);
    },

    remove(context, id: number) {
        return this.$axios.$delete(`/post/${id}`);
    },
};

export const mutations: MutationTree<PostState> = {};
