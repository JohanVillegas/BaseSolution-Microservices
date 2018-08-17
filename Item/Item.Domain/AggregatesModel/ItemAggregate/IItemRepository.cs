using Item.Domain.SeedWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Item.Domain.AggregatesModel.ItemAggregate
{
    public interface IItemRepository : IRepository<ItemMaster>
    {
        Task<List<ItemMaster>> GetAllAsync();

        Task<ItemMaster> GetAsync(Guid itemMasterId);

        ItemMaster Add(ItemMaster itemMaster);

        void Update(ItemMaster itemMaster);

        void Delete(ItemMaster itemMaster);
    }
}
