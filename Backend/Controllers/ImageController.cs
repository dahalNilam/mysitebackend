namespace Backend.Controllers
{
    using Backend.Accessors;
    using Backend.BusinessLogic;
    using Backend.Modals;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Image>> GetAll()
        {
            var all = new ImageAccessor(_context).GetAll();

            return Ok(all);
        }

        [HttpPost]
        public ActionResult<Image> Add([FromBody]Image image)
        {
            return new ImageAccessor(_context).Add(image);
        }

        [HttpGet("{id}")]
        public ActionResult GetBtId(int id)
        {
            var image = new ImageAccessor(_context).GetById(id);

            return ImageBL.GetImageFile(image);
        }

        [HttpPut("{id}")]
        public ActionResult<Image> Update(int id, [FromBody]Image image)
        {
            return Ok(new ImageAccessor(_context).Update(id, image));
        }

        [HttpDelete]
        public ActionResult Remove([FromBody]int id)
        {
            new ImageAccessor(_context).Remove(id);

            return Ok();
        }

        public ImageController(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly ApplicationDbContext _context;
    }
}
