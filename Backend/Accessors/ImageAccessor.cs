namespace Backend.Accessors
{
    using Backend.Accessors.Interfaces;
    using Backend.Modals;
    using System.Collections.Generic;
    using System.Linq;

    public class ImageAccessor : IImage
    {
        public Image Add(Image image)
        {
            _context.Image.Add(image);
            _context.SaveChanges();

            return image;
        }

        public Image GetById(int id)
        {
            return _context.Image.Find(id);
        }

        public Image GetByHash(string hash)
        {
            return _context.Image.FirstOrDefault(p => p.Hash == hash);
        }

        public IEnumerable<Image> GetAll()
        {
            return _context.Image.ToList();
        }

        public Image Update(int id, Image image)
        {
            var itemToUpdate = _context.Image.Find(id);

            itemToUpdate.FileName = image.FileName;
            itemToUpdate.Housing = image.Housing;
            itemToUpdate.HousingId = image.HousingId;
            itemToUpdate.Path = image.Path;

            _context.SaveChanges();

            return image;
        }

        public void Remove(int id)
        {
            _context.Housing.Remove(_context.Housing.Find(id));
            _context.SaveChanges();
        }

        public ImageAccessor(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly ApplicationDbContext _context;
    }
}
