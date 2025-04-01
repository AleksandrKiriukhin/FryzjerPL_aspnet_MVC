using ASP.NET_project.Models;

namespace ASP.NET_project.Service_layer
{
    public interface IServiceService
    {
        IQueryable<Service> GetAll();
        Service GetById(int ID);
        void Insert(Service service);
        void Update(Service service);
        void Delete(int ID);
        void Save();
    }
}
