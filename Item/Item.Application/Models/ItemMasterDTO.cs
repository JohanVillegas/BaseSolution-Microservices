using Item.Domain.AggregatesModel.ItemAggregate;
using System;
using System.Linq.Expressions;

namespace Item.Application.Models
{
    public class ItemMasterDTO
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Decription { get; set; }
        public DateTime DateTime { get; set; }
        public bool Active { get; set; }

        public static Func<ItemMaster, ItemMasterDTO> ProjectionDTO()
        {
            return i => new ItemMasterDTO
            {
                Id = i.Id,
                Name = i.Name,
                Number = i.Number,
                Decription = i.Description,
                ShortName = i.ShortName,
                DateTime = i.DateTime,
                Active = i.Active
            };
        }

        public static ItemMasterDTO ProjectionDTO(ItemMaster i)
        {
            ItemMasterDTO itemMasterDTO = new ItemMasterDTO
            {
                Id = i.Id,
                Name = i.Name,
                Number = i.Number,
                Decription = i.Description,
                ShortName = i.ShortName,
                DateTime = i.DateTime,
                Active = i.Active
            };

            return itemMasterDTO;
        }
    }
}