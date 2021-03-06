﻿namespace Backend.Controllers
{
    using Backend.Accessors;
    using Backend.Modals;
    using Backend.Modals.TransientModals;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class HousingController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Housing>> GetAll()
        {

            return Ok(new HousingAccessor(_context).GetAll());
        }

        [HttpPost]
        public ActionResult<Housing> Add([FromBody] HousingTM housingTM)
        {
            var housing = new Housing()
            {
                Type = housingTM.Type,
                Description = housingTM.Description,
                Images = housingTM.Images,
                NumberOfBathroom = housingTM.NumberOfBathroom,
                NumberOfBedroom = housingTM.NumberOfBedroom,
                Price = housingTM.Price,
            };

            return new HousingAccessor(_context).Add(housing);
        }

        [HttpGet("{id}")]
        public ActionResult<Housing> GetById(int id)
        {
            return new HousingAccessor(_context).GetById(id);
        }

        [HttpPut("{id}")]
        public ActionResult<Housing> Update(int id, [FromBody]Housing housing)
        {
            return Ok(new HousingAccessor(_context).Update(id, housing));
        }

        [HttpDelete]
        public ActionResult Remove([FromBody]int id)
        {
            new HousingAccessor(_context).Remove(id);

            return Ok();
        }

        public HousingController(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly ApplicationDbContext _context;
    }
}
