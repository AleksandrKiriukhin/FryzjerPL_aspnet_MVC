using ASP.NET_project.Models;
using ASP.NET_project.ViewModel;

namespace ASP.NET_project.Service_layer
{
    public interface IClientService
    {
        IQueryable<Client> GetAll();
        Client GetById(int ID);
        void Insert(Client client);
        void Update(Client client);
        void Delete(int ID);
        bool EmailExists(string email);
        bool PhoneExists(string phone);
        IQueryable<ClientViewModel> GetClientsPaged(int pageNumber, int pageSize, out int totalItems);
        void Save();
    }
}
