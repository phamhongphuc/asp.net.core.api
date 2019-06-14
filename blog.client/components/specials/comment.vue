<template>
    <b-card no-body class="comment shadow-sm border-0 row-like mb-3">
        <b-card-body>
            <div class="d-flex flex-row">
                <image-
                    class="rounded-circle mr-3"
                    :source="data.owner.picture"
                    :default="defaultImage"
                    height="30"
                    width="30"
                />
                <b-textarea
                    v-if="isEdit"
                    v-model="data.content"
                    class="flex-1"
                    placeholder="Nhập nội dung bài viết theo định dạng markdown ở đây..."
                    no-resize
                />
                <b-card-text v-else class="flex-1">
                    <div class="d-flex comment-header">
                        <h5 class="mr-auto">{{ data.owner.name }}</h5>
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
                                @click="removeComment"
                            />
                        </template>
                        <b-button-span-
                            v-if="canUpdate"
                            icon="edit"
                            @click="isEdit = true"
                        />
                        <span class="ml-2">
                            <i>{{ time }}</i>
                        </span>
                    </div>
                    <div
                        class="mt-2 comment-content"
                        v-html="compiledMarkdown"
                    />
                </b-card-text>
            </div>
            <div v-if="isEdit" class="d-flex">
                <b-button
                    class="mt-3 ml-auto"
                    variant="main"
                    @click="isEdit = false"
                >
                    <icon- class="mr-1" i="x" />
                    <span>Hủy</span>
                </b-button>
                <b-button
                    class="mt-3 ml-2"
                    variant="main"
                    @click="updateComment"
                >
                    <icon- class="mr-1" i="check" />
                    <span>Cập nhật</span>
                </b-button>
            </div>
        </b-card-body>
    </b-card>
</template>
<script lang="ts">
import { Component, Prop, Vue, namespace } from 'nuxt-property-decorator';
import { ICommentResponse, IAccountResponse, EnumAccess } from '~/types/rest';
import { timeAgo, defaultImageUrl } from '~/modules/format-data';
import marked from 'marked';
import { AuthState } from '~/store/auth';

@Component({
    name: 'comment-',
})
export default class extends Vue {
    @(namespace('auth').State((state: AuthState) => state.profile))
    profile!: IAccountResponse;

    @Prop({ type: Object })
    data!: ICommentResponse;

    @Prop({ default: -1, type: Number })
    postId!: number;

    isEdit: boolean = false;
    isRemoving: boolean = false;

    get time() {
        return timeAgo(this.data.created);
    }

    get defaultImage() {
        return defaultImageUrl(this.data.owner.name);
    }

    get compiledMarkdown() {
        return marked(this.data.content, { headerPrefix: '#' });
    }

    updateComment() {
        const { id, content } = this.data;
        this.$tryCatch({
            handle: () =>
                this.$store.dispatch('comment/update', { id, content }),
            success: { message: 'Cập nhật bình luận thành công' },
            onSuccess: data => {
                this.$emit('reload-post', data);
                this.isEdit = false;
            },
        });
    }

    removeComment() {
        this.$tryCatch({
            handle: () => this.$store.dispatch('comment/remove', this.data.id),
            success: { message: 'Đăng bình luận mới thành công' },
            onSuccess: data => this.$emit('reload-post', data),
        });
    }

    get canRemove() {
        const { profile } = this;
        const { access } = profile;
        const { owner } = this.data;

        const conditionOfAdmin = access === EnumAccess.Administrator;
        const conditionOfMod =
            access === EnumAccess.Moderator &&
            (profile.id === owner.id || owner.access === EnumAccess.NormalUser);
        const conditionOfNormal =
            access === EnumAccess.NormalUser && profile.id === owner.id;

        return conditionOfAdmin || conditionOfMod || conditionOfNormal;
    }

    get canUpdate() {
        const { profile } = this;
        const { access } = profile;
        const { owner } = this.data;
        return (
            [
                EnumAccess.Administrator,
                EnumAccess.Moderator,
                EnumAccess.NormalUser,
            ].includes(access) && owner.id === profile.id
        );
    }
}
</script>
<style lang="scss">
.card.comment {
    .comment-header {
        margin-top: -0.5rem;
        > h5 {
            margin-top: 0.5rem;
            margin-bottom: 0;
        }
        > span {
            line-height: 2rem;
        }
    }
    .comment-content {
        > :last-child {
            margin-bottom: 0;
        }
    }
}
</style>
