using ASP.NET_project.Models;

namespace ASP.NET_project.Repository
{
    public interface IReservationRepository
    {
        IQueryable<Reservation> GetAll();
        Reservation GetById(int ID);
        void Insert(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(int ID);
        void Save();
    }
}
