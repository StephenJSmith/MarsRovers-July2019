using System.Drawing;
using MarsRovers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoversTests
{
    [TestClass]
    public class MarsRoversTests
    {
        [TestMethod]
        public void Position_InitialPosition_InitialPosition()
        {
            var test = new Point(5, 7);
            var orientation = new Orientation(Orientation.North);
            var cmds = string.Empty;
            var expected = test;

            var sut = new MarsRover(test, orientation, cmds);
            var actual = sut.Position;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Position_TurnRight_InitialPosition()
        {
            var test = new Point(5, 7);
            var orientation = new Orientation(Orientation.North);
            var cmds = "R";
            var expected = test;

            var sut = new MarsRover(test, orientation, cmds);
            var actual = sut.Position;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Position_TurnLeft_InitialPosition()
        {
            var test = new Point(5, 7);
            var orientation = new Orientation(Orientation.North);
            var cmds = "L";
            var expected = test;

            var sut = new MarsRover(test, orientation, cmds);
            var actual = sut.Position;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Position_FacingNorthMove_IncrementY()
        {
            var test = new Point(5, 7);
            var orientation = new Orientation(Orientation.North);
            var cmds = "M";
            var expected = new Point(5, 8);

            var sut = new MarsRover(test, orientation, cmds);
            var actual = sut.Position;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(5, 7, Orientation.North, Orientation.Move, 5, 8)]
        [DataRow(5, 7, Orientation.East, Orientation.Move, 6, 7)]
        [DataRow(5, 7, Orientation.South, Orientation.Move, 5, 6)]
        [DataRow(5, 7, Orientation.West, Orientation.Move, 4, 7)]
        public void Position_InitialPositionAndDirectionThenMove_ResultingPosition(
            int x0, int y0, string direction, string navigation, int x1, int y1)
        {
            var initialPosition = new Point(x0, y0);
            var orientation = new Orientation(direction);
            var expected = new Point(x1, y1);

            var sut = new MarsRover(initialPosition, orientation, navigation);
            var actual = sut.Position;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Orientation_InitialNorthThenLeftTwice_South()
        {
            var initialPosition = new Point(5, 7);
            var orientation = new Orientation(Orientation.North);
            var cmds = $"{Orientation.Left}{Orientation.Left}";
            var expected = Orientation.South;

            var sut = new MarsRover(initialPosition, orientation, cmds);
            var actual = sut.Orientation;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Position_MultipleNavigationCommands_ExpectedPosition()
        {
            var initialPosition = new Point(1, 2);
            var orientation = new Orientation(Orientation.North);
            const string cmds = "LMLMLMLMM";
            var expected = new Point(1, 3);

            var sut = new MarsRover(initialPosition, orientation, cmds);
            var actual = sut.Position;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Orientation_MultipleNavigationCommands_ExpectedOrientation()
        {
            var initialPosition = new Point(1, 2);
            var orientation = new Orientation(Orientation.North);
            const string cmds = "LMLMLMLMM";
            var expected = Orientation.North;

            var sut = new MarsRover(initialPosition, orientation, cmds);
            var actual = sut.Orientation;

            Assert.AreEqual(expected, actual);
        }
    }
}
