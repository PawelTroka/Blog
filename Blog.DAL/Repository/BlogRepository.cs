using System.Collections.Generic;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using System;

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
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public IEnumerable<Comment> GetAllCommentsForPost(Post post)
        {
            return _context.Posts.Find(post.Id).Comments;
        }

        public void AddComment(Post post, Comment comment)
        {
            _context.Posts.Find(post.Id).Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
