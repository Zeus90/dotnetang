// import { NodePolyfillPlugin } from "./node_modules/node-polyfill-webpack-plugin";
const NodePolyfillPlugin = require("node-polyfill-webpack-plugin");

plugins: [
    new NodePolyfillPlugin()
  ]