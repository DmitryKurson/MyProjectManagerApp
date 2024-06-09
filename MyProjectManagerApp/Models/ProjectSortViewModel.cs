namespace MvcApp.Models
{
    public class ProjectSortViewModel
    {
        public SortState IDSort  { get; }
        public SortState NameSort { get; }
        public SortState DescriptionSort { get; } 
        public SortState CreatorNameSort { get; }
        public SortState Current { get; }   

        public ProjectSortViewModel(SortState sortOrder)
        {
            IDSort = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            DescriptionSort = sortOrder == SortState.DescriptionAsc ? SortState.DescriptionDesc : SortState.DescriptionAsc;
            CreatorNameSort = sortOrder == SortState.CreatorNameAsc ? SortState.CreatorNameDesc : SortState.CreatorNameAsc;
            Current = sortOrder;
        }
    }
}