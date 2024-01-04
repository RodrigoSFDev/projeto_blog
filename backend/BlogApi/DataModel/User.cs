using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.DataModel
{
    public class User
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[]? Image { get; set; }

        // Navigation property
        public List<BlogPost> BlogPosts { get; set; }

        public void SetImage(byte[] imageBytes)
        {
            Image = imageBytes;
        }
    }
}