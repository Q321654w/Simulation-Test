using System.Collections.Generic;
using Features.Interfaces;

namespace Features.Cubes
{
    public class DefaultCollection<T> : IPredicateCollection<T, T>, IIterate<T>, Interfaces.ICollection<T>
    {
        private readonly List<T> _elements;
        private readonly IDefault<T> _default;
        private readonly IPredicate<T> _predicate;

        public DefaultCollection(IDefault<T> defaultValue, IPredicate<T> predicate) : this(new List<T>(), defaultValue,
            predicate)
        {
        }

        public DefaultCollection(List<T> elements, IDefault<T> defaultValue, IPredicate<T> predicate)
        {
            _elements = elements;
            _default = defaultValue;
            _predicate = predicate;
        }

        public int Count()
        {
            return _elements.Count;
        }

        public ElementStatus<T> Element(T content)
        {
            for (int index = 0; index < _elements.Count; index++)
            {
                var element = _elements[index];
                if (_predicate.Execute(element, content))
                    return new ElementStatus<T>(true, element);
            }

            return new ElementStatus<T>(true, _default.Value());
        }

        public T Element(int index)
        {
            return _elements[index];
        }

        public void With(T content)
        {
            _elements.Add(content);
        }
    }
}