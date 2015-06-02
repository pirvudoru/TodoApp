define([
  'lodash',
  'jquery',
  'backbone',
  'text!templates/new_todo_view.html',
  'models/todo'
], function (_, $, Backbone, newTodoTemplate, Todo) {
    return Backbone.View.extend({
        events: {
            'click input#submit': 'addTodo'
        },

        $title: function () {
            return this.$el.find('#title')
        },

        addTodo: function (e) {
            e.preventDefault();

            var val = this.$title().val();
            if (_.trim(val) == '') {
                return
            }

            var model = new Todo({ 'title': val });
            this.collection.add(model);
            model.save();
            this.$title().val('');
        },

        render: function () {
            var compiledTemplate = ejs.render(newTodoTemplate, {}, {});
            this.$el.empty();
            this.$el.append(compiledTemplate);
            return this;
        }
    });
});