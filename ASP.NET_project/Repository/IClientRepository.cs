
using ASP.NET_project.Models;

namespace ASP.NET_project.Repository
{
    public interface IClientRepository
    {
        IQueryable<Client> GetAll();
        Client GetById(int ID);
        void Insert(Client client);
        void Update(Client client);
        void Delete(int ID);
        void Save();
    }
}
