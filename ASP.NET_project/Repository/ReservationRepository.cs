using ASP.NET_project.Data;
using ASP.NET_project.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_project.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HairdresserContext _context;

        public ReservationRepository()
        {
            var options = new DbContextOptionsBuilder<HairdresserContext>()
            .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FryzjerPL;Trusted_Connection=True;MultipleActiveResultSets=true")
            .Options;

            _context = new HairdresserContext(options);
        }

        public ReservationRepository(HairdresserContext context)
        {
            _context = context;
        }

        public IQueryable<Reservation> GetAll()
        {
            return _context.Reservations;
        }
        public Reservation GetById(int ID)
        {
            return _context.Reservations.Find(ID);
        }
        public void Insert(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
        }
        public void Update(Reservation reservation)
        {
            _context.Entry(reservation).State = EntityState.Modified;
        }
        public void Delete(int ID)
        {
            Reservation reservation = _context.Reservations.Find(ID);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
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
