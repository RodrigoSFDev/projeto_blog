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
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;

    public BlogPostController(IBlogPostService blogPostService)
    {
        _blogPostService = blogPostService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(BlogPost blogPost)
    {
        var newBlogPost = await _blogPostService.Create(blogPost);
        return CreatedAtAction(nameof(Get), new { id = newBlogPost.Id }, newBlogPost);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var blogPost = await _blogPostService.Get(id);
        if (blogPost == null)
        {
            return NotFound();
        }
        return Ok(blogPost);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var blogPosts = await _blogPostService.GetAll();
        return Ok(blogPosts);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, BlogPost blogPost)
    {
        if (id != blogPost.Id)
        {
            return BadRequest();
        }
        var updatedBlogPost = await _blogPostService.Update(id, blogPost);
        return Ok(updatedBlogPost);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _blogPostService.Delete(id);
        return NoContent();
    }
    }
}