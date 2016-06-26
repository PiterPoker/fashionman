namespace Dick.Models.DAO.Client
{
    public interface IClientDao
    {
        void Add(ApplicationUser Users);
        void Edit(ApplicationUser Users);
        void Delete(ApplicationUser Users);
    }
}