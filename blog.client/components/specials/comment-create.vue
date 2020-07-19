<template>
    <b-card no-body class="shadow-sm border-0 row-like mb-3">
        <b-card-body>
            <div class="d-flex flex-row">
                <image-
                    class="rounded-circle mr-3"
                    :source="profile.picture"
                    :default="defaultImage"
                    height="30"
                    width="30"
                />
                <b-textarea
                    v-model="input.content"
                    class="flex-1"
                    placeholder="Nhập nội dung bài viết theo định dạng markdown ở đây..."
                    no-resize
                />
            </div>
            <div class="d-flex">
                <b-button class="mt-3 ml-auto" variant="main" @click="submit">
                    <icon- class="mr-1" i="plus" />
                    <span>Đăng</span>
                </b-button>
            </div>
        </b-card-body>
    </b-card>
</template>
<script lang="ts">
import { Component, Prop, namespace, Vue } from 'nuxt-property-decorator';
import {
    ICommentCreateRequest,
    PostIdTransfer,
    ICommentResponse,
    IAccountResponse,
} from '~/types/rest';
import { defaultImageUrl } from '~/modules/format-data';
import { AuthState } from '~/store/auth';

@Component
export default class extends Vue {
    @Prop({ required: true, type: Number })
    postId!: number;

    input: ICommentCreateRequest = {
        post: new PostIdTransfer({
            id: this.postId,
        }),
        content: '',
    };

    @(namespace('auth').State((state: AuthState) => state.profile))
    profile!: IAccountResponse;

    get defaultImage() {
        return defaultImageUrl(this.profile.name);
    }

    submit() {
        this.$tryCatch<ICommentResponse>({
            handle: () => this.$store.dispatch('comment/create', this.input),
            success: { message: 'Đăng bình luận mới thành công' },
            onSuccess: data => {
                this.$emit('reload-post', data);
                this.input.content = '';
            },
        });
    }
}
</script>
