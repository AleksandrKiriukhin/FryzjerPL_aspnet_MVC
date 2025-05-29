namespace ASP.NET_project.ViewModel
{
    public class ReservationViewModel
    {
        public int ID { get; set; }
        public int id_client { get; set; }
        public int id_worker { get; set; }
        public int id_service { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
        public double price { get; set; }

    }
}
