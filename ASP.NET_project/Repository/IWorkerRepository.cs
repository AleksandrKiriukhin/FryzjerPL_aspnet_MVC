using ASP.NET_project.Models;

namespace ASP.NET_project.Repository
{
    public interface IWorkerRepository
    {
        IQueryable<Worker> GetAll();
        Worker GetById(int ID);
        void Insert(Worker worker);
        void Update(Worker worker);
        void Delete(int ID);
        void Save();
    }
}
