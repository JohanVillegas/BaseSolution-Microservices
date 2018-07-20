using Item.Domain.SeedWork;
using Item.Domain.SeedWork.Interfaces;
using System;

namespace Item.Domain.AggregatesModel.ItemAggregate
{
    
    public class ItemMaster :Entity, IAggregateRoot
    {
        #region [ attributes ]
        public string Number { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Decription { get; set; }
        public UnitMeasure UnitMeasure { get; set; }
        public ItemMasterType Type { get; set; }
        public DateTime DateTime { get; set; }
        public bool Active { get; set; }
        #endregion

        #region [ notas de la clases ]
        //// el atributo {UnitMeasurement} debe ser expresada en una clase 
        //// 
        //// tener presente que el atributo {Type} debe de ser expresado en una clase 
        #endregion

    }
}
