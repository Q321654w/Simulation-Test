namespace Features
{
    public readonly struct ElementStatus<T>
    {
        private readonly bool _success;
        private readonly T _element;

        public ElementStatus(bool success, T element)
        {
            _success = success;
            _element = element;
        }

        public bool Success => _success;
        public T Element => _element;
    }
}