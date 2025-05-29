using ASP.NET_project.Models;
using ASP.NET_project.Service_layer;
using ASP.NET_project.ViewModel;
using FluentValidation;

namespace ASP.NET_project.DataValidation
{
    public class ServiceValidation : AbstractValidator<ServiceViewModel>
    {
        private readonly IServiceService _serviceService;
        public ServiceValidation(IServiceService serviceService)
        {
            _serviceService = serviceService;

            RuleFor(service => service.name).NotEmpty().Length(3, 60).WithMessage("Name should be longer than 3 symbols and shorter than 60 symbols!");
            RuleFor(service => service.name).Must(Name_exists).WithMessage("Service with this name is already in database!");

            RuleFor(service => service.price).NotEmpty().GreaterThan(0).WithMessage("Price can't be zero or less!");
        }

        private bool Name_exists(string name)
        {
            return !_serviceService.NameExists(name);
        }
    }
}
