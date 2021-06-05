using CSharpFunctionalExtensions;

namespace Engine.Core.Rules
{
    public interface IBusinessRule<T> where T : class
    {
        Result Apply(T context);
    }
}
