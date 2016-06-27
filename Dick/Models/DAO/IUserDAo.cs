namespace Dick.Models.DAO
{
    public interface IUserDao
    {
        void Edit(ApplicationUser Users);
        ApplicationUser GetCurrent();
    }
}