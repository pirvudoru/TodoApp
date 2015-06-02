using System.Collections.Generic;
using System.Linq;
using TodoMvc.Models;

namespace TodoMvc.Data
{
    public class TodoRepository
    {
        public static List<Todo> Todos = new List<Todo>();
        public static int MaxId;

        public IEnumerable<Todo> GetAll()
        {
            return Todos;
        }

        public Todo Get(int id)
        {
            return Todos.FirstOrDefault(t => t.Id == id);
        }

        public Todo Save(Todo item)
        {
            if (item.Id == 0)
            {
                item.Id = ++MaxId;
            }

            int index = Todos.IndexOf(item);
            if (index != -1)
            {
                Todos[index] = item;
            }
            else
            {
                Todos.Add(item);
            }

            return item;
        }

        public void Delete()
        {
            Todos.Clear();
        }

        public void Delete(int id)
        {
            Todos.RemoveAll(t => t.Id == id);
        }
    }
}