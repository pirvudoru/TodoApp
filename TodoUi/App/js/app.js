define([
  'backbone',
  'router'
], function (Backbone, Router) {
  return function () {
    this.initialize = function () {
      Router.initialize();
      Backbone.history.start();
    }
  };
});
