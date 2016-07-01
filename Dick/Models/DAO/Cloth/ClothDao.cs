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
                cloths = context.Cloth.OrderBy(g=>g.Name).ToList();
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

        public void Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var item = context.Cloth.Find(id);
                if (item != null)
                {
                    context.Cloth.Remove(item);
                }
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


        public void Update(Entities.Cloth cloth)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(cloth).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}