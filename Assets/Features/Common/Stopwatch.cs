using System;
using Update;

namespace Features.Common
{
    public class Stopwatch : IUpdate
    {
        private DateTime _lastUpdateTime;
        private DateTime _elapsedTime;

        public Stopwatch()
        {
            _lastUpdateTime = DateTime.Now;
        }

        public DateTime ElapsedTime()
        {
            return _elapsedTime;
        }

        public void Update()
        {
            var currentTime = DateTime.Now;
            var deltaTime = currentTime - _lastUpdateTime;

            _elapsedTime += deltaTime;
            _lastUpdateTime = currentTime;
        }
    }
}