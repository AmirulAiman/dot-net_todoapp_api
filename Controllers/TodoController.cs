﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoapp_api.Models;

namespace todoapp_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _todoContext;

        public TodoController(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            if(_todoContext.Todos == null)
            {
                return NotFound();
            }
            return await _todoContext.Todos.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(int id)
        {
            if (_todoContext.Todos == null)
            {
                return NotFound();
            }
            var todo = await _todoContext.Todos.FindAsync(id);
            if(todo == null)
            {
                return NotFound();
            }
            return todo;
        }

        /**
         * Create new todo and return new created todo
         * **/
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Todo>>> CreateTodo(Todo todo)
        {
            _todoContext.Todos.Add(todo);
            await _todoContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodo), new { id = todo.id}, todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, Todo todo)
        {
            if(id != todo.id)
            {
                return BadRequest();
            }
            _todoContext.Entry(todo).State = EntityState.Modified;

            try
            {
                await _todoContext.SaveChangesAsync();
            } catch(DbUpdateConcurrencyException ex) {
                if(!TaskExist(id))
                {
                    return NotFound();
                } else
                {
                    throw;
                }
            }
            return Ok();
        }

        private bool TaskExist(int id) 
        {
            return (_todoContext.Todos?.Any(x => x.id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            if(_todoContext.Todos == null)
            {
                return NotFound();
            }

            var todo = await _todoContext.Todos.FindAsync(id);
            if(todo == null)
            {
                return NotFound();
            }
            _todoContext.Todos.Remove(todo);
            await _todoContext.SaveChangesAsync();
            
            return Ok();
        }
    }
}
