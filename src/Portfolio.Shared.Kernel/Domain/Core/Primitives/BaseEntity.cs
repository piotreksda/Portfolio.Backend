namespace Portfolio.Shared.Kernel.Domain.Core.Primitives;

public abstract class BaseEntity<T> where T : struct
{
    public T Id { get; private set; }
    public bool Deleted { get; private set; }

    public void Delete()
    {
        Deleted = true;
    }
}