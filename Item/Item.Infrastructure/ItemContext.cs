using Item.Domain.AggregatesModel.ItemAggregate;
using Item.Domain.SeedWork.Interfaces;
using Item.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Item.Infrastructure
{
    /// <summary>
    /// class exposed as a custom unit of work object
    /// </summary>
    public class ItemContext : DbContext, IUnitOfWork
    {
        #region [ Entities ]
        public DbSet<ItemMaster> ItemMaster { get; set; }
        #endregion

        public ItemContext(DbContextOptions options) : base(options) { }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync();

            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemMasterEntityTypeConfiguration());
        }
    }
}
