using System.Web;
using System.Web.Mvc;
using Dick.Models.DAO.Cloth;
using Dick.Models.Entities;

namespace Dick.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IClothDao _clothDao;

        public AdminController(IClothDao clothDao)
        {
            _clothDao = clothDao;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cloths()
        {
            return View(_clothDao.GetAll());
        }

        public ActionResult CreateCloth([Bind(Exclude = "Image, ImageType")] Cloth cloth,
            HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    cloth.ImageType = image.ContentType;
                    cloth.Image = new byte[image.ContentLength];
                    image.InputStream.Read(cloth.Image, 0, image.ContentLength);
                }
                _clothDao.Add(cloth);
            }
            return View();
        }
    }
}