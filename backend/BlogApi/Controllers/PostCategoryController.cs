using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.DataModel;
using BlogApi.DataModel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostCategoryController : ControllerBase
    {
        private readonly IPostCategoryService _postCategoryService;

        public PostCategoryController(IPostCategoryService postCategoryService)
        {
            _postCategoryService = postCategoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostCategory postCategory)
        {
            var newPostCategory = await _postCategoryService.Create(postCategory);
            return CreatedAtAction(nameof(Get), new { postId = newPostCategory.PostId, categoryId = newPostCategory.CategoryId }, newPostCategory);
        }

        [HttpGet("{postId}/{categoryId}")]
        public async Task<IActionResult> Get(int postId, int categoryId)
        {
            var postCategory = await _postCategoryService.Get(postId, categoryId);
            if (postCategory == null)
            {
                return NotFound();
            }
            return Ok(postCategory);
        }

        [HttpGet("post/{postId}")]
        public async Task<IActionResult> GetAllByPost(int postId)
        {
            var postCategories = await _postCategoryService.GetAllByPost(postId);
            return Ok(postCategories);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetAllByCategory(int categoryId)
        {
            var postCategories = await _postCategoryService.GetAllByCategory(categoryId);
            return Ok(postCategories);
        }

        [HttpDelete("{postId}/{categoryId}")]
        public async Task<IActionResult> Delete(int postId, int categoryId)
        {
            await _postCategoryService.Delete(postId, categoryId);
            return NoContent();
        }
    }
}