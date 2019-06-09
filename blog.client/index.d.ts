import '@nuxtjs/axios';
import VueRouter from 'vue-router';

declare module 'vuex' {
    interface Store<S> {
        $router: VueRouter;
    }
}
