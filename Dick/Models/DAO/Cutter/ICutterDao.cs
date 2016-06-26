namespace Dick.Models.DAO.Cutter
{
    public interface ICutterDao
    {
        void Add(Entities.Cutter cutter);
        void Edit(Entities.Cutter cutter);
        void Delete(Entities.Cutter cutter);
    }
}