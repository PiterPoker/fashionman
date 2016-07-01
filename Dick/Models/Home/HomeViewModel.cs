using System.Collections.Generic;
using Dick.Models.Entities;

namespace Dick.Models.Home
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            ClothingPattern = new ClothingPattern();
            Cloths = new List<Cloth>();
        }

        public HomeViewModel(ClothingPattern clothingPattern, IEnumerable<Cloth> cloths)
        {
            ClothingPattern = clothingPattern;
            Cloths = cloths;
        }

        public ClothingPattern ClothingPattern { get; set; }

        public IEnumerable<Cloth> Cloths { get; set; }
    }
}