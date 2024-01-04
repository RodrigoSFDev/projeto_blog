using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.DataModel.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> Create(Category category);
        Task<Category> Get(int id);
        Task<List<Category>> GetAll();
        Task<Category> Update(int id, Category category);
        Task Delete(int id);
    }
}