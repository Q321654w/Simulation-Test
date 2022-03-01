using Features.Cubes;
using Features.Interfaces;
using Features.Simulation;
using UnityEngine;

namespace Features
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private int _min;
        [SerializeField] private int _max;

        private IFactory<Cube> _factory;
        private DefaultCollection<Cube> _cubes;
        private ISimulation _simulation;

        private void Start()
        {
            _cubes = new DefaultCollection<Cube>(new DefaultCube(),new CubePredicate());
            var cubeFactory = new CubeFactory(_min, _max, _cubes);
            _factory = new CubeProxy(cubeFactory, _cubes);
            _simulation = new UpdateSimulation<IUpdate>(_cubes);
        }

        private void Update()
        {
            _simulation.Simulate();
        }

        [ContextMenu("CreateCube")]
        private void CreateCube()
        {
            var cube = _factory.Create();
            print(cube.ToString());
        }
    }
}