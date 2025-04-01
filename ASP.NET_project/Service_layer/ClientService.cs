using ASP.NET_project.Models;
using ASP.NET_project.Repository;
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
    }
}
