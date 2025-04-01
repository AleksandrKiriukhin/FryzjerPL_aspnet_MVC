using ASP.NET_project.Models;

namespace ASP.NET_project.Repository
{
    public interface IServiceRepository
    {
        IQueryable<Service> GetAll();
        Service GetById(int ID);
        void Insert(Service service);
        void Update(Service service);
        void Delete(int ID);
        void Save();
    }
}
