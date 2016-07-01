using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using Dick.Models.DAO;
using Dick.Models.DAO.Cloth;
using Dick.Models.DAO.ClothingPattern;
using Dick.Models.DAO.Cutter;
using Dick.Models.DAO.Order;
using Dick.Models.Entities;
using Dick.Models.Home;

namespace Dick.Models.Client
{
    public class ClientService : IClientService
    {
        private readonly IClothDao _clothDao;
        private readonly IClothingPatterDao _clothingPatternDao;
        private readonly IUserDao _userDao;
        private readonly ICutterDao _cutterDao;
        private readonly IOrderDao _orderDao;
        private IClientService clientServiceImplementation;

        public ClientService(IUserDao userDao, 
            IClothDao clothDao, 
            IClothingPatterDao clothingPatternDao,
            ICutterDao cutterDao, IOrderDao orderDao)
        {
            _userDao = userDao;
            _clothDao = clothDao;
            _clothingPatternDao = clothingPatternDao;
            _cutterDao = cutterDao;
            _orderDao = orderDao;
        }

        public void EditUser(ApplicationUser eUsers)
        {
            _userDao.Edit(eUsers);
        }
        
        public ApplicationUser Get()
        {
            var user = _userDao.GetCurrent();
            return user;
        }

        public HomeViewModel Inicialize(int id)
        {
            var model = new HomeViewModel(_clothingPatternDao.Load(id), _clothDao.GetAll());
            return model;
        }

        public List<ClothingPattern> LoadClothingPatterns()
        {
            var model = _clothingPatternDao.Load();
            return model;
        }

        public ClothingPattern LoadClothingPattern(int id)
        {
            var model =_clothingPatternDao.Load(id);
            return model;
        }

        public List<Cloth> LoadCloths()
        {
            var model = _clothDao.GetAll();
            return model;
        }

        public Cloth LoadCloth(int id)
        {
            var model = _clothDao.Get(id);
            return model;
        }


        public OrderViewModel Inicialize()
        {
            var model = new OrderViewModel(_cutterDao.Load(), _clothDao.GetAll(), _clothingPatternDao.Load());
            return model;
        }
        public void AddOrder(Order order)
        {
            _orderDao.Add(order);
        }


        public FavoriteClothViewModel InicializeCloth(int id)
        {
            var model = new FavoriteClothViewModel(_clothDao.Get(id), _clothingPatternDao.Load());
            return model;
        }


        public void DeleteOrder(int id)
        {
            _orderDao.Delete(id);
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