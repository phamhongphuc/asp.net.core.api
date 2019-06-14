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
                    <!-- <icon- class="m-0" i="sliders" /> -->
                    <div class="d-flex header-profile-button">
                        <div class="header-profile-button-text">
                            <div class="header-profile-button-text-name">
                                {{ profile.name }}
                            </div>
                            <div class="header-profile-button-text-position">
                                {{ profileAccess }}
                            </div>
                        </div>
                        <div class="icon ml-2">
                            <image-
                                class="m-1 rounded-circle"
                                :source="profile.picture"
                                :default="defaultImage"
                                height="32"
                                width="32"
                            />
                        </div>
                    </div>
                </template>
                <b-dropdown-item-icon-
                    to="/profile"
                    text="Tài khoản"
                    icon="user"
                    @click="logout"
                />
                <b-dropdown-item-icon-
                    v-if="canOpenSettings"
                    text="Quản trị"
                    to="/admin"
                    icon="settings"
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
import { AuthState } from '~/store/auth';
import { IAccountResponse, EnumAccess } from '~/types/rest';
import { enumAccessMap } from '~/modules/helpers/access';
import { defaultImageUrl } from '~/modules/format-data';

@Component({
    name: 'header-',
})
export default class extends Vue {
    @(namespace('auth').State((state: AuthState) => state.profile))
    profile!: IAccountResponse;

    @(namespace('auth').Action)
    logout;

    get defaultImage() {
        return defaultImageUrl(this.profile.name);
    }

    get canOpenSettings() {
        const { access } = this.profile;
        return [EnumAccess.Administrator, EnumAccess.Moderator].includes(
            access,
        );
    }

    get profileAccess() {
        return enumAccessMap[this.profile.access];
    }
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

.header-profile-button {
    > .header-profile-button-text {
        padding: 0.25rem 0 0.125rem 0.375rem;
        text-align: right;
        > .header-profile-button-text-name {
            font-weight: bold;
            font-size: 1rem;
            line-height: 1rem;
        }
        > .header-profile-button-text-position {
            margin-top: 0.25rem;
            font-size: 0.75rem;
            line-height: 0.75rem;
        }
    }
}
</style>
