namespace Dick.Models.DAO.Cutter
{
    using System.Collections.Generic;

    using Dick.Models.Entities;

    public interface ICutterDao
    {
        void Add(Cutter cutter);

        void Delete(int id);

        void Edit(Cutter cutter);

        Cutter Load(int id);

        List<Cutter> Load();
    }
}