<template>
    <b-col id="index">
        <block-flex- v-if="canCreate" class="mb-3">
            <b-button variant="white" @click="$router.push('/post/create')">
                <icon- class="mr-1" i="edit-2" />
                <span>Đăng</span>
            </b-button>
        </block-flex->
        <b-card-group columns class="row-like">
            <b-card
                v-for="post in data"
                :key="post.id"
                :title="post.title"
                class="shadow-sm border-0"
                no-body
                @click="$router.push(`/post/${post.id}`)"
            >
                <image-
                    class="card-img-top"
                    :source="post.cover"
                    default="/break-image.jpg"
                />
                <b-card-body>
                    <b-card-title>
                        {{ post.title }}
                    </b-card-title>
                    <b-card-text>
                        {{ post.content }}
                    </b-card-text>
                    <b-card-text class="small text-muted">
                        {{ timeAgo(post.created) }}
                    </b-card-text>
                </b-card-body>
            </b-card>
        </b-card-group>
    </b-col>
</template>
<script lang="ts">
import moment from 'moment';
import { Component, mixins, namespace } from 'nuxt-property-decorator';
import { DataMixin } from '~/components/mixins';
import { IPostResponse, IAccountResponse, EnumAccess } from '~/types/rest';
import { timeAgo } from '~/modules/format-data';
import axios from 'axios';
import { AuthState } from '~/store/auth';

@Component
export default class extends mixins<{
    moment: typeof moment;
    timeAgo: typeof timeAgo;
}>(DataMixin({ moment, timeAgo })) {
    @(namespace('auth').State((state: AuthState) => state.profile))
    profile!: IAccountResponse;

    data: IPostResponse[] = [];

    async asyncData({ $axios }: { $axios: typeof axios }) {
        const { data } = await $axios.get<IPostResponse[]>('/post');
        return { data };
    }

    get canCreate() {
        const { profile } = this;
        const { access } = profile;
        return [EnumAccess.Moderator, EnumAccess.Administrator].includes(
            access,
        );
    }
}
</script>
<style lang="scss">
#index {
    > .card-columns {
        column-count: 1;
        @include media-breakpoint-up(md) {
            column-count: 2;
        }
        @include media-breakpoint-up(lg) {
            column-count: 3;
        }

        > .card {
            cursor: pointer;
            transition: all 0.2s;
            &:hover {
                background-color: rgba($black, 0.0125);
            }
            &:active {
                box-shadow: 0 0 0.125rem rgba($black, 0.125) !important;
            }
        }
    }
}
</style>
