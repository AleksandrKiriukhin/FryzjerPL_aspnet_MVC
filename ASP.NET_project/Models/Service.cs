namespace ASP.NET_project.Models
{
    public class Service
    {
        public int ID { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public ICollection<Reservation> reservations { get; set; } = new List<Reservation>();
    }
}
