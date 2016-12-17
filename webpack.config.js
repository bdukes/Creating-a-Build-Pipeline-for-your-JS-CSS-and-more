'use strict';

const ExtractTextPlugin = require("extract-text-webpack-plugin");
const extractCss = new ExtractTextPlugin({
    filename: '[name].css',
    allChunks: true,
});

module.exports = {
    context: __dirname + '/Website/DesktopModules/MVC/Pipeline',
    entry: {
        'Views/Item/Index': [ './Views/Item/Index.js', ],
        'Views/Item/Edit': [ './Views/Item/Edit.js', ],
        'Module': [ './Module.scss', ],
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
            test: /\.scss$/,
            loader: extractCss.extract([ 'css-loader', 'sass-loader', ]),
        }, ],
    },
    plugins: [
        extractCss,
    ],
};