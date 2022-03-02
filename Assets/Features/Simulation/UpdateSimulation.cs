using Features.Collections;
using Features.Interfaces;

namespace Features.Simulation
{
    public class UpdateSimulation<T> : ISimulation where T : IUpdate
    {
        private readonly IIterate<T> _iterate;
        private readonly Stopwatch _stopwatch;

        public UpdateSimulation(IIterate<T> iterate, Stopwatch stopwatch)
        {
            _iterate = iterate;
            _stopwatch = stopwatch;
        }

        public void Simulate()
        {
            _stopwatch.Update();

            for (var index = 0; index < _iterate.Count(); index++)
            {
                _iterate.Element(index);
            }
        }
    }
}