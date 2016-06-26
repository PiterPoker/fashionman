using System.Web;
using Microsoft.AspNet.Identity;

namespace Dick.Models.DAO
{
    public class UserDao : IUserDao
    {
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