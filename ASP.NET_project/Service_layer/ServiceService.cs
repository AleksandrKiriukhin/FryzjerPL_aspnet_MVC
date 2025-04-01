using ASP.NET_project.Models;
using ASP.NET_project.Repository;

namespace ASP.NET_project.Service_layer
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public IQueryable<Service> GetAll()
        {
            return _serviceRepository.GetAll();
        }
        public Service GetById(int ID)
        {
            return _serviceRepository.GetById(ID);
        }
        public void Insert(Service service)
        {
            _serviceRepository.Insert(service);
            _serviceRepository.Save();
        }
        public void Update(Service service)
        {
            _serviceRepository.Update(service);
            _serviceRepository.Save();
        }
        public void Delete(int ID)
        {
            _serviceRepository.Delete(ID);
            _serviceRepository.Save();
        }

        public void Save()
        {
            _serviceRepository.Save();
        }
    }
}
