
using Microsoft.EntityFrameworkCore;
using ToDo_App_Project_1.Models;

namespace ToDo_App_Project_1.DbContexts
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }
    }
}
