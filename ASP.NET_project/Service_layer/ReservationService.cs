using ASP.NET_project.Models;
using ASP.NET_project.Repository;
using ASP.NET_project.ViewModel;

namespace ASP.NET_project.Service_layer
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IWorkerRepository _workerRepository;
        private readonly IServiceRepository _serviceRepository;

        public ReservationService (IReservationRepository reservationRepository, IClientRepository clientRepository, IWorkerRepository workerRepository, IServiceRepository serviceRepository)
        {
            _reservationRepository = reservationRepository;
            _clientRepository = clientRepository;
            _workerRepository = workerRepository;
            _serviceRepository = serviceRepository;
        }

    public IQueryable<ReservationViewModel> GetReservationsPaged(int pageNumber, int pageSize, out int totalItems)
        {
            var reservations = _reservationRepository.GetAll();
            totalItems = reservations.Count();

            var pagedReservation = reservations
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new ReservationViewModel
                {
                    ID = c.ID,
                    id_client = c.id_client,
                    id_worker = c.id_worker,
                    id_service = c.id_service,
                    date = c.date,
                    status = c.status,
                    price = c.price,
                });

            return pagedReservation;
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

        public bool ClientExists (int id_client)
        {
            return _clientRepository.GetAll().Any(c => c.ID == id_client);
        }
        public bool WorkerExists(int id_worker)
        {
            return _workerRepository.GetAll().Any(c => c.ID == id_worker);
        }
        public bool ServiceExists(int id_service)
        {
            return _serviceRepository.GetAll().Any(c => c.ID == id_service);
        }
    }
}
