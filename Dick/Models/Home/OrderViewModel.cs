using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Dick.Models.Entities;

namespace Dick.Models.Home
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            Order = new Order();
            Cloth = new List<SelectListItem>();
            ClothingPatern = new List<SelectListItem>();
            Cutters = new List<SelectListItem>();
        }

        public OrderViewModel(List<Cutter> cutters, 
            List<Cloth> cloths, 
            List<ClothingPattern> cloyhingPatterns)
        {
                        Order = new Order();
            Cutters = Inicialize(cutters);
            Cloth = Inicialize(cloths);
            ClothingPatern = Inicialize(cloyhingPatterns);
        }

        public Order Order { get; set; }
        public List<SelectListItem> Cloth { get; set; }

        public List<SelectListItem> ClothingPatern { get; set; }

        public List<SelectListItem> Cutters { get; set; }

        private List<SelectListItem> Inicialize<T>(List<T> item) where T : class
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Disabled = true, 
                    Selected = true, 
                    Text = "Выберете", 
                    Value = ""
                }
            };
            if (typeof(T) == typeof(Cutter))
            {
                foreach (var i in item)
                {
                    list.Add(new SelectListItem
                    {
                        Disabled = false,
                        Selected = false,
                        Text = i.GetType().GetProperty("LastName").GetValue(i).ToString(),
                        Value = i.GetType().GetProperty("Id").GetValue(i).ToString()
                    });
                }
            }
            else
            {
                list.AddRange(item.Select(i => new SelectListItem
                {
                    Disabled = false, 
                    Selected = false,
                    Text = i.GetType().GetProperty("Name").GetValue(i).ToString(), 
                    Value = i.GetType().GetProperty("Id").GetValue(i).ToString()
                }));
            }

            return list;
        }
    }
}