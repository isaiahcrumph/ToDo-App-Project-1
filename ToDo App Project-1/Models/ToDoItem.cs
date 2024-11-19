namespace ToDo_App_Project_1.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public required string ToDoTitle { get; set; }
        public required string ToDoText { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public bool IsCompleted { get; set; } = false;

    }
}
