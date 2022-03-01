namespace Features.Interfaces
{
    public interface IPredicateCollection<T, U>
    {
        ElementStatus<T> Element(U content);
    }
}