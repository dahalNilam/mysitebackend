namespace Backend.Accessors
{
    using Backend.Accessors.Interfaces;
    using Backend.Modals;
    using System.Collections.Generic;
    using System.Linq;

    public class HousingAccessor : IHousing
    {
        public Housing Add(Housing housing)
        {
            _context.Housing.Add(housing);
            _context.SaveChanges();

            return housing;
        }

        public Housing GetById(int id)
        {
            return _context.Housing.Find(id);
        }

        public IEnumerable<Housing> GetAll()
        {
            return _context.Housing.ToList();
        }

        public Housing Update(int id, Housing housing)
        {
            var itemToUpdate = _context.Housing.Find(id);

            itemToUpdate.Price = housing.Price;
            itemToUpdate.Type = housing.Type;
            itemToUpdate.NumberOfBedroom = housing.NumberOfBedroom;
            itemToUpdate.NumberOfBathroom = housing.NumberOfBathroom;
            itemToUpdate.Description = housing.Description;

            _context.SaveChanges();

            return housing;
        }

        public void Remove(int id)
        {
            _context.Housing.Remove(_context.Housing.Find(id));
            _context.SaveChanges();
        }

        public HousingAccessor(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly ApplicationDbContext _context;
    }
}
