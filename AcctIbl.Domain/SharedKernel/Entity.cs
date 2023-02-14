namespace AcctIbl.Domain.SharedKernel;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
where TId : notnull
{
    protected Entity(TId id)
    {
        if (!IsIdValid(id))
            throw new ArgumentException("Identifier is not a supported format");

        Id = id;
    }

    public TId Id { get; protected init; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity<TId>);
    }

    public bool Equals(Entity<TId>? other)
    {
        return Id?.GetHashCode() == other?.Id?.GetHashCode();
    }

    public override int GetHashCode()
    {
        return Id!.GetHashCode();
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !(left == right);
    }

    private static bool IsIdValid(TId id)
    {
        return id is int || id is long || id is string || id is Guid;
    }
}