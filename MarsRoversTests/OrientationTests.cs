using System;
using System.Drawing;
using MarsRovers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoversTests
{
    [TestClass]
    public class OrientationTests
    {
        [TestMethod]
        public void Direction_InitialiseNorth_North()
        {
            var test = Orientation.North;
            var expected = test;
            var sut = new Orientation(test);

            var actual = sut.Direction;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Direction_InitialiseEast_East()
        {
            var test = Orientation.East;
            var expected = test;
            var sut = new Orientation(test);

            var actual = sut.Direction;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Direction_InitialiseSouth_South()
        {
            var test = Orientation.South;
            var expected = test;
            var sut = new Orientation(test);

            var actual = sut.Direction;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Direction_InitialiseWest_West()
        {
            var test = Orientation.West;
            var expected = test;
            var sut = new Orientation(test);

            var actual = sut.Direction;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Direction_InitialiseInvalidDirection_ThrowsException()
        {
            var test = "H";
            var sut = new Orientation(test);

            Assert.Fail("Expected thrown ArgumentException");
        }

        [TestMethod]
        [DataRow(Orientation.North, Orientation.Right, Orientation.East)]
        [DataRow(Orientation.North, Orientation.Left, Orientation.West)]
        [DataRow(Orientation.North, Orientation.Move, Orientation.North)]
        [DataRow(Orientation.East, Orientation.Right, Orientation.South)]
        [DataRow(Orientation.East, Orientation.Left, Orientation.North)]
        [DataRow(Orientation.East, Orientation.Move, Orientation.East)]
        [DataRow(Orientation.South, Orientation.Right, Orientation.West)]
        [DataRow(Orientation.South, Orientation.Left, Orientation.East)]
        [DataRow(Orientation.South, Orientation.Move, Orientation.South)]
        [DataRow(Orientation.West, Orientation.Right, Orientation.North)]
        [DataRow(Orientation.West, Orientation.Left, Orientation.South)]
        [DataRow(Orientation.West, Orientation.Move, Orientation.West)]
        public void ExecuteNavigationCommand_DirectionBeforeAndAfterCommand(
            string initial, string navigationCmd, string expected)
        {
            var sut = new Orientation(initial);

            sut.ExecuteNavigationCommand(navigationCmd);
            var actual = sut.Direction;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(Orientation.North, Orientation.Right, 0, 0)]
        [DataRow(Orientation.North, Orientation.Left, 0, 0)]
        [DataRow(Orientation.North, Orientation.Move, 0, 1)]
        [DataRow(Orientation.East, Orientation.Right, 0, 0)]
        [DataRow(Orientation.East, Orientation.Left, 0, 0)]
        [DataRow(Orientation.East, Orientation.Move, 1, 0)]
        [DataRow(Orientation.South, Orientation.Right, 0, 0)]
        [DataRow(Orientation.South, Orientation.Left, 0, 0)]
        [DataRow(Orientation.South, Orientation.Move, 0, -1)]
        [DataRow(Orientation.West, Orientation.Right, 0, 0)]
        [DataRow(Orientation.West, Orientation.Left, 0, 0)]
        [DataRow(Orientation.West, Orientation.Move, -1, 0)]
        public void ExecuteNavigationCommand_IncrementalCoordinates(
            string initial, string navigationCmd, int incrementalX, int incrementalY)
        {
            var sut = new Orientation(initial);
            var expected = new Point(incrementalX, incrementalY);

            var actual = sut.ExecuteNavigationCommand(navigationCmd);

            Assert.AreEqual(expected, actual);
        }
    }
}
