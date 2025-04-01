using ASP.NET_project.Models;
using ASP.NET_project.Repository;

namespace ASP.NET_project.Service_layer
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerService(IWorkerRepository workerRepository) { 
            _workerRepository = workerRepository;
        }

        public IQueryable<Worker> GetAll()
        {
            return _workerRepository.GetAll();
        }
        public Worker GetById(int ID)
        {
            return _workerRepository.GetById(ID);
        }
        public void Insert(Worker worker)
        {
            _workerRepository.Insert(worker);
            _workerRepository.Save();
        }
        public void Update(Worker worker)
        {
            _workerRepository.Update(worker);
            _workerRepository.Save();
        }
        public void Delete(int ID)
        {
            _workerRepository.Delete(ID);
            _workerRepository.Save();
        }

        public void Save()
        {
            _workerRepository.Save();
        }
    }
}
