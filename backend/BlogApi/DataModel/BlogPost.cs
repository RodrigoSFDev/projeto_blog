using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.DataModel
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime Published { get; set; }
        public DateTime Updated { get; set; }

        // Navigation properties
        public User User { get; set; }
        public List<PostCategory> PostCategories { get; set; }
    }
}