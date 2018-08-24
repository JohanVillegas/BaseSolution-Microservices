using MediatR;
using System;

namespace Item.Application.Commands
{
    public class UpdateItemMasterCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public bool Active { get; set; }

        public Guid UnitMeasureId { get; set; }
        public int TypeId { get; set; }
    }
}