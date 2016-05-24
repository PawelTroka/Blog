using System.Data.Entity;
using Blog.DAL.Model;

namespace Blog.DAL.Infrastructure
{
    public class BlogContext : DbContext
    {
        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public BlogContext() : base("Blog")
        {
            //     Database.SetInitializer<BlogContext>(null);
            // Database.SetInitializer<BlogContext>(new DropCreateDatabaseIfModelChanges<BlogContext>());
            //DropCreateDatabaseAlways
            //Database.SetInitializer<BlogContext>(new DropCreateDatabaseAlways<BlogContext>());
            //Database.SetInitializer<BlogContext>(new CreateDatabaseIfNotExists<BlogContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BlogContext>(new DropCreateDatabaseIfModelChanges<BlogContext>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
