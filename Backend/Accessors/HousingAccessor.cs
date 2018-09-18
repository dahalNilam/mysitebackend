namespace Backend.Accessors
{
    using Backend.Accessors.Interfaces;
    using Backend.Modals;
    using Microsoft.EntityFrameworkCore;
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
            return _context.Housing.Include(r => r.Images).ToList();
        }

        public Housing Update(int id, Housing housing)
        {
            _context.Housing.Update(housing);

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
