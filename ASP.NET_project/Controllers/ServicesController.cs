using ASP.NET_project.Data;
using ASP.NET_project.Models;
using ASP.NET_project.Repository;
using ASP.NET_project.Service_layer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASP.NET_project.Controllers
{
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

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _serviceService.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Service model)
        {
            if (ModelState.IsValid)
            {
                _serviceService.Insert(model);
                _serviceService.Save();
                return RedirectToAction("Index", "Services");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            Service model = _serviceService.GetById(ID);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Service model)
        {
            if (ModelState.IsValid)
            {
                _serviceService.Update(model);
                _serviceService.Save();
                return RedirectToAction("Index", "Services");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            Service model = _serviceService.GetById(ID);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete_confirm(int ID)
        {
            _serviceService.Delete(ID);
            _serviceService.Save();
            return RedirectToAction("Index", "Services");
        }

    }
}
