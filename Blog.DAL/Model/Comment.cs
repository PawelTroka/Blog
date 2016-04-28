using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.DAL.Model
{


    public class Comment
    {
        [Key]
        public long Id { get; set; }

        //[ForeignKey("Post")]
        public long PostId { get; set; }

        [Required, MinLength(3), MaxLength(3000)]
        public string Content { get; set; }
        [Required, MinLength(2),MaxLength(100)]
        public string Author { get; set; }


        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
    }
}