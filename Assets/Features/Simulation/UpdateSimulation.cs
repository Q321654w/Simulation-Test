using System;
using Features.Interfaces;

namespace Features.Simulation
{
    public class UpdateSimulation<T> : ISimulation where T : IUpdate
    {
        private readonly IIterate<T> _iterate;
        private DateTime _lastUpdateTime;

        public UpdateSimulation(IIterate<T> iterate)
        {
            _iterate = iterate;
            _lastUpdateTime = DateTime.Now;
        }

        public void Simulate()
        {
            var currentTime = DateTime.Now;
            var deltaTime = currentTime - _lastUpdateTime;
            var elapsedMilliseconds = deltaTime.Milliseconds;

            for (var index = 0; index < _iterate.Count(); index++)
            {
                var element = _iterate.Element(index);
                if (element.Status())
                    element.ExecuteFrame(elapsedMilliseconds);
            }

            _lastUpdateTime = currentTime;
        }
    }
}