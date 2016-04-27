using System.ComponentModel.DataAnnotations;

namespace Blog.DAL.Model
{
    public class Post
    {
        [Key]
        public long Id { get; set; }

        [Required,MaxLength(100000)]
        public string Content { get; set; }
        [Required,MaxLength(100)]
        public string Author { get; set; }
    }
}
