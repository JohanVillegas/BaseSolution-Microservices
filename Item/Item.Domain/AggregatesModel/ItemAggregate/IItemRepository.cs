using Item.Domain.SeedWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Item.Domain.AggregatesModel.ItemAggregate
{
    public interface IItemRepository : IRepository<ItemMaster>
    {
        ItemMaster Add(ItemMaster itemMaster);

        void Update(ItemMaster itemMaster);

        Task<ItemMaster> GetAsync(Guid itemMasterId);

        Task<List<ItemMaster>> GetAllAsync();
    }
}
