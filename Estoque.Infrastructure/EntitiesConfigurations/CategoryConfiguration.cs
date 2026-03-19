using Estoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.ObjectModel;


namespace Estoque.Infrastructure.EntitiesConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryId);
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(c => c.ImageUrl).HasMaxLength(25);
        }
    }
}
