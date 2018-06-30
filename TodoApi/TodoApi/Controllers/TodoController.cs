using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext ctx;

        public TodoController(TodoContext context)
        {
            ctx = context;

            if (ctx.TodoItems.Count() == 0)
            {
                ctx.TodoItems.Add(new TodoItem { Name = "Research MS2 database" });
                ctx.TodoItems.Add(new TodoItem { Name = "Connect to T8 azure dev db" });
                ctx.SaveChanges();
            }
        }   

        // GET /todo
        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll()
        {
            return ctx.TodoItems.ToList();
        }

        // GET /todo/id
        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<TodoItem> Get(long id)
        {
            var item = ctx.TodoItems.Find(id);
            if (item == null) {
                return NotFound();
            }
            return item;
        }

        // POST api/todo
        [HttpPost]
        public IActionResult Create(TodoItem item)
        {
            ctx.TodoItems.Add(item);
            ctx.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        // PUT api/todo/id
        [HttpPut("{id}")]
        public IActionResult Update(long id, TodoItem item)
        {
            var it = ctx.TodoItems.Find(id);
            if (it == null)
            {
                return NotFound();
            }

            it.Name = item.Name;
            it.IsComplete = item.IsComplete;

            ctx.TodoItems.Update(it);
            ctx.SaveChanges();
            return NoContent();
        }

        // DELETE api/todo/id
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var it = ctx.TodoItems.Find(id);
            if (it == null)
            {
                return NotFound();
            }

            ctx.TodoItems.Remove(it);
            ctx.SaveChanges();
            return NoContent();
        }
    }
}
