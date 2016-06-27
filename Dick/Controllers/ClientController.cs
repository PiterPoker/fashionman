using System.Web.Mvc;
using Dick.Models.Client;

namespace Dick.Controllers
{
    [Authorize]
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
        //добавить изменение данных клиента
    }
}