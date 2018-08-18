using Item.Domain.SeedWork;
using System.Collections.Generic;

namespace Item.Domain.AggregatesModel.ItemAggregate
{
    public class Type : Enumeration
    {
        public static Type Sales = new Type(1, nameof(Sales).ToLowerInvariant());
        public static Type Discontinued = new Type(2, nameof(Discontinued).ToLowerInvariant());
        public static Type Kit = new Type(3, nameof(Kit).ToLowerInvariant());
        public static Type Services = new Type(4, nameof(Services).ToLowerInvariant());

        protected Type()
        {
        }

        public Type(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<Type> List() => new[] { Sales, Discontinued, Kit, Services };

    }
}
