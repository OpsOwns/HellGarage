namespace Infrastructure.Database.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id).HasColumnName("UserId").HasColumnOrder(0);
        builder.HasKey(x => x.Id);

        builder.ComplexProperty(x => x.Email, y =>
        {
            y.IsRequired();
            y.Property(email => email.Value).HasColumnName("Email").HasColumnOrder(1);
        });
        builder.ComplexProperty(x => x.FirstName, y =>
        {
            y.IsRequired();
            y.Property(firstName => firstName.Value).HasColumnName("FirstName").HasColumnOrder(2);
        });
        builder.ComplexProperty(x => x.LastName, y =>
        {
            y.IsRequired();
            y.Property(lastName => lastName.Value).HasColumnName("LastName").HasColumnOrder(3);
        });
        builder.ComplexProperty(x => x.Phone, y =>
        {
            y.IsRequired();
            y.Property(phone => phone.Value).HasColumnName("Phone").HasColumnOrder(4);
        });
        builder.ComplexProperty(x => x.HashedPassword, y =>
        {
            y.IsRequired();
            y.Property(hashedPassword => hashedPassword.Hash).HasColumnName("Password").HasColumnOrder(6);
            y.Property(hashedPassword => hashedPassword.Salt).HasColumnName("Salt").HasColumnOrder(7);
        });
        builder.Property(notification => notification.Profession)
            .HasColumnName("Profession")
            .HasConversion(p => p.Value, v => Profession.FromValue(v)!)
            .IsRequired().HasColumnOrder(5);
    }
}