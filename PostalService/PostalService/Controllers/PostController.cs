using Microsoft.AspNetCore.Mvc;
using PostalService.Models;
using PostalService.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _postService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var bettor = await _postService.GetByIdAsync(id);

            if (bettor == null)
            {
                return NotFound();
            }

            return bettor;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(Post post)
        {
            await _postService.UpdateAsync(post);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Post>> AddPost(Post post)
        {
            await _postService.AddAsync(post);

            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postService.DeleteAsync(id);

            return NoContent();
        }
    }
}
