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
    [Authorize(Roles = "Customer, Employee, Admin")]
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
        private readonly IMapper _mapper;

        public WorkerController(IWorkerService workerService, IMapper mapper)
        {
            _workerService = workerService;
            _mapper = mapper;
        }

        

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(int pageNumber = 1, int pageSize = 3)
        {
            int totalItems;
            var workers = _workerService.GetWorkersPaged(pageNumber, pageSize, out totalItems);

            //var workerViewModel = workers.Select(c => new WorkerViewModel
            //{

            //    ID = c.ID,
            //    name = c.name,
            //    surname = c.surname

            //});

            var workerViewModel = workers.Select(worker => _mapper.Map<WorkerViewModel>(worker));

            var viewModel = new WorkerListViewModel
            {
                Workers = workerViewModel,
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
        public ActionResult Create(WorkerViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var worker = new Worker
                //{
                //    name = model.name,
                //    surname = model.surname
                //};

                var worker = _mapper.Map<Worker>(model);

                _workerService.Insert(worker);
                _workerService.Save();
                return RedirectToAction("Index", "Worker");
            }
            return View(model);
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int ID)
        {
            var worker = _workerService.GetById(ID);
            if (worker == null)
            {
                return NotFound();
            }

            //var model = new WorkerViewModel
            //{
            //    ID = worker.ID,
            //    name = worker.name,
            //    surname = worker.surname
            //};

            var model = _mapper.Map<WorkerViewModel>(worker);

            return View(model);
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WorkerViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var worker = new Worker
                //{
                //    ID = model.ID,
                //    name = model.name,
                //    surname = model.surname
                //};

                var worker = _mapper.Map<Worker>(model);

                _workerService.Update(worker);
                _workerService.Save();
                return RedirectToAction("Index", "Worker");
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
            var worker = _workerService.GetById(ID);
            if (worker == null)
            {
                return NotFound();
            }

            //var model = new WorkerViewModel
            //{
            //    ID = worker.ID,
            //    name = worker.name,
            //    surname = worker.surname
            //};

            var model = _mapper.Map<WorkerViewModel>(worker);

            return View(model);
        }

        
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete_confirm(int ID)
        {
            _workerService.Delete(ID);
            _workerService.Save();
            return RedirectToAction("Index", "Worker");
        }

    }
}
