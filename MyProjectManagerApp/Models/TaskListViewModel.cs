namespace MyProjectManagerApp.Models
{
    public class TaskListViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? WorkerName { get; set; }
        public int? Time { get; set; }
        
        public IEnumerable<Task> tasks { get; set; } = new List<Task>();
    }
}
