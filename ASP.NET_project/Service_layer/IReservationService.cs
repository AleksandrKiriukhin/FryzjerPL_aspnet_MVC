using ASP.NET_project.Models;
using ASP.NET_project.ViewModel;

namespace ASP.NET_project.Service_layer
{
    public interface IReservationService
    {
        IQueryable<Reservation> GetAll();
        Reservation GetById(int ID);
        void Insert(Reservation reservation);
        void Update(Reservation reservation);
        void Delete(int ID);
        bool ClientExists(int id_clienta);
        bool ServiceExists(int id_service);
        bool WorkerExists(int id_worker);
        IQueryable<ReservationViewModel> GetReservationsPaged(int pageNumber, int pageSize, out int totalItems);
        void Save();
    }
}
