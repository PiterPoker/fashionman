using System.Web.Mvc;
using Dick.Models.DAO.Cloth;

namespace Dick.Controllers
{
    using Dick.Models.DAO.ClothingPattern;

    public class ImageController : Controller
    {
        private readonly IClothDao _clothDao;
        private readonly IClothingPatterDao _clothingPatterDao;

        public ImageController(IClothDao clothDao,
            IClothingPatterDao clothingPatterDao)
        {
            _clothDao = clothDao;
            _clothingPatterDao = clothingPatterDao;
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
        public FileContentResult GetClothingPatterImage(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var clothingPater = _clothingPatterDao.Load(id.Value);
            return clothingPater != null ? File(clothingPater.Image, clothingPater.ImageType) : null;
        }
    }
}