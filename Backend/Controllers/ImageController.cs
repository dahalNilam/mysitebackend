namespace Backend.Controllers
{
    using Backend.Accessors;
    using Backend.BusinessLogic;
    using Backend.Modals;
    using Backend.Utilities;
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
        public ActionResult<Image> Upload()
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

            var filePath = ImageBL.GetFilePath(imageFile.FileName);

            var hash = ImageUtils.GetHash(filePath);

            var imageAccessor = new ImageAccessor(_context);
            var image = imageAccessor.GetByHash(hash);

            if (image == null)
            {
                ImageBL.Upload(imageFile, filePath);

                image = new Image()
                {
                    FileName = imageFile.FileName,
                    Hash = hash,
                    Path = filePath,
                };
            }

            return Ok(image);
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
