using System.Drawing;

namespace MarsRovers
{
    public class MarsRover
    {
        private readonly Orientation _orientation;
        private readonly string _navigationCommands;

        public Point Position { get; private set; }
        public string Orientation => _orientation.Direction;

        public MarsRover(Point initialPosition, Orientation orientation, string navigationCommands)
        {
            Position = initialPosition;
            _orientation = orientation;
            _navigationCommands = navigationCommands;

            ApplyNavigationCommands();
        }

        private void ApplyNavigationCommands()
        {
            foreach (var cmd in _navigationCommands)
            {
                var increment = _orientation.ExecuteNavigationCommand(cmd.ToString());
                IncrementPosition(increment);
            }            
        }

        private void IncrementPosition(Point increment)
        {
            var x = Position.X + increment.X;
            var y = Position.Y + increment.Y;

            Position = new Point(x, y);
            ;
        }
    }
}
