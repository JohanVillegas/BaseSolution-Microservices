using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Item.Application.Commands
{
    public class DeleteItemMasterCommand: IRequest
    {

        public Guid Id { get; set; }

        public DeleteItemMasterCommand()
        {
        }

        public DeleteItemMasterCommand(Guid id)
        {
            Id = id;
        }
    }
}
