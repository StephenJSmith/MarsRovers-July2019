using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRovers
{
    public class Orientation
    {
        public const string North = "N";
        public const string East = "E";
        public const string South = "S";
        public const string West = "W";


        public const string Left = "L";
        public const string Right = "R";
        public const string Move = "M";

        public string Direction { get; private set; }

        private IList<string> _directions = new List<string>
        {
            Orientation.North,
            Orientation.East,
            Orientation.South,
            Orientation.West
        };

        public Orientation(string direction)
        {
            if (!IsValidDirection(direction))
            {
                throw new ArgumentException("Invalid initial orientation entered");

            }

            Direction = direction;
        }

        private bool IsValidDirection(string direction)
        {
            if (string.IsNullOrWhiteSpace(direction))
            {
                return false;
            }

            if (direction == Orientation.North 
                || direction == Orientation.East
                || direction == Orientation.South
                || direction == Orientation.West)
            {
                return true;
            }

            return false;
        }

        public Point ExecuteNavigationCommand(string navigationCommand)
        {
            SetNewDirection(navigationCommand);
            var increment = GetPositionIncrement(navigationCommand);

            return increment;
        }

        private Point GetPositionIncrement(string navigationCommand)
        {
            if (navigationCommand != Orientation.Move)
            {
                return new Point(0, 0);
            }

            var x = 0;
            var y = 0;

            switch (Direction)
            {
                case Orientation.North:
                    y = 1;
                    break;

                case Orientation.East:
                    x = 1;
                    break;

                case Orientation.South:
                    y = -1;
                    break;

                case Orientation.West:
                    x = -1;
                    break;
            }

            return new Point(x, y);
        }

        private void SetNewDirection(string navigationCommand)
        {
            var increment = GetIncrementForNavigationCommand(navigationCommand);
            if (increment == 0) { return; }

            SetIncrementedDirection(increment);
        }

        private void SetIncrementedDirection(int increment)
        {
            var index = _directions.IndexOf(Direction);
            index += increment;
            if (index < 0)
            {
                Direction = _directions[_directions.Count - 1];
            }
            else if (index >= _directions.Count)
            {
                Direction = _directions[0];
            }
            else
            {
                Direction = _directions[index];
            }
        }

        private static int GetIncrementForNavigationCommand(string navigationCommand)
        {
            var increment = 0;
            if (navigationCommand == Orientation.Left)
            {
                increment = -1;
            }
            else if (navigationCommand == Orientation.Right)
            {
                increment = 1;
            }

            return increment;
        }
    }
}
