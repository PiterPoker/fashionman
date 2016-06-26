using System.Data.Entity;
using System.Linq;

namespace Dick.Models.DAO.ClothingPattern
{
    public class ClothingPatterDao : IClothingPatterDao
    {
        public void Add(Entities.ClothingPattern clothingpatter)
        {
            using (var context = new ApplicationDbContext())
            {
                context.ClothingPattern.Add(clothingpatter);
                context.SaveChanges();
            }
        }

        public void Delete(Entities.ClothingPattern clothingpatter)
        {
            using (var context = new ApplicationDbContext())
            {
                var deleteItem = context.ClothingPattern.FirstOrDefault(a => a.Id == clothingpatter.Id);
                if (deleteItem == null)
                    return;
                context.ClothingPattern.Remove(deleteItem);
                context.SaveChanges();
            }
        }

        public void Edit(Entities.ClothingPattern clothingpatter)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(clothingpatter).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}