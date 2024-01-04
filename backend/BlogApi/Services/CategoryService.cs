using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.DataModel;
using BlogApi.DataModel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly Contexto _context;

        public CategoryService(Contexto context)
        {
            _context = context;
        }

        public async Task<Category> Create(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Get(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> Update(int id, Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}