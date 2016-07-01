using System.Collections.Generic;

namespace Dick.Models.DAO.Order
{
    public interface IOrderDao
    {
        void Add(Entities.Order order);
        void Edit(Entities.Order order);
        void Delete(int id);
        Entities.Order Load(int id);
        List<Entities.Order> Load();
    }
}