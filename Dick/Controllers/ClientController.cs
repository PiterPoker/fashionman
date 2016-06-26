using System.Web.Mvc;
using Dick.Models;
using Dick.Models.Client;

namespace Dick.Controllers
{
    [Authorize(Roles = "user")]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public ActionResult Index()
        {
            return View(_clientService.Get());
        }

        [HttpGet]
        // GET: Client
        public ActionResult AddClient()
        {
            return View();
        }

        public ActionResult AddClient(ApplicationUser addClient)
        {
            if (ModelState.IsValid)
            {
                _clientService.AddClient(addClient);
                return RedirectToAction("AddClient");
            }
            return View(addClient);
        }
    }
}