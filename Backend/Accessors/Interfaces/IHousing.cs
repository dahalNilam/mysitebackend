namespace Backend.Accessors.Interfaces
{
    using Backend.Modals;
    using System.Collections.Generic;

    interface IHousing
    {
        Housing Add(Housing housing);

        Housing GetById(int id);

        IEnumerable<Housing> GetAll();

        Housing Update(int id, Housing housing);

        void Remove(int id);
    }
}
