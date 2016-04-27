using System.Data.Entity;
using System.Data.Entity.Migrations;
using Blog.DAL.Model;

namespace Blog.DAL.Infrastructure
{
    public class BlogContext : DbContext
    {
        public IDbSet<Post> Posts { get; set; }

        public BlogContext() : base("Blog")
        {
            Database.SetInitializer<BlogContext>(null);
        }
    }
}
