requirejs.config({
    paths: {
        jquery: '../../Scripts/jquery-1.10.2',
        lodash: '../../Scripts/lodash',
        backbone: '../../Scripts/backbone',
        ejs: '../../Scripts/ejs',
        text: '../../Scripts/requirejs-text',
        bootstrap: '../../Scripts/bootstrap'
    },

    baseUrl: 'App/js',

    map: {
        '*': {
            underscore: 'lodash'
        }
    }
});

requirejs([
  'app',
  'ejs'
], function (App) {
    new App().initialize();
});
