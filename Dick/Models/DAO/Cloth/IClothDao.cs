using System.Collections.Generic;

namespace Dick.Models.DAO.Cloth
{
    public interface IClothDao
    {
        Entities.Cloth Get(int id);
        List<Entities.Cloth> GetAll();
        void Add(Entities.Cloth cloth);
        void Edit(Entities.Cloth cloth);
        void Delete(Entities.Cloth cloth);
    }
}