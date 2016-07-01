using System.Data.Entity;
using System.Linq;

namespace Dick.Models.DAO.Cutter
{
    using System.Collections.Generic;

    using Dick.Models.Entities;

    public class CutterDao : ICutterDao
    {
        public void Add(Entities.Cutter cutter)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Cutter.Add(cutter);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var item = context.Cutter.Find(id);
                if (item != null)
                {
                    context.Cutter.Remove(item);
                }
                context.SaveChanges();
            }
        }

        public void Edit(Entities.Cutter cutter)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(cutter).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public Cutter Load(int id)
        {
            Cutter cutter;
            using (var context = new ApplicationDbContext())
            {
                cutter = context.Cutter.FirstOrDefault(c => c.Id == id);
            }
            return cutter;
        }

        public List<Cutter> Load()
        {
            List<Cutter> cutters;
            using (var context = new ApplicationDbContext())
            {
                cutters = context.Cutter.OrderBy(g => g.FirstName).ToList();
            }
            return cutters;
        }
    }
}