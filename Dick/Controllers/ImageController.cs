using System.Web.Mvc;
using Dick.Models.DAO.Cloth;

namespace Dick.Controllers
{
    public class ImageController : Controller
    {
        private readonly IClothDao _clothDao;

        public ImageController(IClothDao clothDao)
        {
            _clothDao = clothDao;
        }

        public FileContentResult GetClothImage(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var cloth = _clothDao.Get(id.Value);
            return cloth != null ? File(cloth.Image, cloth.ImageType) : null;
        }
    }
}