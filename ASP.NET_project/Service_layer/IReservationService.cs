using ASP.NET_project.Models;

namespace ASP.NET_project.Service_layer
{
    public interface IReservationService
    {
        IQueryable<Reservation> GetAll();
        Reservation GetById(int ID);
        void Insert(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(int ID);
        void Save();
    }
}
