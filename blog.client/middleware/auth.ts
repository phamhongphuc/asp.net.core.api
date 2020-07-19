import { Context } from '@nuxt/vue-app';
import cookie from 'cookie';
import { Store } from 'vuex';
import { RootState } from '~/store';

const anonymousOnlyRoutes = ['login', 'register'];

export default async function({
    req,
    store,
    redirect,
    route,
    app: { $axios },
}: { store: Store<RootState> } & Context): Promise<void> {
    function checkAndRedirect(): void {
        if (!anonymousOnlyRoutes.includes(route.name || '')) redirect('/login');
    }

    if (process.server) {
        // Call first and one time user access to this application.
        const headers = req.headers;
        if (headers.cookie === undefined) return checkAndRedirect();

        const token = cookie.parse(headers.cookie)['token'];
        const isUserLoggedIn = await store.dispatch(
            'auth/serverGetUserProfile',
            token,
        );
        $axios.setToken(token, 'Bearer');
        if (!isUserLoggedIn) return checkAndRedirect();
        else if (anonymousOnlyRoutes.includes(route.name || '')) redirect('/');
    } else {
        const profile = (store.state as RootState).auth.profile;
        if (!profile) return checkAndRedirect();
        else {
            $axios.setToken(
                (store as Store<RootState>).state.auth.token,
                'Bearer',
            );
        }
    }
}
