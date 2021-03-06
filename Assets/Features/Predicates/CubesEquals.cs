using Collections.Predicates.WithParameter;
using Features.Cubes;

namespace Features.Predicates
{
    public readonly struct CubesEquals : IPredicateWithParameter<Cube>
    {
        private readonly Cube _cube;

        public CubesEquals(Cube cube)
        {
            _cube = cube;
        }
        
        public bool Evaluate(Cube content)
        {
            return _cube.Equals(content);
        }
    }
}