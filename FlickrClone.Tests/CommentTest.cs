using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlickrClone.Models;
using Xunit;

namespace FlickrClone.Tests
{
    public class CommentTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            var comment = new Comment();
            comment.Description = "Picture of anything";
            var result = comment.Description;
            Assert.Equal("Picture of anything", result);
        }
    }
}

