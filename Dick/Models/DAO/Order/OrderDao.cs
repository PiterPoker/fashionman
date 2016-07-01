using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dick.Models.DAO.Order
{
    public class OrderDao : IOrderDao
    {
        public void Add(Entities.Order order)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Order.Add(order);
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

        public void Edit(Entities.Order order)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(order).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Entities.Order Load(int id)
        {
            Entities.Order order;
            using (var context = new ApplicationDbContext())
            {
                order = context.Order.FirstOrDefault(c => c.Id == id);
            }
            return order;
        }

        public List<Entities.Order> Load()
        {
            List<Entities.Order> order;
            using (var context = new ApplicationDbContext())
            {
                order = context.Order.OrderBy(g => g.Id).ToList();
            }
            return order;
        }
    }
}