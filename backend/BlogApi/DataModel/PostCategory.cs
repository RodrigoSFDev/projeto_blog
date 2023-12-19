using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.DataModel
{
    public class PostCategory
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }

        // Navigation properties
        public BlogPost Post { get; set; }
        public Category Category { get; set; }
        }
}