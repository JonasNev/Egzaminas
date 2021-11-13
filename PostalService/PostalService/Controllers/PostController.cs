using Microsoft.AspNetCore.Mvc;
using PostalService.Models;
using PostalService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET: api/Bettor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _postService.GetAllAsync();
        }

        // GET: api/Bettor/5
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

        // PUT: api/Bettor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(Post post)
        {
            await _postService.UpdateAsync(post);

            return NoContent();
        }

        // POST: api/Bettor
        [HttpPost]
        public async Task<ActionResult<Post>> AddPost(Post post)
        {
            await _postService.AddAsync(post);

            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // DELETE: api/Bettor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postService.DeleteAsync(id);

            return NoContent();
        }
    }
}
