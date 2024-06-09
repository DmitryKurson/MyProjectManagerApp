namespace MyProjectManagerApp.Models
{
    public class TaskSortViewModel
    {
        public SortState IDSort { get; }
        public SortState NameSort { get; }
        public SortState DescriptionSort { get; }
        public SortState WorkerNameSort { get; }
        public SortState TimeSort { get; }
        public SortState Current { get; }

        public TaskSortViewModel(SortState sortOrder)
        {
            IDSort = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            DescriptionSort = sortOrder == SortState.DescriptionAsc ? SortState.DescriptionDesc : SortState.DescriptionAsc;
            WorkerNameSort = sortOrder == SortState.WorkerNameAsc ? SortState.WorkerNameDesc : SortState.WorkerNameAsc;
            TimeSort = sortOrder == SortState.TimeAsc ? SortState.TimeDesc : SortState.TimeAsc;
            Current = sortOrder;
        }
    }
}
