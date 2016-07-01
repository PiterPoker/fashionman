using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dick.Models.Admin
{
    using Dick.Models.Entities;

    public interface IAdminService
    {
        void EditCloth(Cloth eCloth);
        void DeleteCloth(int id);
        void AddCutter(Cutter aCutter);
        void EditCutter(Cutter eCutter);
        void DeleteCutter(int id);
        Cloth Get(int id);
        void UpdateCloth(Cloth cloth);
        List<Cutter> LoadCutters(); 
        Cutter LoadCutter(int id);

        List<ClothingPattern> LoadClothingPatterns();

        ClothingPattern LoadClothingPattern(int id);

        void AddClothingPatter(ClothingPattern clothingPattern);
        void UpdateClothingPattern(ClothingPattern clothingPattern);
        void DeleteClothingPattern(int id);
        void AddOrder(Order order);
        List<ApplicationUser> LoadUsers();
        List<Order> LoadOrders();
        Entities.Order LoadOrder(int id);


    }
}