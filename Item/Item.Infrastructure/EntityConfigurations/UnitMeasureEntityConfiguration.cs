using Item.Domain.AggregatesModel.ItemAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Item.Infrastructure.EntityConfigurations
{
    class UnitMeasureEntityConfiguration : IEntityTypeConfiguration<UnitMeasure>
    {
        public void Configure(EntityTypeBuilder<UnitMeasure> unitMeasureConfiguration)
        {
            unitMeasureConfiguration.HasKey(u => u.Id);

            unitMeasureConfiguration.Property<string>("Number")
                .IsRequired()
                .HasMaxLength(32);
            unitMeasureConfiguration.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(100);
            unitMeasureConfiguration.Property<string>("ShortName")
                .IsRequired(false)
                .HasMaxLength(16);
            unitMeasureConfiguration.Property<string>("Description")
                .IsRequired(false)
                .HasMaxLength(100);
        }
    }
}
