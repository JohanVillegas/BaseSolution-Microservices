using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Item.Domain.AggregatesModel.ItemAggregate;
using System.Collections.Generic;
using System.Text;

namespace Item.Infrastructure.EntityConfigurations
{
    class TypeEntityConfiguration : IEntityTypeConfiguration<Type>
    {
        public void Configure(EntityTypeBuilder<Type> typeConfiguration)
        {
            typeConfiguration.HasKey(t => t.Id);

            typeConfiguration.Property(t => t.Id)
                .ValueGeneratedNever()
                .IsRequired();

            typeConfiguration.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
