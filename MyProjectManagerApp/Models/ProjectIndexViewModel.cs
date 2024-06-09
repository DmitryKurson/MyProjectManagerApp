using MyProjectManagerApp.Models;

namespace MvcApp.Models
{
    public class ProjectIndexViewModel
    {
        public IEnumerable<Project> projects { get; }
        public PageViewModel PageViewModel { get; }
        public FilterViewModel FilterViewModel { get; }
        public ProjectSortViewModel ProjectSortViewModel { get; }
        public ProjectIndexViewModel(IEnumerable<Project> projects, PageViewModel pageViewModel,FilterViewModel filterViewModel, ProjectSortViewModel ProjectSortViewModel)
        {
            this.projects = projects;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
            this.ProjectSortViewModel = ProjectSortViewModel;
        }
    }
}