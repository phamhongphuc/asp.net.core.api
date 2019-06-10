<template>
    <b-navbar id="header" toggleable="md" type="light" class="shadow-sm" sticky>
        <b-navbar-nav class="flex-row flex-grow-1">
            <b-nav-item-icon- image="/favicon.png" />
            <b-nav-item
                class="font-pacifico font-size-bigger ml-md-2 mx-auto"
                to="/"
            >
                Blog
            </b-nav-item>
            <b-dropdown
                variant="link"
                size="md"
                no-caret
                right
                class="rounded"
                toggle-class="nav-item-icon p-0 border-0"
                menu-class="border-0 shadow rounded mt-3"
            >
                <template slot="button-content">
                    <icon- class="m-0" i="sliders" />
                </template>
                <b-dropdown-item-icon-
                    to="/profile"
                    text="Tài khoản"
                    icon="user"
                    @click="logout"
                />
                <b-dropdown-item-icon-
                    to="/settings"
                    text="Cài đặt"
                    icon="settings"
                    @click="logout"
                />
                <div class="hr line my-2" />
                <b-dropdown-item-icon-
                    text="Đăng xuất"
                    icon="power"
                    @click="logout"
                />
            </b-dropdown>
        </b-navbar-nav>
    </b-navbar>
</template>
<script lang="ts">
import { Vue, Component, namespace } from 'nuxt-property-decorator';
import { UserState } from '~/store/user';
import { AccountResponse } from '~/types/rest';

@Component
export default class extends Vue {
    @(namespace('user').State((state: UserState) => state.profile))
    profile!: AccountResponse;

    @(namespace('user').Action)
    logout;
}
</script>
<style lang="scss">
#header {
    .btn-link:hover {
        text-decoration: none;
    }

    .b-dropdown {
        &.show {
            background-color: rgba(black, 0.2);
        }
    }
}
</style>
