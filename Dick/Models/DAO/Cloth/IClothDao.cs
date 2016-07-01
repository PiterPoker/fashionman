using System.Collections.Generic;

namespace Dick.Models.DAO.Cloth
{
    public interface IClothDao
    {
        void Add(Entities.Cloth cloth);
        void Delete(int id);
        void Edit(Entities.Cloth cloth);
        Entities.Cloth Get(int id);
        List<Entities.Cloth> GetAll();

        void Update(Entities.Cloth cloth);
    }
}