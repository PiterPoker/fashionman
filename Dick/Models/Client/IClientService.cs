using System.Collections.Generic;
using Dick.Models.Entities;
using Dick.Models.Home;

namespace Dick.Models.Client
{
    public interface IClientService
    {
        void EditUser(ApplicationUser eUsers);
        ApplicationUser Get();
        HomeViewModel Inicialize(int id);
        FavoriteClothViewModel InicializeCloth(int id);
        List<ClothingPattern> LoadClothingPatterns();

        ClothingPattern LoadClothingPattern(int id);
        List<Cloth> LoadCloths();
        List<Order> LoadOrders();
        Order LoadOrder(int id);
        Cloth LoadCloth(int id);
        OrderViewModel Inicialize();
        void AddOrder(Order order);
        void DeleteOrder(int id);


    }
}