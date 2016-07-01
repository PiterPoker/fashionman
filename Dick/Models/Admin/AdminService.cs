using System.Collections.Generic;
using Dick.Models.DAO;
using Dick.Models.DAO.Cloth;
using Dick.Models.DAO.ClothingPattern;
using Dick.Models.DAO.Cutter;
using Dick.Models.DAO.Order;
using Dick.Models.Entities;

namespace Dick.Models.Admin
{
    public class AdminService : IAdminService
    {
        private readonly IClothDao _clothDao;
        private readonly IClothingPatterDao _clothingPatterDao;
        private readonly ICutterDao _cutterDao;
        private readonly IOrderDao _orderDao;
        private readonly IUserDao _userDao;



        public AdminService(
            IClothDao clothDao, 
            ICutterDao cutterDao, 
            IClothingPatterDao clothingPatterDao,
            IOrderDao orderDao,
            IUserDao userDao)
        {
            _clothDao = clothDao;
            _cutterDao = cutterDao;
            _clothingPatterDao = clothingPatterDao;
            _orderDao = orderDao;
            _userDao = userDao;
        }

        public void AddClothingPatter(ClothingPattern aClothingPattern)
        {
            _clothingPatterDao.Add(aClothingPattern);
        }

        public void AddCutter(Cutter aCutter)
        {
            _cutterDao.Add(aCutter);
        }

        public void DeleteCloth(int id)
        {
            _clothDao.Delete(id);
        }

        public void DeleteCutter(int id)
        {
            _cutterDao.Delete(id);
        }

        public void EditCloth(Cloth eCloth)
        {
            _clothDao.Edit(eCloth);
        }

        public void EditCutter(Cutter eCutter)
        {
            _cutterDao.Edit(eCutter);
        }

        public Cloth Get(int id)
        {
            var model = _clothDao.Get(id);
            return model;
        }

        public ClothingPattern LoadClothingPattern(int id)
        {
            var model = _clothingPatterDao.Load(id);
            return model;
        }

        public List<ClothingPattern> LoadClothingPatterns()
        {
            var model = _clothingPatterDao.Load();
            return model;
        }

        public Cutter LoadCutter(int id)
        {
            var model = _cutterDao.Load(id);
            return model;
        }

        public List<Cutter> LoadCutters()
        {
            var model = _cutterDao.Load();
            return model;
        }

        public void UpdateCloth(Cloth cloth)
        {
            _clothDao.Update(cloth);
        }

        public void UpdateClothingPattern(ClothingPattern clothingPattern)
        {
            _clothingPatterDao.Update(clothingPattern);
        }


        public void DeleteClothingPattern(int id)
        {
            _clothingPatterDao.Delete(id);
        }


        public void AddOrder(Order order)
        {
            _orderDao.Add(order);
        }


        public List<ApplicationUser> LoadUsers()
        {
            var model = _userDao.Load();
            return model;
        }


        public List<Order> LoadOrders()
        {
            var model = _orderDao.Load();
            return model;
        }

        public Order LoadOrder(int id)
        {
            var model = _orderDao.Load(id);
            return model;
        }
    }
}