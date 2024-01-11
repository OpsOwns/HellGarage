namespace Shared.Domain;

[Serializable]
public abstract class ValueObject : IComparable, IComparable<ValueObject>
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public virtual int CompareTo(object? obj)
    {
        if (obj is not ValueObject other)
            return string.Compare(GetType().ToString(), obj?.GetType().ToString() ?? string.Empty,
                StringComparison.Ordinal);

        var components = GetEqualityComponents().ToArray();
        var otherComponents = other.GetEqualityComponents().ToArray();

        return components.Select((t, i) => CompareComponents(t, otherComponents[i]))
            .FirstOrDefault(x => x != 0);
    }

    public virtual int CompareTo(ValueObject? other) => CompareTo(other as object);

    protected virtual bool Equals(ValueObject? other) =>
        other is not null && GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());

    public override bool Equals(object? obj) =>
        ReferenceEquals(this, obj) ||
        obj is ValueObject valueObject && Equals(valueObject);

    public override int GetHashCode() =>
        GetEqualityComponents()
            .Select(c => c.GetHashCode())
            .Aggregate(1, (current, hashCode) =>
            {
                unchecked
                {
                    return current * 23 + hashCode;
                }
            });

    private static int CompareComponents(object? object1, object? object2) =>
        (object1, object2) switch
        {
            (null, null) => 0,
            (null, _) => -1,
            (_, null) => 1,
            (IComparable comparable1, IComparable comparable2) => comparable1.CompareTo(comparable2),
            var (o1, o2) => o1.Equals(o2) ? 0 : -1,
        };

    public static bool operator ==(ValueObject? left, ValueObject? right) =>
        ReferenceEquals(left, right) ||
        left is not null && left.Equals(right);

    public static bool operator !=(ValueObject? left, ValueObject? right) => !(left == right);
}