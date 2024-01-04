using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.DataModel;
using BlogApi.DataModel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Services
{
    public class BlogPostService : IBlogPostService
    {
        
    private readonly Contexto _context;

    public BlogPostService(Contexto context)
    {
        _context = context;
    }

    public async Task<BlogPost> Create(BlogPost blogPost)
    {
        _context.BlogPosts.Add(blogPost);
        await _context.SaveChangesAsync();
        return blogPost;
    }

    public async Task<BlogPost> Get(int id)
    {
        return await _context.BlogPosts.FindAsync(id);
    }

    public async Task<List<BlogPost>> GetAll()
    {
        return await _context.BlogPosts.ToListAsync();
    }

    public async Task<BlogPost> Update(int id, BlogPost blogPost)
    {
        _context.Entry(blogPost).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return blogPost;
    }

    public async Task Delete(int id)
    {
        var blogPost = await _context.BlogPosts.FindAsync(id);
        if (blogPost != null)
        {
            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();
        }
    }
    }
}