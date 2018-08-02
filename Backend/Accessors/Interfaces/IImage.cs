namespace Backend.Accessors.Interfaces
{
    using Backend.Modals;
    using System.Collections.Generic;

    interface IImage
    {
        Image Add(Image image);

        Image GetById(int id);

        IEnumerable<Image> GetAll();

        Image Update(int id, Image image);

        void Remove(int id);
    }
}
