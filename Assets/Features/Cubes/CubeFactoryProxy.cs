using Collections;
using Features.Interfaces;

namespace Features.Cubes
{
    public class CubeFactoryProxy : IFactory<Cube>
    {
        private readonly IFactory<Cube> _factory;
        private ICollection<Cube, Cube> _collection;

        public CubeFactoryProxy(IFactory<Cube> factory, ICollection<Cube, Cube> collection)
        {
            _factory = factory;
            _collection = collection;
        }

        public Cube Create()
        {
            var cube = _factory.Create();
            _collection = _collection.With(cube);
            return cube;
        }
    }
}