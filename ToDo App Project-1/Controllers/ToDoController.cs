using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo_App_Project_1.Models;
using ToDo_App_Project_1.DbContexts;

namespace ToDo_App_Project_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDos()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDo(int id)
        {
            var todo = await _context.ToDoItems.FindAsync(id);
            return todo == null ? NotFound() : todo;
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItem>> CreateToDo(ToDoItem todo)
        {
            _context.ToDoItems.Add(todo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetToDo), new { id = todo.Id }, todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDo(int id, ToDoItem todo)
        {
            if (id != todo.Id) return BadRequest();

            _context.Entry(todo).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoExists(id)) return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            var todo = await _context.ToDoItems.FindAsync(id);
            if (todo == null) return NotFound();

            _context.ToDoItems.Remove(todo);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool ToDoExists(int id)
        {
            return _context.ToDoItems.Any(e => e.Id == id);
        }
    }
}
