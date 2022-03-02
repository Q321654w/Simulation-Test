using Features.Cubes;
using Features.Interfaces;

namespace Features.Predicates
{
    internal class CubePredicate : IPredicate<Cube>
    {
        private readonly Cube _cube;

        public CubePredicate(Cube cube)
        {
            _cube = cube;
        }

        public bool Execute(Cube content)
        {
            return _cube.Equals(content);
        }
    }
}