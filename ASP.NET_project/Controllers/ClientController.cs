using ASP.NET_project.Data;
using ASP.NET_project.Models;
using ASP.NET_project.Repository;
using ASP.NET_project.Service_layer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime;

namespace ASP.NET_project.Controllers
{
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

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _clientService.GetAll();
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client model)
        {
            if (ModelState.IsValid)
            {
                _clientService.Insert(model);
                _clientService.Save();
                return RedirectToAction("Index", "Client");
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            Client model = _clientService.GetById(ID);
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client model)
        {
            if (ModelState.IsValid)
            {
                _clientService.Update(model);
                _clientService.Save();
                return RedirectToAction("Index", "Client");
            }
            else
            {
                return View(model);
            }
        }
        
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            Client model = _clientService.GetById(ID);
            return View(model);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete_confirm(int ID)
        {
            _clientService.Delete(ID);
            _clientService.Save();
            return RedirectToAction("Index", "Client");
        }
    

}
}
