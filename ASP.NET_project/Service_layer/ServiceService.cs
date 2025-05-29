using ASP.NET_project.Models;
using ASP.NET_project.Repository;
using ASP.NET_project.ViewModel;

namespace ASP.NET_project.Service_layer
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public IQueryable<ServiceViewModel> GetServicesPaged(int pageNumber, int pageSize, out int totalItems)
        {
            var services = _serviceRepository.GetAll();
            totalItems = services.Count();

            var pagedService = services
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new ServiceViewModel
                {
                    ID = c.ID,
                    name = c.name,
                    price = c.price,
                });

            return pagedService;
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
        public bool NameExists(string name)
        {
            return _serviceRepository.GetAll().Any(s => s.name.Trim().ToLower() == name.Trim().ToLower());
        }
    }
}
