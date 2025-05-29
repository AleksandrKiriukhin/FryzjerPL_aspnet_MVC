using ASP.NET_project.Models;
using ASP.NET_project.Service_layer;
using ASP.NET_project.ViewModel;
using FluentValidation;
namespace ASP.NET_project.DataValidation
{
    public class WorkerValidator : AbstractValidator<WorkerViewModel>
    {
        private readonly IWorkerService _workerService;
        public WorkerValidator(IWorkerService workerService)
        {
            _workerService = workerService;

            RuleFor(worker => worker.name).NotEmpty().Length(3, 30).WithMessage("Name should be longer than 3 symbols and shorter than 30 symbols!");
            RuleFor(worker => worker.surname).NotEmpty().Length(3, 50).WithMessage("Surname should be longer than 3 symbols and shorter than 50 symbols!");
        }
    }
}
