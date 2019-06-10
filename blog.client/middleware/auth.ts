import { Context } from '@nuxt/vue-app';
import cookie from 'cookie';
import { Store } from 'vuex';
import { RootState } from '~/store';

const publicRoutes = ['login', 'register'];

export default async function({
    req,
    store,
    redirect,
    route,
}: Context & { store: Store<RootState> }): Promise<void> {
    function checkAndRedirect(): void {
        if (!publicRoutes.includes(route.name || '')) redirect('/login');
    }

    if (process.server) {
        // Call first and one time user access to this application.
        const headers = req.headers;
        if (headers.cookie === undefined) return checkAndRedirect();

        const token = cookie.parse(headers.cookie)['token'];
        const isUserLoggedIn = await store.dispatch(
            'user/serverGetUserProfile',
            token,
        );
        if (!isUserLoggedIn) return checkAndRedirect();
        else if (route.name === 'login') redirect('/');
    } else {
        const profile = (store.state as RootState).user.profile;
        if (!profile) return checkAndRedirect();
    }
}
