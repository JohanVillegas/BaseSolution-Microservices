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
    public class GetAllItemMasterQueryHandler : IRequestHandler<GetAllItemMasterQuery, ItemMasterListViewModel>
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

            var _items = await _itemRepository.GetAllAsync();

            var viewModelDTO = _items.Select(ItemDTO.ProjectionDTO()).ToList(); 

            var viewModel = new ItemMasterListViewModel
            {
                Items = viewModelDTO,
                CreateEnabled = true
            };

            return viewModel;
        }

    }
}
