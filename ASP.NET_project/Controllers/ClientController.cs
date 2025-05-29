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
using System.Runtime;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ASP.NET_project.Controllers
{
    [Authorize(Roles = "Customer, Admin, Emloyee")]
    public class ClientController : Controller
    {
        //private readonly HairdresserContext _context;

        //public ClientController(HairdresserContext context)
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID, name, surname, email, phone")] Client client)
        //{
        //    if (ModelState.IsValid) 
        //    { 
        //        _context.Add(client);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));

        //    }

        //    return View(client);
        //}

        //[HttpGet]

        //public async Task<IActionResult> Index()
        //{
        //    var clients = await _context.Clients.ToListAsync();
        //    return View(clients);
        //}

        //[HttpGet]

        //public async Task<IActionResult> Edit (int ID)
        //{
        //    var client = await _context.Clients.FindAsync(ID);
        //    if (client == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(client);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> Edit(int ID, Client client)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Update(client);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(client);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Delete(int ID)
        //{
        //    var client = await _context.Clients.FindAsync(ID);
        //    if (client == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(client);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]

        //public async Task<IActionResult> DeleteConfirmed(int ID)
        //{
        //    var client = await _context.Clients.FindAsync(ID);
        //    if (client == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Clients.Remove(client);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}

        //private IClientRepository _clientRepository;
        //public ClientController()
        //{
        //    var options = new DbContextOptionsBuilder<HairdresserContext>()
        //    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FryzjerPL;Trusted_Connection=True;MultipleActiveResultSets=true")
        //    .Options;

        //    _clientRepository = new ClientRepository(new HairdresserContext(options));
        //}

        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index(int pageNumber = 1, int pageSize = 3)
        {

            int totalItems;
            var clients = _clientService.GetClientsPaged(pageNumber, pageSize, out totalItems);

            //var clientViewModel = clients.Select(c => new ClientViewModel{

            //    ID = c.ID,
            //    name = c.name,
            //    surname = c.surname,
            //    email = c.email,
            //    phone = c.phone

            //});

            var clientViewModel = clients.Select(client => _mapper.Map<ClientViewModel>(client));

            var viewModel = new ClientListViewModel
            {
                Clients = clientViewModel,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                TotalItems = totalItems
            };

            return View(viewModel);
        }

        
        [HttpGet]
        [Authorize(Roles = "Employee, Admin")]
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [Authorize(Roles = "Employee, Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var client = new Client
                //{
                //    name = model.name,
                //    surname = model.surname,
                //    email = model.email,
                //    phone = model.phone
                //};

                var client = _mapper.Map<Client>(model);

                _clientService.Insert(client);
                _clientService.Save();
                return RedirectToAction("Index", "Client");
            }
            return View(model);
        }

        
        [HttpGet]
        [Authorize(Roles = "Employee, Admin")]
        public ActionResult Edit(int ID)
        {

            var client = _clientService.GetById(ID);
            if (client == null) {
                return NotFound();
            }

            //var model = new ClientViewModel
            //{
            //    ID = client.ID,
            //    name = client.name,
            //    surname = client.surname,
            //    email = client.email,
            //    phone = client.phone
            //};

            var model = _mapper.Map<ClientViewModel>(client);

            return View(model);
        }

       
        [HttpPost]
        [Authorize(Roles = "Employee, Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientViewModel model)
        {

            if (ModelState.IsValid)
            {
                //var client = new Client
                //{
                //    ID = model.ID,
                //    name = model.name,
                //    surname = model.surname,
                //    email = model.email,
                //    phone = model.phone
                //};

                var client = _mapper.Map<Client>(model);

                _clientService.Update(client);
                _clientService.Save();
                return RedirectToAction("Index", "Client");
            }
            else
            {
                return View(model);
            }
        }

        
        [HttpGet]
        [Authorize(Roles = "Employee, Admin")]
        public ActionResult Delete(int ID)
        {
            var client = _clientService.GetById(ID);
            if (client == null)
            {
                return NotFound();
            }

            //var model = new ClientViewModel
            //{
            //    ID = client.ID,
            //    name = client.name,
            //    surname = client.surname,
            //    email = client.email,
            //    phone = client.phone
            //};

            var model = _mapper.Map<ClientViewModel>(client);

            return View(model);
        }

        
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Employee, Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete_confirm(int ID)
        {
            _clientService.Delete(ID);
            _clientService.Save();
            return RedirectToAction("Index", "Client");
        }
    

}
}
