import '@nuxtjs/axios';
import VueRouter from 'vue-router';
import 'bootstrap-vue';

declare module 'vuex' {
    interface Store<S> {
        $router: VueRouter;
    }
}
