using System;
using System.Drawing;
using MarsRovers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoversTests
{
    [TestClass]
    public class InputTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBoundaryCoordinates_NoBoundaryCoordinatesEntered_ThrowException()
        {
            var sut = new InputOutput("");

            Assert.Fail("Expected Argument Exception");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBoundaryCoordinates_InvalidBoundaryCoordinatesEntered_ThrowException()
        {
            var sut = new InputOutput("GRID BOUNDARY");

            Assert.Fail("Expected Argument Exception");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBoundaryCoordinates_ZeroXYCoordinatesEntered_ThrowException()
        {
            var sut = new InputOutput("0 0");

            Assert.Fail("Expected Argument Exception");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBoundaryCoordinates_ANegativeXYCoordinatesEntered_ThrowException()
        {
            var sut = new InputOutput("5 -10");

            Assert.Fail("Expected Argument Exception");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBoundaryCoordinates_MoreThan2XYCoordinatesEntered_ThrowException()
        {
            var sut = new InputOutput("5 10 3");

            Assert.Fail("Expected Argument Exception");
        }

        [TestMethod]
        public void GetBoundaryCoordinates_ValidXYCoordinatesEntered_ReturnsXY()
        {
            var expected = new Point(7, 6);
            var test = "7 6";
            var sut = new InputOutput(test);

            var actual = sut.GetBoundaryCoordinates();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetMarsRovers_InvalidNrInputLines_ThrowException()
        {
            var test = @"7 6
1 2 N";
            var sut = new InputOutput(test);

            Assert.Fail("Expected Argument Exception");
        }

        [TestMethod]
        public void GetMarsRovers_OneValidInputAndEmptyLines_OneMarsRover()
        {
            var test = @"5 5
1 2 N
LMLMLMLMM


";
            var expectedCount = 1;
            var sut = new InputOutput(test);

            var actual = sut.GetMarsRovers();


            Assert.AreEqual(expectedCount, actual.Count);
        }

        [TestMethod]
        public void GetMarsRovers_OneValidInput_OneMarsRover()
        {
            var test = @"5 5
1 2 N
LMLMLMLMM";
            var expectedCount = 1;
            var sut = new InputOutput(test);

            var actual = sut.GetMarsRovers();


            Assert.AreEqual(expectedCount, actual.Count);
        }

        [TestMethod]
        public void GetMarsRovers_TwoValidInput_TwoMarsRovers()
        {
            var test = @"5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
";
            var expectedCount = 2;
            var sut = new InputOutput(test);

            var actual = sut.GetMarsRovers();


            Assert.AreEqual(expectedCount, actual.Count);
        }

        [TestMethod]
        public void GetMarsRovers_OneValidRoverInput_ExpectedOutput()
        {
            var test = @"5 5
1 2 N
LMLMLMLMM";
            var expected = @"1 3 N
";

            var sut = new InputOutput(test);

            var actual = sut.GetOutput();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMarsRovers_TwoValidRoversInput_ExpectedOutput()
        {
            var test = @"5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
";
            var expected = @"1 3 N
5 1 E
";

            var sut = new InputOutput(test);

            var actual = sut.GetOutput();

            Assert.AreEqual(expected, actual);
        }
    }
}
