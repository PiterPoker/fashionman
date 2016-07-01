namespace Dick.Models.DAO.Client
{
    public interface IClientDao
    {
        void Add(ApplicationUser user);
        void Edit(ApplicationUser users);
        void Delete(ApplicationUser users);
    }
}