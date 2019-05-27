<template>
    <b-form
        class="flex-fill d-flex flex-column login-form"
        @submit.prevent="login({ id, password })"
    >
        <img
            :style="{ width: '120px' }"
            src="/favicon.png"
            class="d-block img-fluid m-5 mx-auto"
        />
        <h4 class="font-pacifico text-center mb-5 text-white">Đăng nhập</h4>
        <b-input-
            v-model="id"
            name="username"
            type="text"
            placeholder="Tên đăng nhập"
            icon="user"
            class="circle"
        />
        <b-input-
            v-model="password"
            name="password"
            type="password"
            placeholder="Mật khẩu"
            icon="lock"
            class="my-2 circle"
        />
        <b-button variant="main" type="submit" class="circle">
            Đăng nhập
        </b-button>
        <b-button variant="main" type="submit" class="circle my-2">
            Đăng ký
        </b-button>
    </b-form>
</template>
<script lang="ts">
import { Vue, Component } from 'nuxt-property-decorator';
@Component
export default class extends Vue {
    id = '';
    password = '';

    layout() {
        return 'center';
    }
}
</script>
