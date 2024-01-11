namespace Shared.Domain;

public abstract class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>> where TEnum : Enumeration<TEnum>
{
    private static readonly Dictionary<int, TEnum> EnumerationsDictionary = GetAllEnumerationOptions().ToDictionary(item => item.Value);
    public static IReadOnlyCollection<TEnum> List => EnumerationsDictionary.Values.ToList();
    public int Value { get; protected init; }
    public string Name { get; protected init; }

    protected Enumeration(int value, string name)
    {
        Value = value;
        Name = name;
    }

    public static TEnum? FromValue(int value) => EnumerationsDictionary.GetValueOrDefault(value);
    public static TEnum? FromName(string name) => EnumerationsDictionary.Values.SingleOrDefault(x => x.Name == name);

    public bool Equals(Enumeration<TEnum>? other)
    {
        if (other is null)
        {
            return false;
        }

        return GetType() == other.GetType() && other.Value.Equals(Value);
    }

    public static bool operator ==(Enumeration<TEnum> a, Enumeration<TEnum> b) => Equals(a, b);
    public static bool operator !=(Enumeration<TEnum> a, Enumeration<TEnum> b) => !(a == b);
    public override bool Equals(object? obj) => obj is Enumeration<TEnum> other && Equals(other);
    public override int GetHashCode() => Value.GetHashCode();

    private static IEnumerable<TEnum> GetAllEnumerationOptions()
    {
        var enumType = typeof(TEnum);

        var enumerationTypes = Assembly
            .GetAssembly(enumType)!
            .GetTypes()
            .Where(type => enumType.IsAssignableFrom(type));

        var enumerations = new List<TEnum>();

        foreach (var enumerationType in enumerationTypes)
        {
            var enumerationTypeOptions = GetFieldsOfType<TEnum>(enumerationType);

            enumerations.AddRange(enumerationTypeOptions);
        }

        return enumerations;
    }

    public override string ToString() => Name;

    private static List<TFieldType> GetFieldsOfType<TFieldType>(Type type) =>
        type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fieldInfo => type.IsAssignableFrom(fieldInfo.FieldType))
            .Select(fieldInfo => (TFieldType)fieldInfo.GetValue(default)!)
            .ToList();
}