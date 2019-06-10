<template>
    <b-form
        class="flex-fill d-flex flex-column register-form"
        autocomplete="new-password"
        @submit.prevent="submit"
    >
        <div class="top">
            <img
                :style="{ width: '80px' }"
                src="/favicon.png"
                class="d-block img-fluid m-4 mx-auto"
            />
            <h4 class="font-pacifico text-center mb-4 text-white">Đăng ký</h4>
        </div>
        <div class="register-form-content">
            <b-form-row>
                <b-col>
                    <b-input-
                        v-model="input.email"
                        name="username"
                        type="text"
                        placeholder="Địa chỉ email"
                        icon="user"
                        class="circle bg-white"
                    />
                    <b-input-
                        v-model="input.password"
                        name="password"
                        type="password"
                        autocomplete="new-password"
                        placeholder="Mật khẩu"
                        icon="lock"
                        class="circle bg-white"
                    />
                    <b-input-
                        v-model="newPassword"
                        name="password"
                        type="password"
                        autocomplete="new-password"
                        placeholder="Nhập lại mật khẩu"
                        icon="lock"
                        class="circle bg-white"
                    />
                </b-col>
                <b-col>
                    <b-input-
                        v-model="input.name"
                        name="username"
                        type="text"
                        placeholder="Tên hiển thị"
                        icon="user"
                        class="circle bg-white"
                    />
                    <b-select-
                        v-model="input.gender"
                        class="circle"
                        icon="droplet"
                        :options="genderOptions"
                    />
                </b-col>
            </b-form-row>
            <b-button variant="main" class="circle" block type="submit">
                Đăng ký
            </b-button>
        </div>
    </b-form>
</template>
<script lang="ts">
import { Component, namespace, mixins } from 'nuxt-property-decorator';
import { IAccountCreateRequest, EnumGender } from '~/types/rest';
import { tryCatch } from '~/modules/error-handling';
import { DataMixin } from '~/components/mixins/data';

@Component({
    name: 'register-',
})
export default class extends mixins<{ tryCatch: typeof tryCatch }>(
    DataMixin({ tryCatch }),
) {
    newPassword = '';

    input: IAccountCreateRequest = {
        email: '',
        name: '',
        password: '',
        picture: '',
        gender: EnumGender.Unknown,
    };

    genderOptions = [
        {
            value: EnumGender[EnumGender.Male],
            text: 'Nam',
        },
        {
            value: EnumGender[EnumGender.Female],
            text: 'Nữ',
        },
        {
            value: EnumGender[EnumGender.Unknown],
            text: 'Không rõ',
        },
    ];

    layout() {
        return 'center';
    }

    async submit() {
        this.tryCatch({
            handle: () => this.register(this.input),
            success: { message: 'Đăng ký thành công' },
            fail: { message: 'Đăng ký không thành công' },
        });
    }

    @(namespace('user').Action)
    register;
}
</script>
<style lang="scss">
.register-form {
    > .register-form-content {
        > *,
        .b-input,
        .b-select {
            margin-top: 10px;
        }
    }
}
</style>
