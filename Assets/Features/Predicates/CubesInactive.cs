using Collections.Predicates.WithParameter;
using Features.Cubes;

namespace Features.Predicates
{
    public readonly struct CubesInactive : IPredicateWithParameter<Cube>
    {
        private readonly Cube _cube;

        public CubesInactive(Cube cube)
        {
            _cube = cube;
        }
        
        public bool Evaluate(Cube content)
        {
            return _cube.Inactive() && _cube.Inactive();
        }
    }
}