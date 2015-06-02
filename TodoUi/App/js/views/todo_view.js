define([
  'lodash',
  'jquery',
  'backbone',
  'text!templates/todo_view.html'
], function (_, $, Backbone, todoTemplate) {
    return Backbone.View.extend({
        tagName: 'li',
        className: 'list-group-item',

        events: {
            'mouseover': 'toggleButtonShow',
            'mouseout': 'toggleButtonShow',
            'click .checkbox': 'checkTodo',
            'click button': 'deleteTodo'
        },

        toggleButtonShow: function () {
            this.$('button').toggleClass('show');
        },

        checkTodo: function () {
            this.model.set({ 'completed': !this.model.get('completed') });
            this.model.save();
        },

        highlightStatus: function () {
            this.$('span').attr('class', this.model.get('completed') ? 'done' : '');
            this.$('.checkbox').prop('checked', !!this.model.get('completed'));
        },

        deleteTodo: function () {
            this.model.destroy();
            this.stopListening();
            this.remove();
        },

        render: function () {
            var compiledTemplate = ejs.render(todoTemplate, { model: this.model }, {});
            this.$el.empty();
            this.$el.append(compiledTemplate);
            this.highlightStatus();

            this.listenTo(this.model, 'change:completed', this.highlightStatus, this);
            return this;
        }
    });
});