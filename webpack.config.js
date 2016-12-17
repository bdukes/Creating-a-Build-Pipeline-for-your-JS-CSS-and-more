'use strict';

module.exports = {
    context: __dirname + '/Website/DesktopModules/MVC/Pipeline',
    entry: {
        'Views/Item/Index': [ './Views/Item/Index.js', ],
        'Views/Item/Edit': [ './Views/Item/Edit.js', ],
    },
    output: {
        path: __dirname + '/Website/DesktopModules/MVC/Pipeline',
        filename: '[name].bundle.js',
    },
    module: {
        rules: [ {
            test: /\.js$/,
            use: [ {
                loader: 'babel-loader',
                options: {
                    presets: [ [ 'latest', { "es2015": { "modules": false, }, }, ], ],
                },
            }, ],
        }, {
            test: /\.css$/,
            use: [ 'style-loader', 'css-loader', ],
        }, ],
    },
};