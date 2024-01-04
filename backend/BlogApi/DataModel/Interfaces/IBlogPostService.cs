using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.DataModel.Interfaces
{
    public interface IBlogPostService
    {
        Task<BlogPost> Create(BlogPost blogPost);
        Task<BlogPost> Get(int id);
        Task<List<BlogPost>> GetAll();
        Task<BlogPost> Update(int id, BlogPost blogPost);
        Task Delete(int id);
    }
}