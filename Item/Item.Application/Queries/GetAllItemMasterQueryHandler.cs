using Item.Application.Models;
using Item.Domain.AggregatesModel.ItemAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
namespace Item.Application.Queries
{
    class GetAllItemMasterQueryHandler : IRequestHandler<GetAllItemMasterQuery, ItemMasterListViewModel>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMediator _mediator;

        // Using DI to inject infrastructure persistence Repositories
        public GetAllItemMasterQueryHandler(IMediator mediator, IItemRepository itemRepository)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<ItemMasterListViewModel> Handle(GetAllItemMasterQuery request, CancellationToken cancellationToken)
        {

            List<ItemDTO> _items = _itemRepository.GetAllAsync().Result.Select(ItemDTO.ProjectionDTO()).Cast<ItemDTO>().ToList();

            var viewModel = new ItemMasterListViewModel
            {
                Items = _items,
                CreateEnabled = true
            };

            return viewModel;
        }

    }
}
