using Item.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Item.Application.Queries
{
    public class GetAllItemMasterQuery : IRequest<ItemMasterListViewModel>
    {
    }
}
