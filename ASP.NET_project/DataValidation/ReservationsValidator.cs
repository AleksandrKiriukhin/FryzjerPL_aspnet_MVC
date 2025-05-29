using ASP.NET_project.Models;
using ASP.NET_project.Service_layer;
using ASP.NET_project.ViewModel;
using FluentValidation;

namespace ASP.NET_project.DataValidation
{
    public class ReservationsValidator : AbstractValidator<ReservationViewModel>
    {
        
        private readonly IReservationService _reservationService;
        public ReservationsValidator(IReservationService reservationService)
        {
            _reservationService = reservationService;

            RuleFor(x => x.id_client).Must(ClientExists).WithMessage("Client with this ID does not exist in database.");

            RuleFor(x => x.id_service).Must(ServiceExists).WithMessage("Service with this ID does not exist in database.");

            RuleFor(x => x.id_worker).Must(WorkerExists).WithMessage("Worker with this ID does not exist in database.");

            RuleFor(x => x.price).NotEmpty().GreaterThan(0).WithMessage("Price can't be zero or less!");

            RuleFor(x => x.status).NotEmpty().WithMessage("Status can't be empty!");

            RuleFor(x => x.date).NotEmpty().WithMessage("Date can't be empty!");
        }

        private bool ClientExists(int clientId)
        {
            return _reservationService.ClientExists(clientId);
        }
        private bool ServiceExists(int serviceId)
        {
            return _reservationService.ServiceExists(serviceId);
        }
        private bool WorkerExists(int workerId)
        {
            return _reservationService.WorkerExists(workerId);
        }
    }
}
