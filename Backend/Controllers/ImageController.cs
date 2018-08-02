namespace Backend.Controllers
{
    using Backend.Accessors;
    using Backend.Modals;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

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
        public async Task<IActionResult> GetBtId(int id)
        {
            var image = new ImageAccessor(_context).GetById(id);

            var filePath = $@"E:\Projects\MySite\Images\" + image.FileName;

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, "image/jpg", Path.GetFileName(filePath));
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
