using Features.Cubes;

namespace Features.Predicates
{
    public readonly struct CubeEquals : IPredicate<Cube>
    {
        private readonly Cube _cube;

        public CubeEquals(Cube cube)
        {
            _cube = cube;
        }

        public bool Execute(Cube content)
        {
            return _cube.Equals(content) && !_cube.Inactive() && !content.Inactive();
        }
    }
}