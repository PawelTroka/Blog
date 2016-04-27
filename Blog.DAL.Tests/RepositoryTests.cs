using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using Blog.DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using TDD.DbTestHelpers.Core;
using TDD.DbTestHelpers.Yaml;

namespace Blog.DAL.Tests
{
    public class BlogFixtures
 : YamlDbFixture<BlogContext, BlogFixturesModel>
    {
        public BlogFixtures()
        {
            SetYamlFiles("posts.yml");
        }
    }
    public class BlogFixturesModel
    {
        public FixtureTable<Post> Posts { get; set; }
    }

    [TestClass]
    public class RepositoryTests : DbBaseTest<BlogFixtures>
    {
        [TestMethod]
        public void GetAllPost_OnePostInDb_ReturnOnePost()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();

            // -- prepare data in db
          //  context.Posts.ToList().ForEach(x => context.Posts.Remove(x));
          //  context.Posts.Add(new Post
         //   {
       //         Author = "test",
       //         Content = "test, test, test..."
      //      });
    //        context.SaveChanges();

            // act
            var result = repository.GetAllPosts();
            // assert
            Assert.AreEqual(2, result.Count());
        }
    }
}
