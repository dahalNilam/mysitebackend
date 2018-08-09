namespace Backend.Controllers
{
    using Backend.Accessors;
    using Backend.BusinessLogic;
    using Backend.Modals;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

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
        public ActionResult<string> Upload()
        {
            var requestFiles = Request.Form.Files;

            if (requestFiles.Count < 1)
            {
                return null;
            }

            var imageFile = requestFiles.FirstOrDefault();

            if (imageFile.Length < 1)
            {
                return null;
            }

            ImageBL.Upload(imageFile);

            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var image = new ImageAccessor(_context).GetById(id);

            return ImageBL.GetImageFile(image);
        }

        [HttpPut("{id}")]
        public ActionResult<Image> Update(int id, [FromBody]Image image)
        {
            return new ImageAccessor(_context).Update(id, image);
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
