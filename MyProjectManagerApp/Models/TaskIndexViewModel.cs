using MvcApp.Models;

namespace MyProjectManagerApp.Models
{
    public class TaskIndexViewModel
    {
        public IEnumerable<Task> tasks { get; }
        public PageViewModel PageViewModel { get; }
        public FilterViewModel FilterViewModel { get; }
        public TaskSortViewModel TaskSortViewModel { get; }
        public TaskIndexViewModel(IEnumerable<Task> tasks, PageViewModel pageViewModel, FilterViewModel filterViewModel, TaskSortViewModel TasksortViewModel)
        {
            this.tasks = tasks;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
            TaskSortViewModel = TasksortViewModel;
        }
    }
}
