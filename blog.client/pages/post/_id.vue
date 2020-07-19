<template>
    <b-col id="post-detail">
        <b-card
            id="post-detail-content"
            no-body
            class="shadow-sm border-0 row-like mb-3"
        >
            <image-
                class="card-img-top"
                :source="post.cover"
                default="/break-image.jpg"
            />
            <b-card-body>
                <div class="d-flex post-detail-time-ago">
                    <span class="mr-auto pr-2">
                        <i>{{ timeAgo(post.created) }}</i>
                    </span>
                    <template v-if="canRemove">
                        <b-button-span-
                            v-if="!isRemoving"
                            icon="trash"
                            @click="isRemoving = true"
                        />
                        <b-button-span-
                            v-else
                            class="text-red"
                            icon="trash-2"
                            text="Ấn lần nữa để xóa"
                            @clickaway="isRemoving = false"
                            @click="removePost"
                        />
                    </template>
                    <b-button-span-
                        v-if="canUpdate"
                        icon="edit"
                        @click="$router.push(`/post/update/${post.id}`)"
                    />
                </div>
                <h1 class="mb-3">
                    {{ post.title }}
                </h1>
                <div class="d-flex mb-2">
                    <image-
                        class="rounded-circle mr-3"
                        :source="post.owner.picture"
                        :default="defaultImage"
                        height="30"
                        width="30"
                    />
                    <div>{{ post.owner.name }}</div>
                </div>
                <div class="line hr" />
                <no-ssr>
                    <b-card-text
                        class="post-detail-content"
                        v-html="compiledMarkdown"
                    />
                </no-ssr>
            </b-card-body>
        </b-card>
        <no-ssr>
            <comment-
                v-for="comment in post.comments"
                :key="comment.id"
                :data="comment"
                @reload-post="reloadPost"
            />
        </no-ssr>
        <comment-create-
            v-if="canCreateComment"
            :post-id="post.id"
            @reload-post="reloadPost"
        />
    </b-col>
</template>
<script lang="ts">
import { Component, mixins, namespace } from 'nuxt-property-decorator';
import { DataMixin } from '~/components/mixins';
import { EnumAccess, IPostResponse, IAccountResponse } from '~/types/rest';
import marked from 'marked';
import axios from 'axios';
import { timeAgo, defaultImageUrl } from '~/modules/format-data';
import { AuthState } from '~/store/auth';

@Component({
    name: 'post-detail-',
})
export default class extends mixins<{
    timeAgo: typeof timeAgo;
}>(DataMixin({ timeAgo })) {
    @(namespace('auth').State((state: AuthState) => state.profile))
    profile!: IAccountResponse;

    post!: IPostResponse;

    isRemoving: boolean = false;

    removePost() {
        this.$tryCatch({
            handle: () => this.$store.dispatch('post/remove', this.post.id),
            success: { message: 'Đã xóa bài viết' },
            onSuccess: () => this.$router.push('/'),
        });
    }

    get compiledMarkdown() {
        return marked(this.post.content, {
            headerPrefix: '#',
        });
    }

    async asyncData({ params, $axios }: { params: any; $axios: typeof axios }) {
        const result = await $axios.get<IPostResponse>(`/post/${params.id}`);
        return {
            post: result.data,
        };
    }

    async reloadPost() {
        const result = await this.$axios.get<IPostResponse>(
            `/post/${this.$route.params.id}`,
        );
        this.post = result.data;
    }

    get defaultImage() {
        return defaultImageUrl(this.post.owner.name);
    }

    get canCreateComment() {
        return [
            EnumAccess.Administrator,
            EnumAccess.Moderator,
            EnumAccess.NormalUser,
        ].includes(this.profile.access);
    }

    get canRemove() {
        const { profile } = this;
        const { access } = profile;
        const { owner } = this.post;
        return (
            access === EnumAccess.Administrator ||
            (access === EnumAccess.Moderator && profile.id === owner.id)
        );
    }

    get canUpdate() {
        const { profile } = this;
        const { access } = profile;
        const { owner } = this.post;
        return (
            [EnumAccess.Administrator, EnumAccess.Moderator].includes(access) &&
            owner.id === profile.id
        );
    }
}
</script>
<style lang="scss">
#post-detail {
    .card-body {
        > .line.hr {
            width: auto;
            margin: 1rem -20px;
        }
        > .post-detail-content {
            > *:last-child {
                margin-bottom: 0;
            }
        }
        > .post-detail-time-ago {
            line-height: 2rem;
        }
    }
}
</style>
