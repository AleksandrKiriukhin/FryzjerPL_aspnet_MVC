using ASP.NET_project.Data;
using ASP.NET_project.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_project.Repository
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly HairdresserContext _context;

        public WorkerRepository()
        {
            var options = new DbContextOptionsBuilder<HairdresserContext>()
            .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FryzjerPL;Trusted_Connection=True;MultipleActiveResultSets=true")
            .Options;

            _context = new HairdresserContext(options);
        }

        public WorkerRepository(HairdresserContext context)
        {
            _context = context;
        }

        public IQueryable<Worker> GetAll()
        {
            return _context.Workers;
        }
        public Worker GetById(int ID)
        {
            return _context.Workers.Find(ID);
        }
        public void Insert(Worker worker)
        {
            _context.Workers.Add(worker);
        }
        public void Update(Worker worker)
        {
            _context.Entry(worker).State = EntityState.Modified;
        }
        public void Delete(int ID)
        {
            Worker worker = _context.Workers.Find(ID);
            if (worker != null)
            {
                _context.Workers.Remove(worker);
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
