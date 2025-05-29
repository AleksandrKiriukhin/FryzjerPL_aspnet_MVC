using ASP.NET_project.Models;
using ASP.NET_project.Service_layer;
using ASP.NET_project.ViewModel;
using FluentValidation;
namespace ASP.NET_project.DataValidation
{
    public class ClientValidator : AbstractValidator<ClientViewModel>
    {
        private readonly bool isUpdate;
        private readonly IClientService _clientService;
        public ClientValidator(IClientService clientService)
        {
            _clientService = clientService;

            isUpdate = false;

            RuleFor(client => client.name).NotEmpty().WithMessage("Client should have first name!");
            RuleFor(client => client.name).NotEmpty().Length(3,30).WithMessage("Name should be longer than 3 symbols and shorter than 30 symbols!");

            RuleFor(client => client.surname).NotEmpty().WithMessage("Client should have last name!");
            RuleFor(client => client.surname).NotEmpty().Length(3, 50).WithMessage("Surname should be longer than 3 symbols and shorter than 50 symbols!");

            RuleFor(client => client.email).NotEmpty().EmailAddress().WithMessage("Email address is not correct!");
            RuleFor(client => client.email).Must(Email_exists).WithMessage("Email already exists in database!");

            RuleFor(client => client.phone).NotEmpty().Matches(@"^\+48 \d{3} \d{3} \d{3}$").WithMessage("The phone number should look like this: +48 XXX XXX XXX!");
            RuleFor(client => client.phone).Must(Phone_exists).WithMessage("This mobile phone already exists in database!");

            
        }

        private bool Email_exists(string email)
        {
            return !_clientService.EmailExists(email);
        }
        private bool Phone_exists(string phone)
        {
            return !_clientService.PhoneExists(phone);
        }
    }
}
