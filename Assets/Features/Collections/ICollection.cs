using Features.Predicates;

namespace Features.Collections
{
    public interface ICollection<T, U>
    {
        Result<T> Element(IPredicate<U> predicate);
        ICollection<T, U> With(T content);
    }
}