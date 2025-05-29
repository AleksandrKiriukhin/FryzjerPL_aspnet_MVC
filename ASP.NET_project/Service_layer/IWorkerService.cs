using ASP.NET_project.Models;
using ASP.NET_project.ViewModel;

namespace ASP.NET_project.Service_layer
{
    public interface IWorkerService
    {

        IQueryable<Worker> GetAll();
        Worker GetById(int ID);
        void Insert(Worker worker);
        void Update(Worker worker);
        void Delete(int ID);

        IQueryable<WorkerViewModel> GetWorkersPaged(int pageNumber, int pageSize, out int totalItems);
        void Save();

    }
}
