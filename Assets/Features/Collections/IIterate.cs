namespace Features.Collections
{
    public interface IIterate<out T>
    {
        int Count();
        T Element(int index);
    }
}