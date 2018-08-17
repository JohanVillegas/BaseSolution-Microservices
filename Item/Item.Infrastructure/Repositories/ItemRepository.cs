using Item.Domain.AggregatesModel.ItemAggregate;
using Item.Domain.SeedWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Item.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ItemContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ItemRepository(ItemContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ItemMaster>> GetAllAsync()
        {
            var itemMasters = await _context.ItemMaster
                    .Include(i => i.UnitMeasure)
                    .Include(i => i.Type)
                    .ToListAsync();

            return itemMasters;
        }

        public async Task<ItemMaster> GetAsync(Guid itemMasterId)
        {
            var itemMaster = await _context.ItemMaster.FindAsync(itemMasterId);
            if (itemMaster != null)
            {
                await _context.Entry(itemMaster)
                    .Reference(i => i.Type).LoadAsync();

                await _context.Entry(itemMaster)
                    .Reference(i => i.UnitMeasure).LoadAsync();
            }

            return itemMaster;
        }

        public ItemMaster Add(ItemMaster itemMaster)
        {
            return _context.ItemMaster.Add(itemMaster).Entity;
        }

        public void Update(ItemMaster itemMaster)
        {
            //_context.Entry(itemMaster).State = EntityState.Modified;
            _context.ItemMaster.Update(itemMaster);

        }

        public void Delete(ItemMaster itemMaster)
        {
            // var itemMaster = await _context.ItemMaster.SingleOrDefaultAsync(x => x.Id == itemMasterId);
            _context.Remove(itemMaster);
         }
    }
}
