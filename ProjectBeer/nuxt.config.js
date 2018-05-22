module.exports = {
    render: {
        ssr: false
    },
    modules: [
        '@nuxtjs/axios'
    ],
    plugins: ['~/plugins/pagination.js'],
    css: [
        { src: 'assets/main.sass', lang: 'sass' },
        { src: 'font-awesome/scss/font-awesome.scss', lang: 'scss' }
    ],
    head: {
        meta: [
            { name: 'viewport', content: 'width=device-width, initial-scale=1' }
        ]
    }
};