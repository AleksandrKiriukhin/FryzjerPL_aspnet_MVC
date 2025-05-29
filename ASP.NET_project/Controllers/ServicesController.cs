using ASP.NET_project.Data;
using ASP.NET_project.Models;
using ASP.NET_project.Repository;
using ASP.NET_project.Service_layer;
using ASP.NET_project.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASP.NET_project.Controllers
{
    [Authorize(Roles = "Customer, Emloyee, Admin")]
    public class ServicesController : Controller
    {
        //private readonly HairdresserContext _context;

        //public ServicesController(HairdresserContext context)
        //{
        //    _context = context;
        //}
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //public IActionResult Edit()
        //{
        //    return View();
        //}

        ////public IActionResult Index()
        ////{

        ////    return View();
        ////}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID, name, price")] Service service)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(service);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));

        //    }

        //    return View(service);
        //}

        //[HttpGet]

        //public async Task<IActionResult> Index()
        //{
        //    var services = await _context.Services.ToListAsync();
        //    return View(services);
        //}

        //[HttpGet]

        //public async Task<IActionResult> Edit(int ID)
        //{
        //    var service = await _context.Services.FindAsync(ID);
        //    if (service == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(service);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> Edit(int ID, Service service)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Update(service);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(service);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Delete(int ID)
        //{
        //    var service = await _context.Services.FindAsync(ID);
        //    if (service == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(service);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> DeleteConfirmed(int ID)
        //{
        //    var service = await _context.Services.FindAsync(ID);
        //    if (service == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Services.Remove(service);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}

        //private IServiceRepository _serviceRepository;
        //public ServicesController()
        //{
        //    var options = new DbContextOptionsBuilder<HairdresserContext>()
        //    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FryzjerPL;Trusted_Connection=True;MultipleActiveResultSets=true")
        //    .Options;

        //    _serviceRepository = new ServiceRepository(new HairdresserContext(options));
        //}

        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public ServicesController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(int pageNumber = 1, int pageSize = 3)
        {
            int totalItems;
            var services = _serviceService.GetServicesPaged(pageNumber, pageSize, out totalItems);

            //var serviceViewModel = services.Select(c => new ServiceViewModel
            //{

            //    ID = c.ID,
            //    name = c.name,
            //    price = c.price

            //});

            var serviceViewModel = services.Select(service => _mapper.Map<ServiceViewModel>(service));

            var viewModel = new ServiceListViewModel
            {
                Services = serviceViewModel,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                TotalItems = totalItems
            };

            return View(viewModel);
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var service = new Service
                //{
                //    name = model.name,
                //    price = model.price
                //};

                var service = _mapper.Map<Service>(model);

                _serviceService.Insert(service);
                _serviceService.Save();
                return RedirectToAction("Index", "Services");
            }
            return View(model);
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int ID)
        {
            var service = _serviceService.GetById(ID);
            if (service == null)
            {
                return NotFound();
            }

            //var model = new ServiceViewModel
            //{
            //    ID = service.ID,
            //    name = service.name,
            //    price = service.price
            //};

            var model = _mapper.Map<ServiceViewModel>(service);

            return View(model);
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var service = new Service
                //{
                //    ID = model.ID,
                //    name = model.name,
                //    price = model.price
                //};

                var service = _mapper.Map<Service>(model);

                _serviceService.Update(service);
                _serviceService.Save();
                return RedirectToAction("Index", "Services");
            }
            else
            {
                return View(model);
            }
        }


        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int ID)
        {
            var service = _serviceService.GetById(ID);
            if (service == null)
            {
                return NotFound();
            }

            //var model = new ServiceViewModel
            //{
            //    ID = service.ID,
            //    name = service.name,
            //    price = service.price
            //};

            var model = _mapper.Map<ServiceViewModel>(service);

            return View(model);
        }

        
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete_confirm(int ID)
        {
            _serviceService.Delete(ID);
            _serviceService.Save();
            return RedirectToAction("Index", "Services");
        }

    }
}
