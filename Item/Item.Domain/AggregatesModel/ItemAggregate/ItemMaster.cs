using Item.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Item.Domain.AggregatesModel.ItemAggregate
{
    public class ItemMaster :Entity, IAggregateRoot
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Decription { get; set; }
        public string UnitMeasurement { get; set; }

        public decimal StandardCost { get; set; }
        public decimal CurrentCost { get; set; }

        public int Quantity { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool Active { get; set; }
    }
}
