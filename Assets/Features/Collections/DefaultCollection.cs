using System.Collections.Generic;
using Features.Interfaces;
using Features.Predicates;

namespace Features.Collections
{
    public class DefaultCollection<T> : IIterate<T>, ICollection<T, T>
    {
        private readonly List<T> _elements;
        private readonly IDefault<T> _default;

        public DefaultCollection(IDefault<T> defaultValue) : this(new List<T>(), defaultValue)
        {
        }

        public DefaultCollection(List<T> elements, IDefault<T> defaultValue)
        {
            _elements = elements;
            _default = defaultValue;
        }

        public int Count()
        {
            return _elements.Count;
        }

        public Result<T> Element(IPredicate<T> predicate)
        {
            for (int index = 0; index < _elements.Count; index++)
            {
                var element = _elements[index];
                if (predicate.Execute(element))
                    return new Result<T>(true, element);
            }

            return new Result<T>(false, _default.Value());
        }

        public T Element(int index)
        {
            return _elements[index];
        }

        public ICollection<T, T> With(T content)
        {
            _elements.Add(content);
            return this;
        }
    }
}