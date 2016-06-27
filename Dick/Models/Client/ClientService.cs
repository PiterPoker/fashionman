using Dick.Models.DAO;

namespace Dick.Models.Client
{
    public class ClientService : IClientService
    {
        private readonly IUserDao _userDao;

        private readonly IUserDao _editUserDao;

        public ClientService( IUserDao editUserDao, IUserDao userDao)
        {
            _userDao = userDao;
            _editUserDao = editUserDao;
        }


        public ApplicationUser Get()
        {
            var user = _userDao.GetCurrent();
            return user;
        }

        public void EditUser(ApplicationUser eUsers)
        {
            _editUserDao.Edit(eUsers);
        }
    }
}