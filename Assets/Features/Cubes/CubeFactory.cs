using Collections;
using Features.Interfaces;
using Values;
using Random = UnityEngine.Random;

namespace Features.Cubes
{
    public class CubeFactory : IFactory<Cube>
    {
        private readonly IFind<Cube, Cube> _collection;
        private readonly IRange<int> _range;

        public CubeFactory(IFind<Cube, Cube> collection, IRange<int> range)
        {
            _collection = collection;
            _range = range;
        }

        public Cube Create()
        {
            var value = Random.Range(_range.Min(), _range.Max());
            return new Cube(value, _collection);
        }
    }
}