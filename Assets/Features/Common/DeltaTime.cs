using System;

namespace Features.Common
{
    public class DeltaTime
    {
        private DateTime _lastUpdateTime;
        private TimeSpan _deltaTime;

        public DeltaTime()
        {
            _lastUpdateTime = DateTime.Now;
        }

        public TimeSpan Span()
        {
            return _deltaTime;
        }

        public void Update()
        {
            var currentTime = DateTime.Now;
            _deltaTime = currentTime - _lastUpdateTime;

            _lastUpdateTime = currentTime;
        }
    }
}