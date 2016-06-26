using System.Data.Entity;
using System.Linq;

namespace Dick.Models.DAO.Client
{
    public class ClientDao : IClientDao
    {
        public void Add(ApplicationUser client)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Users.Add(client);
                context.SaveChanges();
            }
        }

        public void Delete(ApplicationUser client)
        {
            using (var context = new ApplicationDbContext())
            {
                var deleteItem = context.Users.FirstOrDefault(c => c.Id == client.Id);
                if (deleteItem == null)
                    return;
                context.Users.Remove(deleteItem);
                context.SaveChanges();
            }
        }

        public void Edit(ApplicationUser client)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(client).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}