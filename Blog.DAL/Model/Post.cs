using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.DAL.Model
{
    public class Post
    {
        [Key]
        public long Id { get; set; }

        [Required, MinLength(5), MaxLength(100000)]
        public string Content { get; set; }
        [Required,MinLength(2),MaxLength(100)]
        public string Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
