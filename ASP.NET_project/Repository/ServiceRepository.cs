using ASP.NET_project.Data;
using ASP.NET_project.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_project.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly HairdresserContext _context;

        public ServiceRepository()
        {
            var options = new DbContextOptionsBuilder<HairdresserContext>()
            .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FryzjerPL;Trusted_Connection=True;MultipleActiveResultSets=true")
            .Options;

            _context = new HairdresserContext(options);
        }

        public ServiceRepository(HairdresserContext context)
        {
            _context = context;
        }

        public IQueryable<Service> GetAll()
        {
            return _context.Services;
        }
        public Service GetById(int ID)
        {
            return _context.Services.Find(ID);
        }
        public void Insert(Service service)
        {
            _context.Services.Add(service);
        }
        public void Update(Service service)
        {
            _context.Entry(service).State = EntityState.Modified;
        }
        public void Delete(int ID)
        {
            Service service = _context.Services.Find(ID);
            if (service != null)
            {
                _context.Services.Remove(service);
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
