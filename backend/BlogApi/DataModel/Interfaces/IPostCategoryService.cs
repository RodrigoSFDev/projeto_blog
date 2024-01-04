using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.DataModel.Interfaces
{
    public interface IPostCategoryService
    {
        Task<PostCategory> Create(PostCategory postCategory);
        Task<PostCategory> Get(int postId, int categoryId);
        Task<List<PostCategory>> GetAllByPost(int postId);
        Task<List<PostCategory>> GetAllByCategory(int categoryId);
        Task Delete(int postId, int categoryId);
    }
}