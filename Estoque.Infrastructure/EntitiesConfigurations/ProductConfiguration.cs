using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Estoque.Domain.Entities;

namespace Estoque.Infrastructure.EntitiesConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);
            builder.Property(p => p.Name).HasMaxLength(60).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Price);
            builder.Property(p => p.ImageUrl).HasMaxLength(25);
            builder.Property(p => p.Stock).HasDefaultValue(0);
            builder.Property(p => p.RegistrationDate).IsRequired();
        }
    }
}
