using Item.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Item.Application.Commands
{
    public class CreateItemMasterCommand : IRequest<bool>
    {
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
