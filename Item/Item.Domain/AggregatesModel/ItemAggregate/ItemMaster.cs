using Item.Domain.SeedWork;
using Item.Domain.SeedWork.Interfaces;
using System;

namespace Item.Domain.AggregatesModel.ItemAggregate
{
    
    public class ItemMaster :Entity, IAggregateRoot
    {
        #region [ attributes ]
        public string Number { get; private set; }
        public string Name { get; private set; }
        public string ShortName { get; private set; }
        public string Decription { get; private set; }
        public DateTime DateTime { get; private set; }
        public bool Active { get; private set; }

        public UnitMeasure UnitMeasure { get; private set; }
        public ItemMasterType Type { get; private set; }
        #endregion

        #region [ methods ]
        public static ItemMaster AddItemMaster(string number, string name, string shortName, string description, 
                                               DateTime dateTime, bool active, UnitMeasure unitMeasure, ItemMasterType type)
        {
            ItemMaster itemMaster = new ItemMaster()
            {
                Id = Guid.NewGuid(),
                Number = number,
                Name = name,
                ShortName = shortName,
                Decription = description,
                DateTime = dateTime,
                Active = active,
                UnitMeasure = unitMeasure,
                Type = type
            };

            return itemMaster;
        }

        #endregion

        #region [ notas de la clases ]
        //// el atributo {UnitMeasurement} debe ser expresada en una clase 
        //// 
        //// tener presente que el atributo {Type} debe de ser expresado en una clase 
        #endregion

    }
}
