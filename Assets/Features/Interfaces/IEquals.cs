using Features.Predicates;

namespace Features.Interfaces
{
    public interface IEquals<T>
    {
        bool Equals(T content);
    }
}