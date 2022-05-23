using BLOG_CMS.ViewModel;
using BLOG_LIB.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BLOG_CMS.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _PostService;

        public PostController(IPostService postService)
        {
            _PostService = postService ?? throw new ArgumentNullException(nameof(_PostService));
        }


        // GET: api/<PostController>
        [HttpGet]
        public async Task<IActionResult> GetPostListAsync(int id)
        {
            var entities = await _PostService.GetAllPostAsync();

            return Ok(entities);
        }


        [HttpPost]
        public async Task<IActionResult> CreatePostAsync([FromBody] PostEditViewModel model)
        {
            await _PostService.CreatePostAsync(model.Title, model.Content, model.AuthorId);

            return Ok("新增成功");
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthorAsync(int id, [FromBody] PostEditViewModel model)
        {
            await _PostService.UpdatePostAsync(id, model.Title, model.Content, model.AuthorId);

            return Ok("更新成功");
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostAsync(int id)
        {
            await _PostService.DeletePostAsync(id);

            return Ok("刪除成功");
        }
    }
}
