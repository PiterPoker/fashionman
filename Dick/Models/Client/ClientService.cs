using Dick.Models.DAO;
using Dick.Models.DAO.Client;

namespace Dick.Models.Client
{
    public class ClientService : IClientService
    {
        private readonly IClientDao _clientDao;
        private readonly IClientDao _editClientDao;
        private readonly IUserDao _userDao;

        public ClientService(IClientDao clientDao, IClientDao editClientDao, IUserDao userDao)
        {
            _clientDao = clientDao;
            _editClientDao = editClientDao;
            _userDao = userDao;
        }

        public void AddClient(ApplicationUser aUsers)
        {
            _clientDao.Add(aUsers);
        }

        public ApplicationUser Get()
        {
            var user = _userDao.GetCurrent();
            return user;
        }

        public void EditClient(ApplicationUser eUsers)
        {
            _editClientDao.Edit(eUsers);
        }
    }
}