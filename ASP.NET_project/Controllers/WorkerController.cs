using ASP.NET_project.Data;
using ASP.NET_project.Models;
using ASP.NET_project.Repository;
using ASP.NET_project.Service_layer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASP.NET_project.Controllers
{
    public class WorkerController : Controller
    {
        //private readonly HairdresserContext _context;

        //public WorkerController(HairdresserContext context)
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
        //public async Task<IActionResult> Create([Bind("ID, name, surname")] Worker worker)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(worker);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));

        //    }

        //    return View(worker);
        //}

        //[HttpGet]

        //public async Task<IActionResult> Index()
        //{
        //    var workers = await _context.Workers.ToListAsync();
        //    return View(workers);
        //}

        //[HttpGet]

        //public async Task<IActionResult> Edit(int ID)
        //{
        //    var worker = await _context.Workers.FindAsync(ID);
        //    if (worker == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(worker);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> Edit(int ID, Worker worker)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Update(worker);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(worker);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Delete(int ID)
        //{
        //    var worker = await _context.Workers.FindAsync(ID);
        //    if (worker == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(worker);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> DeleteConfirmed(int ID)
        //{
        //    var worker = await _context.Workers.FindAsync(ID);
        //    if (worker == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Workers.Remove(worker);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}

        //private IWorkerRepository _workerRepository;
        //public WorkerController()
        //{
        //    var options = new DbContextOptionsBuilder<HairdresserContext>()
        //    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FryzjerPL;Trusted_Connection=True;MultipleActiveResultSets=true")
        //    .Options;

        //    _workerRepository = new WorkerRepository(new HairdresserContext(options));
        //}

        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _workerService.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Worker model)
        {
            if (ModelState.IsValid)
            {
                _workerService.Insert(model);
                _workerService.Save();
                return RedirectToAction("Index", "Worker");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            Worker model = _workerService.GetById(ID);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Worker model)
        {
            if (ModelState.IsValid)
            {
                _workerService.Update(model);
                _workerService.Save();
                return RedirectToAction("Index", "Worker");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            Worker model = _workerService.GetById(ID);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete_confirm(int ID)
        {
            _workerService.Delete(ID);
            _workerService.Save();
            return RedirectToAction("Index", "Worker");
        }

    }
}
