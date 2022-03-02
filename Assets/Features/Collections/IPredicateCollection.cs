using Features.Predicates;

namespace Features.Collections
{
    public interface IPredicateCollection<T, U>
    {
        ElementStatus<T> Element(IPredicate<U> predicate);
    }
}