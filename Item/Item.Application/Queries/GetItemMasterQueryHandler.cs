using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Item.Application.Models;
using Item.Domain.AggregatesModel.ItemAggregate;
using MediatR;
using System.Linq;
using System.Collections;

namespace Item.Application.Queries
{
    public class GetItemMasterQueryHandler : IRequestHandler<GetItemMasterQuery, ItemMasterViewModel>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMediator _mediator;

        // Using DI to inject infrastructure persistence Repositories
        public GetItemMasterQueryHandler(IMediator mediator, IItemRepository itemRepository)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<ItemMasterViewModel> Handle(GetItemMasterQuery request, CancellationToken cancellationToken)
        {
            var _item = await _itemRepository.GetAsync(request.Id);

            var model = new ItemMasterViewModel
            {
                Item =  ItemDTO.ProjectionDTO(_item),
                EditEnabled = true,
                DeleteEnabled = false
            };

            return model;


        }
    }
}
