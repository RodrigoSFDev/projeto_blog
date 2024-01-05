using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BlogApi.DataModel
{
    public class User : IdentityUser<int>
    {
        override public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[]? Image { get; set; }

        // Navigation property
        public List<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();

        public void SetImage(byte[] imageBytes)
        {
            Image = imageBytes;
        }
    }
}