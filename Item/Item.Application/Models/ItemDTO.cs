using Item.Domain.AggregatesModel.ItemAggregate;
using System;
using System.Linq.Expressions;

namespace Item.Application.Models
{
    public class ItemDTO
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Decription { get; set; }
        public DateTime DateTime { get; set; }
        public bool Active { get; set; }

        public static Func<ItemMaster, ItemDTO> ProjectionDTO()
        {
            return i => new ItemDTO
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

        public static implicit operator ItemDTO(ItemMaster i)
        {
            ItemDTO itemDTO = new ItemDTO{
                Id = i.Id,
                Name = i.Name,
                Number = i.Number,
                Decription = i.Description,
                ShortName = i.ShortName,
                DateTime = i.DateTime,
                Active = i.Active
            };

            return itemDTO;
        }

        internal static ItemDTO ProjectionDTO(ItemMaster i)
        {
            ItemDTO itemDTO = new ItemDTO
            {
                Id = i.Id,
                Name = i.Name,
                Number = i.Number,
                Decription = i.Description,
                ShortName = i.ShortName,
                DateTime = i.DateTime,
                Active = i.Active
            };

            return itemDTO;
        }
    }
}