using ASP.NET_project.Models;

namespace ASP.NET_project.Service_layer
{
    public interface IClientService
    {
        IQueryable<Client> GetAll();
        Client GetById(int ID);
        void Insert(Client client);
        void Update(Client client);
        void Delete(int ID);
        void Save();
    }
}
