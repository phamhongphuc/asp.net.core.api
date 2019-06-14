import { ActionTree, MutationTree } from 'vuex/types/index';
import {
    ICommentCreateRequest,
    ICommentResponse,
    ICommentUpdateRequest,
} from '~/types/rest';
import { RootState } from '.';

export interface PostState {}

export const state = (): PostState => ({});

export const actions: ActionTree<PostState, RootState> = {
    create(context, request: ICommentCreateRequest) {
        return this.$axios.$post<ICommentResponse>('/comment', request);
    },

    update(context, request: ICommentUpdateRequest) {
        return this.$axios.$put<ICommentResponse>('/comment', request);
    },

    remove(context, id: number) {
        return this.$axios.$delete(`/comment/${id}`);
    },
};

export const mutations: MutationTree<PostState> = {};
