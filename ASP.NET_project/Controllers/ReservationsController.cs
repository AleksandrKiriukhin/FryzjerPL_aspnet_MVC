using ASP.NET_project.Data;
using ASP.NET_project.Models;
using ASP.NET_project.Repository;
using ASP.NET_project.Service_layer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ASP.NET_project.Controllers
{
    public class ReservationsController : Controller
    {
        //private readonly HairdresserContext _context;

        //public ReservationsController(HairdresserContext context)
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
        //public async Task<IActionResult> Create([Bind("ID, id_client, id_worker, id_service, date, status, price")] Reservation reservation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(reservation);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));

        //    }

        //    return View(reservation);
        //}

        //[HttpGet]

        //public async Task<IActionResult> Index()
        //{
        //    var reservations = await _context.Reservations.ToListAsync();
        //    return View(reservations);
        //}

        //[HttpGet]

        //public async Task<IActionResult> Edit(int ID)
        //{
        //    var reservation = await _context.Reservations.FindAsync(ID);
        //    if (reservation == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(reservation);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> Edit(int ID, Reservation reservation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Update(reservation);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(reservation);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Delete(int ID)
        //{
        //    var reservation = await _context.Reservations.FindAsync(ID);
        //    if (reservation == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(reservation);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> DeleteConfirmed(int ID)
        //{
        //    var reservation = await _context.Reservations.FindAsync(ID);
        //    if (reservation == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Reservations.Remove(reservation);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}

        //private IReservationRepository _reservationRepository;
        //public ReservationsController()
        //{
        //    var options = new DbContextOptionsBuilder<HairdresserContext>()
        //    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FryzjerPL;Trusted_Connection=True;MultipleActiveResultSets=true")
        //    .Options;

        //    _reservationRepository = new ReservationRepository(new HairdresserContext(options));
        //}

        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _reservationService.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservation model)
        {
            if (ModelState.IsValid)
            {
                _reservationService.Insert(model);
                _reservationService.Save();
                return RedirectToAction("Index", "Reservations");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            Reservation model = _reservationService.GetById(ID);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reservation model)
        {
            if (ModelState.IsValid)
            {
                _reservationService.Update(model);
                _reservationService.Save();
                return RedirectToAction("Index", "Reservations");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            Reservation model = _reservationService.GetById(ID);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete_confirm(int ID)
        {
            _reservationService.Delete(ID);
            _reservationService.Save();
            return RedirectToAction("Index", "Reservations");
        }

    }
}
