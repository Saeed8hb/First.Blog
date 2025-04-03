using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.DataLayer.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Slug { get; set; }
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
