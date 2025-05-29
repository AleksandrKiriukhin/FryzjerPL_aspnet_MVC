namespace ASP.NET_project.ViewModel
{
    public class ReservationListViewModel
    {
        public IQueryable<ReservationViewModel> Reservations { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
    }
}
