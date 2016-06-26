namespace Dick.Models.DAO.ClothingPattern
{
    public interface IClothingPatterDao
    {
        void Add(Entities.ClothingPattern clothingpatter);
        void Edit(Entities.ClothingPattern clothingpatter);
        void Delete(Entities.ClothingPattern clothingpatter);
    }
}