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
        public string Description { get; private set; }
        public DateTime DateTime { get; private set; }
        public bool Active { get; private set; }

        public UnitMeasure UnitMeasure { get; private set; }
        public Guid _unitMeasureId { get; private set; }
        public Type Type { get; private set; }
        public int? _typeId { get; private set; }
        #endregion

        #region [ constructor ]
        public ItemMaster()
        {

        } 

        public ItemMaster(string number, string name, string shortName, string description, DateTime dateTime, bool active, Guid unitMeasureId, int typeId)
        {
            Number = number;
            Name = name;
            ShortName = shortName;
            Description = description;
            DateTime = dateTime;
            Active = active;
            _unitMeasureId = unitMeasureId;
            _typeId = typeId;
        }
        #endregion

        #region [ methods ]
        public void AddItemMaster(string number, string name, string shortName, string description, 
                                               DateTime dateTime, bool active, Guid unitMeasureId, int typeId)
        {
            Number = number;
            Name = name;
            ShortName = shortName;
            Description = description;
            DateTime = dateTime;
            Active = active;
            _unitMeasureId = unitMeasureId;
            _typeId = typeId;
            Id = Guid.NewGuid();
        }

        #endregion


    }
}
