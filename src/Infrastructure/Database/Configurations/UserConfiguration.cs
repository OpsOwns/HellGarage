namespace Infrastructure.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ComplexProperty(x => x.Email, y =>
        {
            y.IsRequired();
            y.Property(email => email.Value).HasColumnName("Email");
        });
        builder.ComplexProperty(x => x.FirstName, y => y.IsRequired());
        builder.ComplexProperty(x => x.LastName, y => y.IsRequired());
        builder.ComplexProperty(x => x.Phone, y => y.IsRequired());
        builder.ComplexProperty(x => x.HashedPassword, y => y.IsRequired());
        builder.Property(notification => notification.Profession)
            .HasConversion(p => p.Value, v => Profession.FromValue(v)!)
            .IsRequired();
    }
}