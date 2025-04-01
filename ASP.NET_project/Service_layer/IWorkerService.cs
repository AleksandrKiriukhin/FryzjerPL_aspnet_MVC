using ASP.NET_project.Models;

namespace ASP.NET_project.Service_layer
{
    public interface IWorkerService
    {

        IQueryable<Worker> GetAll();
        Worker GetById(int ID);
        void Insert(Worker worker);
        void Update(Worker worker);
        void Delete(int ID);
        void Save();

    }
}
