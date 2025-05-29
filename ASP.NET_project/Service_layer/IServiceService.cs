using ASP.NET_project.Models;
using ASP.NET_project.ViewModel;

namespace ASP.NET_project.Service_layer
{
    public interface IServiceService
    {
        IQueryable<Service> GetAll();
        Service GetById(int ID);
        void Insert(Service service);
        void Update(Service service);
        void Delete(int ID);
        bool NameExists(string name);
        IQueryable<ServiceViewModel> GetServicesPaged(int pageNumber, int pageSize, out int totalItems);
        void Save();
    }
}
