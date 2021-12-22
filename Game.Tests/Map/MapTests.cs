using Game.Extensions;
using Game.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Tests.Map
{
    [TestClass]
    public class MapTests
    {
        //[TestMethod]
        //public void Constructor_SetCorrectWidth() //MapService
        //{
        //    const int expectedWidth = 10;
        //    const int expectedHeight = 20;
        //    var mapServiceMock = new Mock<IMapService>();

        //    mapServiceMock.Setup(m => m.GetMap()).Returns((expectedWidth, expectedHeight));

        //    var map = new GameWorld.Map(mapServiceMock.Object);

        //    var actual = map.Width;

        //    Assert.AreEqual(expectedWidth, actual);

        //}

        [TestMethod]
        public void Constructor_SetCorrectWidth2() //IConfiguration
        {
            const int expected = 10;
            var configMock = new Mock<IConfiguration>();
            var getMapSizeMock = new Mock<IGetMapSize>();

            getMapSizeMock.Setup(m => m.GetMapSizeFor(configMock.Object, It.IsAny<string>())).Returns(expected);
            ExtentionTestDemo.Implemetation = getMapSizeMock.Object;

            var map = new GameWorld.Map(configMock.Object);

            var actual = map.Width;

            Assert.AreEqual(expected, actual);
        }
    }
}
