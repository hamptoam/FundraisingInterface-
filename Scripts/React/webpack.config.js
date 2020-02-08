
const webpack = require("webpack");
const path = require("path");


module.exports = {
    entry: {
        index: "./src/index.js"
    },
    output: {
        filename: "[name].bundle.js",
        path: path.resolve(__dirname, "dist")
    },
    module: {
        rules: [
            {
                test: /\.js$/,
                //exclude: /(node_modules|bower_components)/,
                use: {
                    loader: "babel-loader",
                    options: {
                        //presets: ["babel-preset-env", "babel-preset-react"],
                        includePaths: ["./node_modules"]
                    }
                }
            }
        ]
    }
}
