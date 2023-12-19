using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.DataModel
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property
        public List<PostCategory> PostCategories { get; set; }

    }
}