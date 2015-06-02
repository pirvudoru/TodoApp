define([
  'backbone',
  'views/app_view',
  'collections/todos'
], function (Backbone, AppView, TodoCollection) {
    var Router = Backbone.Router.extend({
        routes: {
            "(?:params)": "index"
        },

        index: function () {
            var todos = new TodoCollection();

            todos.fetch()
                .then(function () {
                    var appView = new AppView({ collection: todos });
                    appView.render();
                });
        }
    },
      {
          initialize: function () {
              return new Router();
          }
      });

    return Router;
});