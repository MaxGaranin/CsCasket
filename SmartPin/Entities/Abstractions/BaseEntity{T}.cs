namespace SmartPin.Entities.Abstractions;

public interface IBaseEntity<out T>
    where T : struct
{
    T Id { get; }
}

public abstract class BaseEntity<T> : BaseEntity, IBaseEntity<T>
    where T : struct
{
    protected BaseEntity()
    {
    }

    protected BaseEntity(T id)
    {
        Id = id;
    }

    public T Id { get; set; }
}