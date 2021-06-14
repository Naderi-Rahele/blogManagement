using BlogManagement.Core.Domain.Comments;
using System.Threading.Tasks;
using BlogManagement.Core.ApplicationServices.Comments;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CommentManagement.Endpoints.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly CommentApplicationService _commentApplicaitonService;

        public CommentsController(CommentApplicationService commentApplicaitonService)
        {
            _commentApplicaitonService = commentApplicaitonService;
        }

        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return _commentApplicaitonService.Get();
        }
        [HttpGet("{id}")]
        public Comment Get(int id)
        {
            return _commentApplicaitonService.Get(id);
        }

        [HttpPost]
        public IActionResult Add(AddCommentCommand CommentForAdd)
        {
            _commentApplicaitonService.Add(CommentForAdd);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _commentApplicaitonService.Remove(id);
            return NoContent();
        }
    }
}
