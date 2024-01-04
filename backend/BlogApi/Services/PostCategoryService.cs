using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.DataModel;
using BlogApi.DataModel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Services
{
    public class PostCategoryService : IPostCategoryService
    {
        private readonly Contexto _context;

        public PostCategoryService(Contexto context)
        {
            _context = context;
        }

        public async Task<PostCategory> Create(PostCategory postCategory)
        {
            _context.PostCategories.Add(postCategory);
            await _context.SaveChangesAsync();
            return postCategory;
        }

        public async Task<PostCategory> Get(int postId, int categoryId)
        {
            return await _context.PostCategories.FirstOrDefaultAsync(pc => pc.PostId == postId && pc.CategoryId == categoryId);
        }

        public async Task<List<PostCategory>> GetAllByPost(int postId)
        {
            return await _context.PostCategories.Where(pc => pc.PostId == postId).ToListAsync();
        }

        public async Task<List<PostCategory>> GetAllByCategory(int categoryId)
        {
            return await _context.PostCategories.Where(pc => pc.CategoryId == categoryId).ToListAsync();
        }

        public async Task Delete(int postId, int categoryId)
        {
            var postCategory = await _context.PostCategories.FirstOrDefaultAsync(pc => pc.PostId == postId && pc.CategoryId == categoryId);
            if (postCategory != null)
            {
                _context.PostCategories.Remove(postCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}