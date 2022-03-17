using Collections;
using Collections.Predicates.Common;
using Collections.Predicates.WithParameter;
using Collections.Predicates.WithParameter.Composites;
using Collections.Predicates.WithParameter.Decorators;
using Features.Predicates;
using Update;

namespace Features.Cubes
{
    public class Cube : IUpdate, IEqualsWithParameter<Cube>
    {
        private readonly IFind<Cube, Cube> _collection;

        private int _value;
        private bool _inactive;

        public Cube(int value, IFind<Cube, Cube> collection)
        {
            _inactive = false;
            _value = value;
            _collection = collection;
        }

        public bool Inactive()
        {
            return _inactive;
        }

        public void Update()
        {
            if (_inactive)
                return;

            var result = _collection.Find(new AndWithParameter<Cube>(new IPredicateWithParameter<Cube>[]
            {
                new CubesEquals(this),
                new NotWithParameter<Cube>(new CubesInactive(this))
            }));

            if (result.Success)
                InteractWith(result.Content);
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

        public bool Equals(Cube source)
        {
            return _value == source._value;
        }

        public override string ToString()
        {
            return $"{_value}";
        }
    }
}