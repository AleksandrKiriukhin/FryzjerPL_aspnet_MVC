using ASP.NET_project.Models;
using ASP.NET_project.Repository;

namespace ASP.NET_project.Service_layer
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public IQueryable<Reservation> GetAll()
        {
            return _reservationRepository.GetAll();
        }
        public Reservation GetById(int ID)
        {
            return _reservationRepository.GetById(ID);
        }
        public void Insert(Reservation reservation)
        {
            _reservationRepository.Insert(reservation);
            _reservationRepository.Save();
        }
        public void Update(Reservation reservation)
        {
            _reservationRepository.Update(reservation);
            _reservationRepository.Save();
        }
        public void Delete(int ID)
        {
            _reservationRepository.Delete(ID);
            _reservationRepository.Save();
        }

        public void Save()
        {
            _reservationRepository.Save();
        }
    }
}
