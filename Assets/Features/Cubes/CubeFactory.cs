using Features.Collections;
using Features.Interfaces;
using Random = UnityEngine.Random;

namespace Features.Cubes
{
    public class CubeFactory : IFactory<Cube>
    {
        private readonly IPredicateCollection<Cube, Cube> _collection;
        private readonly int _min;
        private readonly int _max;

        public CubeFactory(int min, int max, IPredicateCollection<Cube, Cube> collection)
        {
            _min = min;
            _max = max;
            _collection = collection;
        }

        public Cube Create()
        {
            var value = Random.Range(_min, _max);
            return new Cube(value, _collection);
        }
    }
}