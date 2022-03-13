using Collections;
using Features.Interfaces;
using Features.Predicates;
using Predicate.WithParameter;
using Update;

namespace Features.Cubes
{
    public class Cube : IUpdate, IEquals<Cube>
    {
        private readonly ICollection<Cube, Cube> _collection;

        private int _value;
        private bool _inactive;

        public Cube(int value, ICollection<Cube, Cube> collection)
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

            var result = _collection.Element(new AndWithParameter<Cube>(new IPredicateWithParameter<Cube>[]
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

        public bool Evaluate(Cube content)
        {
            return _value == content._value;
        }

        public override string ToString()
        {
            return $"{_value}";
        }
    }
}