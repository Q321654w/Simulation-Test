using Features.Collections;
using Features.Interfaces;
using Features.Predicates;

namespace Features.Cubes
{
    public class Cube : IUpdate, IEquals<Cube>
    {
        private readonly ICollection<Cube, Cube> _predicateCollection;

        private int _value;
        private bool _inactive;

        public Cube(int value, ICollection<Cube, Cube> predicateCollection)
        {
            _inactive = false;
            _value = value;
            _predicateCollection = predicateCollection;
        }

        public bool Inactive()
        {
            return _inactive;
        }

        public void ExecuteFrame()
        {
            if (_inactive)
                return;

            var status = _predicateCollection.Element(new CubeEquals(this));
            if (status.Success)
                InteractWith(status.Element);
        }

        private void InteractWith(Cube cube)
        {
            _inactive = true;
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