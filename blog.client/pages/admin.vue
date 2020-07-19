<template>
    <b-col id="index">
        <h4 class="row-like">
            Danh sách tài khoản
        </h4>
        <div class="row-like">
            <b-table
                class="shadow-sm bg-white rounded table-style"
                :fields="[
                    {
                        key: 'id',
                        label: '#',
                    },
                    {
                        key: 'name',
                        label: 'Tên',
                    },
                    {
                        key: 'email',
                        label: 'Email',
                    },
                    {
                        key: 'access',
                        label: 'Quyền',
                    },
                    {
                        key: 'action',
                        label: 'Hành động',
                    },
                ]"
                :items="data"
            >
                <template v-slot:access="{ value }">
                    {{ enumAccessMap[value] }}
                </template>
                <template v-slot:action="{ item }">
                    <div class="d-flex m-n1">
                        <b-button-span-
                            v-b-tooltip.hover
                            icon="key"
                            title="Thay đổi quyền"
                            text="Thay đổi quyền"
                            @click="openModal(item, 'change-access')"
                        />
                    </div>
                </template>
            </b-table>
        </div>
        <b-modal id="change-access" title="Thay đổi quyền" @ok="changeAccess">
            <template v-if="selectedAccount">
                <b-select
                    v-model="selectedAccount.access"
                    :options="AccessOptions"
                />
            </template>
            <template v-slot:modal-footer="{ ok, cancel }">
                <b-button variant="light" @click="cancel">
                    <icon- class="mr-1" i="x" />
                    <span>Hủy</span>
                </b-button>
                <b-button variant="main" @click="ok">
                    <icon- class="mr-1" i="check" />
                    <span>Cập nhật</span>
                </b-button>
            </template>
        </b-modal>
    </b-col>
</template>
<script lang="ts">
import axios from 'axios';
import { Component, mixins } from 'nuxt-property-decorator';
import {
    IAccountSimpleResponse,
    IAccountUpdateAccessRequest,
    AccountIdTransfer,
} from '~/types/rest';
import { DataMixin } from '~/components/mixins';
import { AccessOptions, enumAccessMap } from '~/modules/helpers/access';

@Component({
    name: 'admin-',
})
export default class extends mixins<{
    AccessOptions: typeof AccessOptions;
    enumAccessMap: typeof enumAccessMap;
}>(DataMixin({ AccessOptions, enumAccessMap })) {
    data!: IAccountSimpleResponse[];

    selectedAccount: IAccountSimpleResponse | null = null;

    async asyncData({ $axios }: { $axios: typeof axios }) {
        const { data } = await $axios.get<IAccountSimpleResponse[]>('/account');
        return { data };
    }

    async reloadAccount() {
        const { data } = await this.$axios.get<IAccountSimpleResponse[]>(
            '/account',
        );
        this.data = data;
    }

    openModal(item: IAccountSimpleResponse, name: string) {
        this.selectedAccount = { ...item };
        this.$bvModal.show(name);
    }

    changeAccess() {
        const account = this.selectedAccount;
        if (!account) return;
        const request: IAccountUpdateAccessRequest = {
            account: new AccountIdTransfer({ id: account.id }),
            access: account.access,
        };
        this.$tryCatch({
            handle: () => this.$axios.$patch('/account/updateAccess', request),
            success: { message: 'Cập nhật quyền thành công' },
            onSuccess: () => this.reloadAccount(),
        });
    }
}
</script>
