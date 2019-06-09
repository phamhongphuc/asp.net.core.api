import pkg from './package';

export default {
    mode: 'universal',
    head: {
        title: pkg.name,
        meta: [
            { charset: 'utf-8' },
            {
                name: 'viewport',
                content: 'width=device-width, initial-scale=1',
            },
            {
                hid: 'description',
                name: 'description',
                content: pkg.description,
            },
        ],
        link: [
            { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' },
            {
                rel: 'stylesheet',
                href: 'https://fonts.googleapis.com/css?family=Pacifico',
            },
        ],
    },
    server: {
        port: process.env.PORT || 8080,
    },
    css: [{ src: '~/assets/scss/main.scss', lang: 'scss' }],
    loading: { color: '#fff' },
    modules: [
        '@nuxtjs/axios',
        '@nuxtjs/style-resources',
        ['bootstrap-vue/nuxt', { css: false }],
    ],
    axios: {
        baseURL: 'http://localhost:5000/api/',
    },
    styleResources: {
        scss: [
            'assets/scss/before/_before.scss',
            'bootstrap/scss/_functions.scss',
            'bootstrap/scss/_variables.scss',
            'bootstrap/scss/_mixins.scss',
            'assets/scss/after/_after.scss',
        ],
    },
    plugins: [{ src: '~/plugins/component' }],
    build: {
        extend(config, { isDev, isClient }) {
            if (isDev && isClient) {
                config.module.rules.push({
                    enforce: 'pre',
                    test: /\.(ts|js|vue)$/,
                    loader: 'eslint-loader',
                    exclude: /(node_modules)/,
                });
            }
        },
        postcss: {
            plugins: {},
            preset: {
                autoprefixer: {},
            },
        },
    },
};
