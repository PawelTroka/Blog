﻿using System;
using System.ComponentModel.DataAnnotations;
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

namespace Blog.DAL.Tests
{
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

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void AddPostWithoutAuthor_ShouldThrowException()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();

            repository.AddPost(new Post() { Content = "lalala" });
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void AddPostWithoutContent_ShouldThrowException()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();

            repository.AddPost(new Post() { Author = "lalala" });

        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void AddCommentWithoutContent_ShouldThrowException()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();

            repository.AddComment(repository.GetAllPosts().First(), new Comment() { Author = "aaaa" });

        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void AddCommentWithoutAuthor_ShouldThrowException()
        {

            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            var repository = new BlogRepository();

            repository.AddComment(repository.GetAllPosts().First(), new Comment() { Content = "aaaa" });

        }
    }
}
