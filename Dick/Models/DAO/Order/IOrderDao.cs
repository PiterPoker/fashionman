namespace Dick.Models.DAO.Order
{
    public interface IOrderDao
    {
        void Add(Entities.Order order);
        void Edit(Entities.Order order);
        void Delete(Entities.Order order);
    }
}