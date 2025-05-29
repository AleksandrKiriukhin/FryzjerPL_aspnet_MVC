using ASP.NET_project.Models;
using ASP.NET_project.Repository;
using ASP.NET_project.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ASP.NET_project.Service_layer
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository) { 
            _clientRepository = clientRepository;
        }

        public IQueryable<ClientViewModel> GetClientsPaged(int pageNumber, int pageSize, out int totalItems)
        {
            var clients = _clientRepository.GetAll(); 
            totalItems = clients.Count(); 

            var pagedClients = clients
                .Skip((pageNumber - 1) * pageSize) 
                .Take(pageSize) 
                .Select(c => new ClientViewModel
                {
                    ID = c.ID,
                    name = c.name,
                    surname = c.surname,
                    email = c.email,
                    phone = c.phone
                });

            return pagedClients;
        }

        public IQueryable<Client> GetAll() {
            return _clientRepository.GetAll();
        }
        public Client GetById(int ID) { 
            return _clientRepository.GetById(ID);
        }
        public void Insert(Client client) { 
            _clientRepository.Insert(client);
            _clientRepository.Save();
        }
        public void Update(Client client) { 
            _clientRepository.Update(client);
            _clientRepository.Save();   
        }
        public void Delete(int ID) { 
            _clientRepository.Delete(ID);
            _clientRepository.Save();   
        }

        public void Save()
        {
            _clientRepository.Save();
        }

        public bool EmailExists(string email)
        {
            return _clientRepository.GetAll().Any(c => c.email == email);
        }
        public bool PhoneExists(string phone)
        {
            return _clientRepository.GetAll().Any(c => c.phone == phone);
        }
    }
}
