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
        public FixtureTable<Comment> Comments { get; set; }
    }

    [TestClass]
    public class RepositoryTests : DbBaseTest<BlogFixtures>
    {
        [TestMethod]
        public void GetAllPost_TwoPostsInDb_ReturnTwoPosts()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();

            // act
            var result = repository.GetAllPosts();
            // assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void AddPost_OneMorePostInDb_ReturnOneMorePost()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();


            // act
            var numberOfPosts = repository.GetAllPosts().Count();
            repository.AddPost(new Post() {Author = "Gen",Content = "lalala"});
            var newNumberOfPosts = repository.GetAllPosts().Count();
            // assert
            Assert.AreEqual(newNumberOfPosts, numberOfPosts+1);
        }



        [TestMethod]
        public void GetAllCommentsForFirstPost_OneCommentInDb_ReturnOneComment()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();

            // act
            var result = repository.GetAllCommentsForPost(repository.GetAllPosts().First()).Count();
            
            // assert
            Assert.AreEqual(1, result);
        }


        [TestMethod]
        public void GetAllCommentsForLastPost_OneCommentInDb_ReturnZeroComments()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();

            // act
            var result = repository.GetAllCommentsForPost(repository.GetAllPosts().Last()).Count();

            // assert
            Assert.AreEqual(0, result);
        }
    }
}
