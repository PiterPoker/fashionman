using System;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using Dick.Models.Admin;
using Dick.Models.DAO.Cloth;
using Dick.Models.Entities;
using Dick.Models.Home;

namespace Dick.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IClothDao _clothDao;

        public AdminController(IClothDao clothDao, IAdminService adminService)
        {
            _clothDao = clothDao;
            _adminService = adminService;
        }

        [HttpGet]
        public ActionResult AddClothingPatter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddClothingPatter([Bind(Exclude = "Image, ImageType")] ClothingPattern clothingPattern, 
            HttpPostedFileBase image = null)
        {
            if (!ModelState.IsValid) return View(clothingPattern);
            if (image != null)
            {
                clothingPattern.ImageType = image.ContentType;
                clothingPattern.Image = new byte[image.ContentLength];
                image.InputStream.Read(clothingPattern.Image, 0, image.ContentLength);
            }

            _adminService.AddClothingPatter(clothingPattern);
            return View();
        }

        [HttpGet]
        public ActionResult AddCutter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCutter(Cutter addCutter)
        {
            if (ModelState.IsValid)
            {
                _adminService.AddCutter(addCutter);
                return RedirectToAction("AddCutter");
            }

            return View(addCutter);
        }

        public ActionResult ClothingPatter()
        {
            return View(_adminService.LoadClothingPatterns());
        }

        public ActionResult Cloths()
        {
            return View(_clothDao.GetAll());
        }

        [HttpGet]
        public ActionResult CreateCloth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCloth([Bind(Exclude = "Image, ImageType")] Cloth cloth, 
            HttpPostedFileBase image = null)
        {
            if (!ModelState.IsValid) return View(cloth);
            if (image != null)
            {
                cloth.ImageType = image.ContentType;
                cloth.Image = new byte[image.ContentLength];
                image.InputStream.Read(cloth.Image, 0, image.ContentLength);
            }

            _clothDao.Add(cloth);
            return View();
        }

        [HttpGet]
        public ActionResult DeleteCloth(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var model = _adminService.Get(id.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteCloth(int id)
        {
            _adminService.DeleteCloth(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteCutter(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var model = _adminService.LoadCutter(id.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteCutter(int id)
        {
            _adminService.DeleteCutter(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCutter(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var model = _adminService.LoadCutter(id.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCutter(Cutter editCutter)
        {
            if (ModelState.IsValid)
            {
                _adminService.EditCutter(editCutter);
                return RedirectToAction("EditCutter");
            }

            return View();
        }

        public ActionResult GetAllCutter()
        {
            return View(_adminService.LoadCutters());
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null || _adminService.Get(id.Value) == null)
            {
                return RedirectToAction("Index");
            }

            return View(_adminService.Get(id.Value));
        }

        [HttpPost]
        public ActionResult Update([Bind(Exclude = "Image, ImageType")] Cloth cloth, 
            HttpPostedFileBase image = null)
        {
            if (!ModelState.IsValid) return View(cloth);
            if (image != null)
            {
                cloth.ImageType = image.ContentType;
                cloth.Image = new byte[image.ContentLength];
                image.InputStream.Read(cloth.Image, 0, image.ContentLength);
            }
            else
            {
                var newBrand = _adminService.Get(cloth.Id);
                cloth.ImageType = newBrand.ImageType;
                cloth.Image = newBrand.Image;
            }

            _adminService.UpdateCloth(cloth);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult UpdateClothingPattern(int? id)
        {
            if (id == null || _adminService.LoadClothingPattern(id.Value) == null)
            {
                return RedirectToAction("Index");
            }

            return View(_adminService.LoadClothingPattern(id.Value));
        }

        [HttpPost]
        public ActionResult UpdateClothingPattern([Bind(Exclude = "Image, ImageType")] ClothingPattern clothingPattern,
            HttpPostedFileBase image = null)
        {
            if (!ModelState.IsValid) return View(clothingPattern);
            if (image != null)
            {
                clothingPattern.ImageType = image.ContentType;
                clothingPattern.Image = new byte[image.ContentLength];
                image.InputStream.Read(clothingPattern.Image, 0, image.ContentLength);
            }
            else
            {
                var newBrand = _adminService.Get(clothingPattern.Id);
                clothingPattern.ImageType = newBrand.ImageType;
                clothingPattern.Image = newBrand.Image;
            }

            _adminService.UpdateClothingPattern(clothingPattern);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeleteClothingPattern(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var model = _adminService.LoadClothingPattern(id.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteClothingPattern(int id)
        {
            _adminService.DeleteClothingPattern(id);
            return RedirectToAction("Index");
        }
        public ActionResult Orders()
        {
            return View(_adminService.LoadOrders());
        }
    }
}