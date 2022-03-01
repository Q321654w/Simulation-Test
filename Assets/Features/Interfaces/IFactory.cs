namespace Features.Interfaces
{
    public interface IFactory<T>
    {
        T Create();
    }
}