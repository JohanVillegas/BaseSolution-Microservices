using Item.Domain.SeedWork;

namespace Item.Domain.AggregatesModel.ItemAggregate
{
    public class UnitMeasure:Entity
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }

    }
}
