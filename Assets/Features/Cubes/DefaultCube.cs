using Collections;

namespace Features.Cubes
{
    internal class DefaultCube : IDefault<Cube>
    {
        private readonly Cube _value;

        public DefaultCube()
        {
            _value = new Cube(0, null);
        }

        public Cube Value()
        {
            return _value;
        }
    }
}