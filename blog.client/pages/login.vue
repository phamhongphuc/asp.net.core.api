<template>
    <b-form
        class="flex-fill d-flex flex-column login-form"
        @submit.prevent="submit"
    >
        <img
            :style="{ width: '120px' }"
            src="/favicon.png"
            class="d-block img-fluid m-5 mx-auto"
        />
        <h4 class="font-pacifico text-center mb-5 text-white">Đăng nhập</h4>
        <b-input-
            v-model="input.email"
            name="username"
            type="text"
            placeholder="Tên đăng nhập"
            icon="user"
            class="circle bg-white"
        />
        <b-input-
            v-model="input.password"
            name="password"
            type="password"
            placeholder="Mật khẩu"
            icon="lock"
            class="my-2 circle bg-white"
        />
        <b-button variant="main" type="submit" class="circle">
            Đăng nhập
        </b-button>
        <b-button
            variant="main"
            class="circle my-2"
            @click="$router.push('/register')"
        >
            Đăng ký
        </b-button>
    </b-form>
</template>
<script lang="ts">
import { Component, namespace, Vue } from 'nuxt-property-decorator';
import { IAccountLoginRequest } from '~/types/rest';

@Component({
    name: 'login-',
})
export default class extends Vue {
    layout() {
        return 'center';
    }

    input: IAccountLoginRequest = {
        email: '',
        password: '',
    };

    @(namespace('auth').Action)
    login;

    submit() {
        this.$tryCatch({
            handle: () => this.login(this.input),
            success: { message: 'Đăng nhập thành công' },
        });
    }
}
</script>
