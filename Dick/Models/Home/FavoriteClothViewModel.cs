using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dick.Models.Entities;

namespace Dick.Models.Home
{
    public class FavoriteClothViewModel
    {
         public FavoriteClothViewModel()
        {
            ClothingPatterns = new List<ClothingPattern>();
            Cloth = new Cloth();
        }

         public FavoriteClothViewModel(
            Cloth cloth,
            IEnumerable<ClothingPattern> clothingPatterns)
        {
            ClothingPatterns = clothingPatterns;
            Cloth = cloth;
        }

        public Cloth Cloth { get; set; }
        public IEnumerable<ClothingPattern> ClothingPatterns { get; set; }
    }
}