using Features.Interfaces;

namespace Features.Cubes
{
    public class Cube : IUpdate, IEquals<Cube>
    {
        private readonly IPredicateCollection<Cube, Cube> _predicateCollection;
        private int _value;
        private bool _active;

        public Cube(int value, IPredicateCollection<Cube, Cube> predicateCollection)
        {
            _active = true;
            _value = value;
            _predicateCollection = predicateCollection;
        }

        public bool Status()
        {
            return _active;
        }

        public void ExecuteFrame(double elapsedMilliseconds)
        {
            var status = _predicateCollection.Element(this);
            if (status.Success)
                AttractWith(status.Element);
        }

        private void AttractWith(Cube cube)
        {
            _active = false;
            cube.Merge(this);
        }

        private void Merge(Cube cube)
        {
            _value += cube._value;
        }

        public bool Equals(Cube content)
        {
            return _value == content._value;
        }

        public override string ToString()
        {
            return $"{_value}";
        }
    }
}