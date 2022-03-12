namespace Features.Collections
{
    public readonly struct Result<T>
    {
        private readonly bool _success;
        private readonly T _element;

        public Result(bool success, T element)
        {
            _success = success;
            _element = element;
        }

        public bool Success => _success;
        public T Element => _element;
    }
}