namespace Features.Interfaces
{
    public interface IPredicate<T>
    {
        bool Execute(T first, T second);
    }
}