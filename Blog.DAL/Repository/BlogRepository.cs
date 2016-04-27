using System.Collections.Generic;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Blog.DAL.Repository
{
    public class BlogRepository
    {
        private readonly BlogContext _context;

        public BlogRepository()
        {
            _context = new BlogContext();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts;
        }

        public void AddPost(Post post)
        {
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(post, new ValidationContext(post, serviceProvider: null, items: null), results))
                throw new ValidationException(results.First()?.ErrorMessage);

            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public IEnumerable<Comment> GetAllCommentsForPost(Post post)
        {
            return _context.Posts.Find(post.Id).Comments;
        }

        public void AddComment(Post post, Comment comment)
        {
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(comment, new ValidationContext(comment, serviceProvider: null, items: null), results))
                throw new ValidationException(results.First()?.ErrorMessage);

            _context.Posts.Find(post.Id).Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
