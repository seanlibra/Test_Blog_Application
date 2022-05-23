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
    /// <summary>
    /// 作者 api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorRoomService;

        public AuthorController(IAuthorService authorService)
        {
            _authorRoomService = authorService ?? throw new ArgumentNullException(nameof(_authorRoomService));
        }

        // GET: api/<AuthorController>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAuthorDetailAsync(int id)
        {
            var entity = await _authorRoomService.GetAuthorDetailAsync(id);

            return Ok(entity);
        }

        [HttpPost]

        public async Task<IActionResult> CreateAuthorAsync([FromBody] AuthorEditViewModel model )
        {
            await _authorRoomService.CreateAuthorAsync( model.Name, model.Gender);

            return Ok("新增成功");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAuthorAsync(int id, [FromBody] AuthorEditViewModel model)
        {
            await _authorRoomService.UpdateAuthorAsync(id, model.Name, model.Gender);

            return Ok("更新成功");
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAuthorAsync(int id)
        {
            await _authorRoomService.DeleteAuthorAsync(id);
            
            return Ok("刪除成功");
        }
    }
}
