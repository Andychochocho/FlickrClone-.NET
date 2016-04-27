using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlickrClone.Models;
using Xunit;
using FlickrClone.Models;

namespace FlickrClone.Tests
{
    public class ImageTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            var image = new Image();
            var result = image.Description;
            Assert.Equal("Picture of anything", result);
        }
    }
}
