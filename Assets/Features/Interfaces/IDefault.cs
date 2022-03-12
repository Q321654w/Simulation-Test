namespace Features.Interfaces
{
    public interface IDefault<out T>
    {
        T Value();
    }
}