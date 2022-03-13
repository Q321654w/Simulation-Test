namespace Features.Interfaces
{
    public interface IFactory<out T>
    {
        T Create();
    }
}