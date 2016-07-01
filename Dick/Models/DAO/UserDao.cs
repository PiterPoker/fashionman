using System.Web;
using Microsoft.AspNet.Identity;

namespace Dick.Models.DAO
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class UserDao : IUserDao
    {
        public void Edit(ApplicationUser user)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public ApplicationUser GetCurrent()
        {
            ApplicationUser user;
            using (var context = new ApplicationDbContext())
            {
                user = context.Users.Find(HttpContext.Current.User.Identity.GetUserId());
            }
            return user;
        }

        public List<ApplicationUser> Load()
        {
            List<ApplicationUser> user;
            using (var context = new ApplicationDbContext())
            {
                user = context.Users.OrderBy(g => g.Id).ToList();
            }
            return user;
        }


        public ApplicationUser Load(int id)
        {
            ApplicationUser user;
            using (var context = new ApplicationDbContext())
            {
                user = context.Users.Find(HttpContext.Current.User.Identity.GetUserId());
            }
            return user;
        }
    }
}