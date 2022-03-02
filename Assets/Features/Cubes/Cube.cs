﻿using Features.Collections;
using Features.Interfaces;

namespace Features.Cubes
{
    public class Cube : IUpdate, IEquals<Cube>
    {
        private readonly IPredicateCollection<Cube, Cube> _predicateCollection;

        private int _value;
        private bool _inactive;

        public Cube(int value, IPredicateCollection<Cube, Cube> predicateCollection)
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
                AttractWith(status.Element);
        }

        private void AttractWith(Cube cube)
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
            return _value == content._value && _inactive ;
        }

        public override string ToString()
        {
            return $"{_value}";
        }
    }
}