namespace Shared.Domain;

public class Entity : IEquatable<Entity>
{
    public Guid Id { get; init; }
    protected Entity() { }
    protected Entity(Guid id) : this()
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id cannot be an empty", nameof(id));
        }

        Id = id;
    }

    public static bool operator ==(Entity? a, Entity? b) => ReferenceEquals(a, b) || (a is not null && a.Equals(b));
    public static bool operator !=(Entity? a, Entity? b) => !(a == b);
    public bool Equals(Entity? other) => other is not null && (ReferenceEquals(this, other) || Id == other.Id);
    public override bool Equals(object? obj) =>
        obj is not null &&
        (ReferenceEquals(this, obj) ||
         obj.GetType() == GetType() && obj is Entity entity && entity.Id != Guid.Empty && Id == entity.Id);
    public override int GetHashCode() => Id.GetHashCode() * 41;
}