using MvcApp.Models;

namespace MyProjectManagerApp.Models
{
    public class WorkerIndexViewModel
    {
        public IEnumerable<Worker> workers { get; }
        public PageViewModel PageViewModel { get; }
        public FilterViewModel FilterViewModel { get; }
        public WorkerSortViewModel WorkerSortViewModel { get; }
        public WorkerIndexViewModel(IEnumerable<Worker> workers, PageViewModel pageViewModel, FilterViewModel filterViewModel, WorkerSortViewModel WorkerSortViewModel)
        {
            this.workers = workers;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
            this.WorkerSortViewModel = WorkerSortViewModel;
        }
    }
}
