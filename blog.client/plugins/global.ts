import { NuxtAppOptions } from '@nuxt/vue-app';
import { Vue } from 'nuxt-property-decorator';
import { Store } from 'vuex';
import { $tryCatch } from '~/modules/error-handling';
import { RootState } from '~/store';

Vue.mixin({ methods: { $tryCatch } });

export default function({
    app,
    store,
}: {
    app: NuxtAppOptions;
    store: Store<RootState>;
}): void {
    if (!app.mixins) app.mixins = [];
    app.mixins.push({
        async mounted(): Promise<void> {
            store.dispatch('auth/setToken', store.state.auth.token);
        },
    });
}
