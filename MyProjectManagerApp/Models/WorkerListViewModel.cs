namespace MyProjectManagerApp.Models
{
    public class WorkerListViewModel
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Position { get; set; }
        public int? salary { get; set; }

        public IEnumerable<Worker> workers { get; set; } = new List<Worker>();
    }
}
