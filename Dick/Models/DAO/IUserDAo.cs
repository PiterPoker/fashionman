namespace Dick.Models.DAO
{
    using System.Collections.Generic;

    public interface IUserDao
    {
        void Edit(ApplicationUser Users);
        ApplicationUser GetCurrent();
        List<ApplicationUser> Load();
        ApplicationUser Load(int id);
    }
}