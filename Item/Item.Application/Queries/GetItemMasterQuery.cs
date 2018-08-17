using Item.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Item.Application.Queries
{
    public class GetItemMasterQuery : IRequest<ItemMasterViewModel>
    {
        public Guid Id { get; set; }


        public GetItemMasterQuery()
        {
        }

        public GetItemMasterQuery(Guid id)
        {
            Id = id;
        }
    }
}


