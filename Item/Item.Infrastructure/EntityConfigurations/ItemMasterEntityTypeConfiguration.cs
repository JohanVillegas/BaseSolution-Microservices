using Item.Domain.AggregatesModel.ItemAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Item.Infrastructure.EntityConfigurations
{
    class ItemMasterEntityTypeConfiguration : IEntityTypeConfiguration<ItemMaster>
    {
        public void Configure(EntityTypeBuilder<ItemMaster> itemMasterConfiguration)
        {

            #region [ Property restrictions ]

            itemMasterConfiguration.HasKey(o => o.Id);
            itemMasterConfiguration.Property<string>("Number")
                .IsRequired()
                .HasMaxLength(32);
            itemMasterConfiguration.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(100);
            itemMasterConfiguration.Property<string>("ShortName")
                .IsRequired(false)
                .HasMaxLength(16);
            itemMasterConfiguration.Property<string>("Description")
                .IsRequired(false)
                .HasMaxLength(100);
            itemMasterConfiguration.Property<DateTime>("DateTime")
                .IsRequired();
            itemMasterConfiguration.Property<bool>("Active")
                .IsRequired();

            itemMasterConfiguration.Property<Guid?>("TypeId")
                .IsRequired();
            itemMasterConfiguration.Property<Guid?>("UnitMeasureId")
                .IsRequired();

            #endregion

            #region [ Entity restrictions ]

            itemMasterConfiguration.HasOne(t => t.Type)
                .WithMany()
                .HasForeignKey("TypeId")
                .IsRequired();

            itemMasterConfiguration.HasOne(u => u.UnitMeasure)
                .WithMany()
                .HasForeignKey("UnitMeasureId")
                .IsRequired();

            #endregion
        }
    }
}
