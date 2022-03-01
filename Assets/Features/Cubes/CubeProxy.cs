using Features.Interfaces;

namespace Features.Cubes
{
    public class CubeProxy : IFactory<Cube>
    {
        private readonly IFactory<Cube> _factory;
        private readonly ICollection<Cube> _collection;

        public CubeProxy(IFactory<Cube> factory, ICollection<Cube> collection)
        {
            _factory = factory;
            _collection = collection;
        }

        public Cube Create()
        {
            var cube = _factory.Create();
            _collection.With(cube);
            return cube;
        }
    }
}