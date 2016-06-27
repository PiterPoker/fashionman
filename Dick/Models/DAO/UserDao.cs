using System.Web;
using Microsoft.AspNet.Identity;

namespace Dick.Models.DAO
{
    using System.Data.Entity;

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
    }
}