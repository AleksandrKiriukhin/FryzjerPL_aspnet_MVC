using ASP.NET_project.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_project.Data
{
    public class DbInitializer
    {
        public static void Initialize(HairdresserContext context)
        {
            context.Database.EnsureCreated();

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Client ON");

            if (context.Clients.Any())
            {
                return; 
            }

            var clients = new Client[]
            {
                new Client{name="Agnieszka", surname="Nowicka", email="anowicka@gmail.com", phone="+48223190277"},
                new Client{name="Robert", surname="Złoty", email="rzlo@gmail.com", phone="+48190281561"},
                new Client{name="Andrzej", surname="Kamiński", email="akaminski@gmail.com", phone="+48900712911"}
            };
            foreach (Client c in clients)
            {
                context.Clients.Add(c);
            }
            context.SaveChanges();

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Client OFF");

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Service ON");

            var services = new Service[]
            {
                new Service{name="Strzyżenie męskie"},
                new Service{name="Strzyżenie damskie"}
            };
            foreach (Service s in services)
            {
                context.Services.Add(s);
            }
            context.SaveChanges();

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Service OFF");

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Worker ON");

            var workers = new Worker[]
            {
                new Worker{name="Alicja", surname="Biała"},
                new Worker{name="Piotr", surname="Nowak"},
                new Worker{name="Andrzej", surname="Zieliński"}
            };
            foreach (Worker w in workers)
            {
                context.Workers.Add(w);
            }
            context.SaveChanges();

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Worker OFF");

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Reservation ON");

            var reservations = new Reservation[]
            {
                new Reservation{id_service=1,id_client=1,id_worker=1,date=DateTime.Parse("2025-09-01"), status="gotowe", price=40},
                new Reservation{id_service=2,id_client=2,id_worker=2,date=DateTime.Parse("2025-09-01"), status="gotowe", price=45},
                new Reservation{id_service=2,id_client=3,id_worker=2,date=DateTime.Parse("2025-09-01"), status="gotowe", price=55},
            };
            foreach (Reservation r in reservations)
            {
                context.Reservations.Add(r);
            }
            context.SaveChanges();

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Reservation OFF");
        }
    }
}
