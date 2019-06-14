import '@nuxtjs/axios';
import 'bootstrap-vue';
import VueRouter from 'vue-router';
import { $tryCatch } from '~/modules/error-handling';
import { RootState } from './store';

declare module 'vuex' {
    interface Store<S> {
        $router: VueRouter;
    }
}

declare module 'vue/types/vue' {
    interface Vue {
        $tryCatch: typeof $tryCatch;
        $store: Store<RootState>;
    }
}
