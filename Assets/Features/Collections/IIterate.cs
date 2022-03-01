namespace Features.Interfaces
{
    public interface IIterate<out T>
    {
        int Count();
        T Element(int index);
    }
}