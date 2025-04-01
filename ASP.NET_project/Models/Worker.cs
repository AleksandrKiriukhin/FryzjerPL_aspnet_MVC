namespace ASP.NET_project.Models
{
    public class Worker
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public ICollection<Reservation> reservations { get; set; } = new List<Reservation>();
    }
}
