namespace Dick.Models.Client
{
    public interface IClientService
    {
        void EditUser(ApplicationUser eUsers);
        ApplicationUser Get();
    }
}