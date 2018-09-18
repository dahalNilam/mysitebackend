namespace Backend.Accessors.Interfaces
{
    using Backend.Modals;
    using System.Collections.Generic;

    interface IImage
    {
        Image Add(Image image);

        Image GetById(int id);

        Image GetByHash(string hash);

        IEnumerable<Image> GetAll();

        Image Update(int id, Image image);

        void Remove(int id);
    }
}
