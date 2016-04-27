using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlickrClone.Models;
using Xunit;

namespace FlickrClone.Tests
{
    public class ImageTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            var image = new Image();
            image.Description = "Picture of anything";
            var result = image.Description;
            Assert.Equal("Picture of anything", result);
        }
    }
}
