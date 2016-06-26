namespace Dick.Models.Client
{
    public interface IClientService
    {
        void EditClient(ApplicationUser eUsers);
        void AddClient(ApplicationUser aUsers);
        ApplicationUser Get();
    }
}