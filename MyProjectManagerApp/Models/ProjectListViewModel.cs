namespace MyProjectManagerApp.Models;
public class ProjectListViewModel
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? CreatorName { get; set; }

    public IEnumerable<Project> projects { get; set; } = new List<Project>();
}
