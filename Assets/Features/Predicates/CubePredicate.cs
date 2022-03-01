using Features.Cubes;
using Features.Interfaces;

namespace Features
{
    internal class CubePredicate : IPredicate<Cube>
    {
        public bool Execute(Cube first, Cube second)
        {
            return first.Status() && second.Status() && first.Equals(second);
        }
    }
}