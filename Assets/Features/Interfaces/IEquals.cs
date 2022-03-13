using Predicate.WithParameter;

namespace Features.Interfaces
{
    public interface IEquals<T> : IPredicateWithParameter<T>
    {
        new bool Evaluate(T content);
    }
}