using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dick.Models.DAO.Cloth
{
    public class ClothDao : IClothDao
    {
        public Entities.Cloth Get(int id)
        {
            Entities.Cloth cloth;
            using (var context = new ApplicationDbContext())
            {
                cloth = context.Cloth.FirstOrDefault(c => c.Id == id);
            }
            return cloth;
        }

        public List<Entities.Cloth> GetAll()
        {
            List<Entities.Cloth> cloths;
            using (var context = new ApplicationDbContext())
            {
                cloths = context.Cloth.ToList();
            }
            return cloths;
        }

        public void Add(Entities.Cloth cloth)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Cloth.Add(cloth);
                context.SaveChanges();
            }
        }

        public void Delete(Entities.Cloth cloth)
        {
            using (var context = new ApplicationDbContext())
            {
                var deleteItem = context.Cloth.FirstOrDefault(a => a.Id == cloth.Id);
                if (deleteItem == null)
                    return;
                context.Cloth.Remove(deleteItem);
                context.SaveChanges();
            }
        }

        public void Edit(Entities.Cloth cloth)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(cloth).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}