namespace ASP.NET_project.ViewModel
{
    public class WorkerListViewModel
    {
        public IQueryable<WorkerViewModel> Workers { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
    }
}
