namespace ASP.NET_project.ViewModel
{
    public class ClientListViewModel
    {
        public IQueryable<ClientViewModel> Clients { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
    }
}
