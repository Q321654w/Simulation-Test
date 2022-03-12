using Features.Collections;
using Features.Common;
using Features.Interfaces;

namespace Features.Simulation
{
    public class UpdateSimulation<T> : ISimulation where T : IUpdate
    {
        private readonly IIterate<T> _iterate;
        private readonly DeltaTime _deltaTime;

        public UpdateSimulation(IIterate<T> iterate, DeltaTime deltaTime)
        {
            _iterate = iterate;
            _deltaTime = deltaTime;
        }

        public void Simulate()
        {
            _deltaTime.Update();

            for (var index = 0; index < _iterate.Count(); index++)
            {
                _iterate.Element(index);
            }
        }
    }
}