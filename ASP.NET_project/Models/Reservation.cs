namespace ASP.NET_project.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public int id_client { get; set; }
        public int id_worker { get; set; }
        public int id_service { get; set; }
        public DateTime date {  get; set; }
        public string status { get; set; }
        public double price { get; set; }

        public ICollection<Client> clients { get; set; } = new List<Client>();
        public ICollection<Service> services { get; set; } = new List<Service>();
        public ICollection<Worker> workers { get; set; } = new List<Worker>();
        

    }
}
