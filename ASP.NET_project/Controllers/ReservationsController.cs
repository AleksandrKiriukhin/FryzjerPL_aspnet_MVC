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
    [Authorize(Roles = "Employee, Admin")]
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
        private readonly IMapper _mapper;

        public ReservationsController(IReservationService reservationService, IMapper mapper)
        {
            _reservationService = reservationService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index(int pageNumber = 1, int pageSize = 3)
        {
            int totalItems;
            var reservations = _reservationService.GetReservationsPaged(pageNumber, pageSize, out totalItems);

            //var reservationViewModel = reservations.Select(c => new ReservationViewModel
            //{

            //    ID = c.ID,
            //    id_client = c.id_client,
            //    id_worker = c.id_worker,
            //    id_service = c.id_service,
            //    date = c.date,
            //    status = c.status,
            //    price = c.price,

            //});

            var reservationViewModel = reservations.Select(reservation => _mapper.Map<ReservationViewModel>(reservation));

            var viewModel = new ReservationListViewModel
            {
                Reservations = reservationViewModel,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                TotalItems = totalItems
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var reservation = new Reservation
                //{
                //    id_client = model.id_client,
                //    id_worker = model.id_worker,
                //    id_service = model.id_service,
                //    date = model.date,
                //    status = model.status,
                //    price = model.price,
                //};

                var reservation = _mapper.Map<Reservation>(model);

                _reservationService.Insert(reservation);
                _reservationService.Save();
                return RedirectToAction("Index", "Reservations");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var reservation = _reservationService.GetById(ID);
            if (reservation == null)
            {
                return NotFound();
            }

            //var model = new ReservationViewModel
            //{
            //    ID = reservation.ID,
            //    id_client = reservation.id_client,
            //    id_worker = reservation.id_worker,
            //    id_service = reservation.id_service,
            //    date = reservation.date,
            //    status = reservation.status,
            //    price = reservation.price,
            //};

            var model = _mapper.Map<ReservationViewModel>(reservation);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReservationViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var reservation = new Reservation
                //{
                //    ID = model.ID,
                //    id_client = model.id_client,
                //    id_worker = model.id_worker,
                //    id_service = model.id_service,
                //    date = model.date,
                //    status = model.status,
                //    price = model.price,
                //};

                var reservation = _mapper.Map<Reservation>(model);

                _reservationService.Update(reservation);
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
            var reservation = _reservationService.GetById(ID);
            if (reservation == null)
            {
                return NotFound();
            }

            //var model = new ReservationViewModel
            //{
            //    ID = reservation.ID,
            //    id_client = reservation.id_client,
            //    id_worker = reservation.id_worker,
            //    id_service = reservation.id_service,
            //    date = reservation.date,
            //    status = reservation.status,
            //    price = reservation.price,
            //};

            var model = _mapper.Map<ReservationViewModel>(reservation);

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
