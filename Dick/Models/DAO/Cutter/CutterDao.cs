using System.Data.Entity;
using System.Linq;

namespace Dick.Models.DAO.Cutter
{
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

        public void Delete(Entities.Cutter cutter)
        {
            using (var context = new ApplicationDbContext())
            {
                var deleteItem = context.Cutter.FirstOrDefault(a => a.Id == cutter.Id);
                if (deleteItem == null)
                    return;
                context.Cutter.Remove(deleteItem);
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
    }
}