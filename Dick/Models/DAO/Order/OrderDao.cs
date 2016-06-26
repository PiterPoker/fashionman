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

        public void Delete(Entities.Order order)
        {
            using (var context = new ApplicationDbContext())
            {
                var deleteItem = context.Order.FirstOrDefault(a => a.Id == order.Id);
                if (deleteItem == null)
                    return;
                context.Order.Remove(deleteItem);
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
    }
}