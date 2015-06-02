using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoMvc.Data;
using TodoMvc.Models;

namespace TodoMvc.Controllers
{
    public class TodosController : ApiController
    {
        private readonly TodoRepository _repo;

        public TodosController()
        {
            _repo = new TodoRepository();
        }

        // GET: Todos
        public IEnumerable<Todo> Get()
        {
            var items = _repo.GetAll()
                .Select(t =>
            {
                t.Url = String.Format("{0}/{1}", Request.RequestUri.ToString(), t.Id.ToString());
                return t;
            });

            return items;
        }

        // GET: Todos/5
        public Todo Get(int id)
        {
            var t = _repo.Get(id);
            if (t != null)
            {
                t.Url = Request.RequestUri.ToString();
            }
            return t;
        }

        // POST: Todos
        public HttpResponseMessage Post(Todo item)
        {
            var t = _repo.Save(item);
            t.Url = String.Format("{0}/{1}", Request.RequestUri.ToString(), t.Id.ToString());

            var response = Request.CreateResponse(HttpStatusCode.OK, t);
            response.Headers.Location = new Uri(Request.RequestUri, "todos/" + t.Id);

            return response;
        }

        // PATCH: Todos/5
        public HttpResponseMessage Put(int id, Todo item)
        {
            item.Id = id;
            var t = _repo.Save(item);
            t.Url = Request.RequestUri.ToString();

            var response = Request.CreateResponse(HttpStatusCode.OK, t);
            response.Headers.Location = new Uri(Request.RequestUri, t.Id.ToString());

            return response;
        }

        // DELETE: Todos
        public void Delete()
        {
            _repo.Delete();
        }

        // DELETE: Todos/5
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
