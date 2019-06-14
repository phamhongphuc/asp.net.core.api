<template>
    <b-col id="post-create">
        <block-flex->
            <b-button class="ml-auto" variant="white" @click="submit">
                <icon- class="mr-1" i="edit" />
                <span>Chỉnh sửa</span>
            </b-button>
        </block-flex->
        <div class="row-like">
            <b-input-
                v-model="input.title"
                placeholder="Tiêu đề của bài viết"
                icon="edit-2"
                class="mt-3"
            />
            <b-input-
                v-model="input.cover"
                icon="image"
                placeholder="Ảnh bìa"
                class="mt-3"
            />
            <div class="mt-3 d-flex markdown-editor">
                <div class="bg-white rounded flex-1 d-flex">
                    <b-textarea
                        id="textarea"
                        v-model="input.content"
                        placeholder="Nhập nội dung bài viết theo định dạng markdown ở đây..."
                        no-resize
                    />
                </div>
                <div class="bg-white rounded shadow-sm flex-1 ml-3">
                    <!-- eslint-disable-next-line vue/no-v-html -->
                    <div class="py-2 px-3" v-html="compiledMarkdown" />
                </div>
            </div>
        </div>
    </b-col>
</template>
<script lang="ts">
import marked from 'marked';
import { Component, Vue } from 'nuxt-property-decorator';
import { IPostResponse, IPostUpdateRequest } from '~/types/rest';
import axios from 'axios';

@Component
export default class extends Vue {
    input!: IPostUpdateRequest;

    get compiledMarkdown() {
        return marked(this.input.content, {
            headerPrefix: '#',
        });
    }

    async asyncData({ params, $axios }: { params: any; $axios: typeof axios }) {
        const { data } = await $axios.get<IPostResponse>(`/post/${params.id}`);
        const { id, title, content, cover } = data;
        return {
            input: { id, title, content, cover },
        };
    }

    submit() {
        this.$tryCatch({
            handle: () => this.$store.dispatch('post/update', this.input),
            success: { message: 'Đã cập nhật bài viết thành công' },
            onSuccess: () => this.$router.push(`/post/${this.input.id}`),
        });
    }
}
</script>
<style lang="scss">
.markdown-editor {
    height: calc(100vh - 18rem);
    word-break: break-word;
    > div {
        max-width: calc(50% - 8px);
    }
}
</style>
