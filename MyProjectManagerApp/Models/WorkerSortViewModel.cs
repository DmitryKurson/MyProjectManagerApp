namespace MyProjectManagerApp.Models
{
    public class WorkerSortViewModel
    {
        public SortState IDSort { get; }
        public SortState NameSort { get; }
        public SortState SurnameSort { get; }
        public SortState PositionSort { get; }
        public SortState SalarySort { get; }
        public SortState Current { get; }

        public WorkerSortViewModel(SortState sortOrder)
        {
            IDSort = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            SurnameSort = sortOrder == SortState.SurnameAsc ? SortState.SurnameDesc : SortState.SurnameAsc;
            PositionSort = sortOrder == SortState.PositionAsc ? SortState.PositionDesc : SortState.PositionAsc;
            SalarySort = sortOrder == SortState.SalaryAsc ? SortState.SalaryDesc : SortState.SalaryAsc;
            Current = sortOrder;
        }
    }

}
