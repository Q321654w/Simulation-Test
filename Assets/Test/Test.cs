using Collections;
using Collections.Implementations;
using Features.Cubes;
using Features.Interfaces;
using Features.Simulation;
using UnityEngine;
using Update;
using Values;

namespace Test
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private int _min;
        [SerializeField] private int _max;

        private IFactory<Cube> _factory;
        private DefaultList<Cube> _cubes;
        private ISimulation _simulation;

        private void Start()
        {
            _cubes = new DefaultList<Cube>(new DefaultCube());
            var cubeFactory = new CubeFactory(_cubes, new DefaultRange<int>(_min, _max));
            _factory = new CubeFactoryProxy(cubeFactory, _cubes);
            _simulation = new UpdateSimulation<IUpdate>(_cubes,
                new CacheBetweenUpdate<double>(new SecondsDeltaTime(new DeltaTime())));
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