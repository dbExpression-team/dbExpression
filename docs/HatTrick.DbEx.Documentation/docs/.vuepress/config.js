module.exports = {
    title: 'Hello World',
    description: 'Documentation...',
    themeConfig: {
        nav: [
            {
                text: 'Versions',
                items: [
                    { text: 'MSSQL 2012', link: '/mssql/2012/' },
                    { text: 'MSSQL 2014', link: '/mssql/2014/' }
                ]
            }
        ],
        sidebar: {
            '/guide/': [
                ''
            ],

            '/mssql/': [{
                title: "MSSQL",
                collapsable: false,
                children: [
                    '',      /* /bar/ */
                    'Appenders'
                ]
            }],

            // fallback
            '/': [
                '',        /* / */
                'about'    /* /about.html */
            ]
        }
    }
}