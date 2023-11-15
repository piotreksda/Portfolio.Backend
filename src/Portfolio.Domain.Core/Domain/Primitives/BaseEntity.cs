namespace Portfolio.Domain.Core.Domain.Primitives;

public abstract class BaseEntity<T> where T : struct
{
    public T Id { get; private set; }
    public bool Deleted { get; private set; }
}