using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppKovaApi.Context.Contracts;

namespace WebAppKovaApi.Contracts.Configurations
{
    /// <summary>
    /// Конфигурация <see cref="Supplier"/>
    /// </summary>
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder
                .ToTable("Suppliers");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .HasIndex(x => x.Name)
                .HasDatabaseName($"IX_{nameof(Supplier)}_{nameof(ISoftDeleted.Deleted)}")
                .IsUnique()
                .HasFilter($"'{nameof(ISoftDeleted.Deleted)}' is not null");
        }
    }
}
