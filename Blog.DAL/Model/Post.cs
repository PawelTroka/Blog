using System.Collections.Generic;
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

        public virtual ICollection<Comment> Comments { get; set; }
    }

    public class Comment
    {
        [Key]
        public long Id { get; set; }
        [Required, MaxLength(3000)]
        public string Content { get; set; }
        [Required, MaxLength(100)]
        public string Author { get; set; }

        public virtual Post Post { get; set; }
    }
}
