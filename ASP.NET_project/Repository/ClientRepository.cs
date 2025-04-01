using ASP.NET_project.Data;
using ASP.NET_project.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_project.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly HairdresserContext _context;

        public ClientRepository()
        {
            var options = new DbContextOptionsBuilder<HairdresserContext>()
            .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FryzjerPL;Trusted_Connection=True;MultipleActiveResultSets=true") 
            .Options;

            _context = new HairdresserContext(options);
        }

        public ClientRepository(HairdresserContext context)
        {
            _context = context;
        }

        public IQueryable<Client> GetAll()
        {
            return _context.Clients;
        }
        public Client GetById(int ID)
        {
            return _context.Clients.Find(ID);
        }
        public void Insert(Client client)
        {
            _context.Clients.Add(client);
        }
        public void Update(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
        }
        public void Delete(int ID)
        {
            Client client = _context.Clients.Find(ID);
            if (client != null)
            {
                _context.Clients.Remove(client);
            }

        }

        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
