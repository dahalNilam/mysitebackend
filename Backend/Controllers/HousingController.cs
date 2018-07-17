namespace Backend.Controllers
{
    using Backend.Modals;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/[controller]")]
    [ApiController]
    public class HousingController : ControllerBase
    {
        public HousingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Housing>> GetAll()
        {
            _context.Housing.Add(new Housing()
            {
                Id = 5,
                Price = 90,
            });
            _context.SaveChanges();

            var data = _context.Housing.ToList();

            return Ok(data);
        }

        private readonly ApplicationDbContext _context;
    }
}
