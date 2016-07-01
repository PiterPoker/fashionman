namespace Dick.Models.DAO.ClothingPattern
{
    using System.Collections.Generic;

    using Dick.Models.Entities;

    public interface IClothingPatterDao
    {
        void Add(Entities.ClothingPattern clothingpatter);

        void Delete(int id);
        ClothingPattern Load(int id);

        List<ClothingPattern> Load();
        void Update(ClothingPattern clothingpatter);
    }
}