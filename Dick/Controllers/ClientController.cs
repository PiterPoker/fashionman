using System;
using System.Globalization;
using System.Web.Mvc;
using Dick.Models.Client;
using Dick.Models;
using Dick.Models.Entities;
using Dick.Models.Home;
using Microsoft.AspNet.Identity;

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
        [HttpGet]
        public ActionResult EditUser(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var model = _clientService.Get();
            return View(model);
        }
        [HttpPost]
        public ActionResult EditUser(ApplicationUser eUser)
        {
            if (ModelState.IsValid)
            {
                _clientService.EditUser(eUser);
                return RedirectToAction("EditUser");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DetailClothingPatern(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            return View(_clientService.Inicialize(id.Value));
        }
        public ActionResult LoadCloths()
        {
            return View(_clientService.LoadCloths());
        }
        [HttpGet]
        public ActionResult AddOrder()
        {
            return View(_clientService.Inicialize());
        }

        [HttpPost]
        public ActionResult AddOrder(string bdate, Order order)
        {



            if (!ModelState.IsValid)
            {
                var model = _clientService.Inicialize();
                model.Order = order;
                return View(model);
            }
            order.BeginDate = DateTime.Now;
            order.UserId = User.Identity.GetUserId();
            _clientService.AddOrder(order);
            return RedirectToAction("AddOrder");
        }

        public ActionResult LoadClothingPatterns()
        {
            return View(_clientService.LoadClothingPatterns());
        }
        public ActionResult DetailCloth(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            return View(_clientService.InicializeCloth(id.Value));
        }
        public ActionResult LoadOrders()
        {
            return View(_clientService.LoadOrders());
        }
        [HttpGet]
        public ActionResult DeleteOrder(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var model = _clientService.LoadOrder(id.Value);
            return View(model);
        }
        [HttpPost]
        public ActionResult DeleteOrder(int id)
        {
            _clientService.DeleteOrder(id);
            return RedirectToAction("Index");
        }
    }
}