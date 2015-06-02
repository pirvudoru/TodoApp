define([
  'lodash',
  'backbone',
  'models/todo'
], function (_, Backbone, Todo) {
  return Backbone.Collection.extend({
      model: Todo,

      url: function() {
          return 'http://localhost:55654/todos/';
      }
  });
});