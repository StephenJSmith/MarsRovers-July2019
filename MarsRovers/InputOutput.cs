using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MarsRovers
{
    public class InputOutput
    {
        private readonly string _input;
        private IList<string> _inputLines = new List<string>();
        private IList<MarsRover> _marsRovers = new List<MarsRover>();
        private Point _boundaryCoordinates = new Point(0,0);

        public InputOutput(string input)
        {
            _input = input;
            ExecuteCommands();
        }

        private void ExecuteCommands()
        {
            var lines = _input.Split(
                new[] {Environment.NewLine}, 
                StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length == 0)
            {
                throw new ArgumentException("No input entered");
            }

            _inputLines = lines;
            ExtractBoundaryPoint();
            ExtractRoversCommands();
        }

        private void ExtractBoundaryPoint()
        {
            var firstLine = _inputLines.FirstOrDefault();
            if (firstLine == null)
            {
                throw new ArgumentException("No Boundary Coordinates entered");
            }

            var coords = firstLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (coords.Length != 2)
            {
                throw new ArgumentException("The first line must consist of X Y Boundary Coordinates");
            }

            if (!int.TryParse(coords.First(), out int x)
                || !int.TryParse(coords.Last(), out int y))
            {
                throw  new ArgumentException( "Valid X Y Boundary Coordinates NOT found");
            }

            if (x <= 0 || y <= 0)
            {
                throw new ArgumentException("Valid X Y Boundary Coordinates MUST both be positive numbers");
            }

            _boundaryCoordinates = new Point(x, y);

        }

        private void ExtractRoversCommands()
        {
            if (_inputLines.Count % 2 != 1)
            {
                throw new ArgumentException("Must be a pair of command lines for each Mars Rover");
            }

            for (int i = 1; i < _inputLines.Count; i+=2)
            {
                InitialiseRover(_inputLines[i], _inputLines[i + 1]);    
            }
        }

        private void InitialiseRover(string initialPositionLine, string navigationCommandsLine)
        {
            var initialPosition = GetCoordinates(initialPositionLine);
            var initialDirection = GetInitialDirection(initialPositionLine);
            var orientation = new Orientation(initialDirection);
            var rover = new MarsRover(initialPosition, orientation, navigationCommandsLine);

            _marsRovers.Add(rover);
        }

        private Point GetCoordinates(string initialPositionLine)
        {
            var items = initialPositionLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int.TryParse(items[0], out int x);
            int.TryParse(items[1], out int y);

            return new Point(x, y);
        }

        private string GetInitialDirection(string initialPositionLine)
        {
            var items = initialPositionLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            return items[2];
        }

        public Point GetBoundaryCoordinates()
        {
            return _boundaryCoordinates;
        }

        public IList<MarsRover> GetMarsRovers()
        {
            return _marsRovers;
        }

        public string GetOutput()
        {
            var sb = new StringBuilder();
            foreach (var rover in _marsRovers)
            {
                sb.AppendFormat("{0} {1} {2}{3}",
                    rover.Position.X, rover.Position.Y, rover.Orientation,
                    Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
