namespace Features.Predicates
{
    public interface IPredicate<T>
    {
        bool Execute(T content);
    }
}