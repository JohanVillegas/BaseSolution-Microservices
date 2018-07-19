using Item.Domain.SeedWork;
using System.Collections.Generic;

namespace Item.Domain.AggregatesModel.ItemAggregate
{
    public class ItemMasterType : Enumeration
    {
        public static ItemMasterType Sales = new ItemMasterType(1, nameof(Sales).ToLowerInvariant());
        public static ItemMasterType Discontinued = new ItemMasterType(2, nameof(Discontinued).ToLowerInvariant());
        public static ItemMasterType Kit = new ItemMasterType(3, nameof(Kit).ToLowerInvariant());
        public static ItemMasterType Services = new ItemMasterType(4, nameof(Services).ToLowerInvariant());

        protected ItemMasterType()
        {
        }

        public ItemMasterType(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<ItemMasterType> List() => new[] { Sales, Discontinued, Kit, Services };

    }
}
