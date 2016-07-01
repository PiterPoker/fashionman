using System.Collections.Generic;
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

        public void Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var item = context.ClothingPattern.Find(id);
                if (item != null)
                {
                    context.ClothingPattern.Remove(item);
                }

                context.SaveChanges();
            }
        }

        public Entities.ClothingPattern Load(int id)
        {
            Entities.ClothingPattern clothingPattern;
            using (var context = new ApplicationDbContext())
            {
                clothingPattern = context.ClothingPattern.FirstOrDefault(c => c.Id == id);
            }

            return clothingPattern;
        }

        public List<Entities.ClothingPattern> Load()
        {
            List<Entities.ClothingPattern> clothingPatterns;
            using (var context = new ApplicationDbContext())
            {
                clothingPatterns = context.ClothingPattern.OrderBy(g => g.Name).ToList();
            }

            return clothingPatterns;
        }

        public void Update(Entities.ClothingPattern clothingPatterns)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(clothingPatterns).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}