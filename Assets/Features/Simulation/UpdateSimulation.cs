using Collections;
using Update;
using Values;

namespace Features.Simulation
{
    public class UpdateSimulation<T> : ISimulation where T : IUpdate
    {
        private readonly IIterate<T> _iterate;
        private readonly IValue<double> _deltaTime;

        public UpdateSimulation(IIterate<T> iterate, IValue<double> deltaTime)
        {
            _iterate = iterate;
            _deltaTime = deltaTime;
        }

        public void Simulate()
        {
            _deltaTime.Evaluate();
            var count = _iterate.Count();
            
            for (var index = 0; index < count; index++)
            {
                _iterate.Element(index);
            }
        }
    }
}