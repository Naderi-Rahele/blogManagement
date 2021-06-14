
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using BlogManagement.Core.ApplicationServices.Posts;
using BlogManagement.Core.Domain.Posts;

namespace PostManagement.Endpoints.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly PostApplicationService _postApplicaitonService;

        public PostsController(PostApplicationService postApplicaitonService)
        {
            _postApplicaitonService = postApplicaitonService;
        }

        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _postApplicaitonService.Get();
        }
        
        [HttpGet("{id}")]
        public PostCommentModel Get(int id)
        {
            return _postApplicaitonService.Get(id);
        }

        [HttpPost]
        public IActionResult Add(AddPostCommand PostForAdd)
        {
            _postApplicaitonService.Add(PostForAdd);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _postApplicaitonService.Remove(id);
            return NoContent();
        }
    }
}
