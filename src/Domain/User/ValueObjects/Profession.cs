namespace Domain.User.ValueObjects;

public sealed class Profession : Enumeration<Profession>
{
    public static readonly Profession Mechanic = new(0, nameof(Mechanic));
    public static readonly Profession Cleaner = new(1, nameof(Cleaner));
    public static readonly Profession OfficeWorker = new(2, nameof(OfficeWorker));

    private Profession(int value, string name) : base(value, name)
    {
    }
}