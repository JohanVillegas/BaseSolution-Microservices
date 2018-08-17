using Item.Domain.AggregatesModel.ItemAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Item.Application.Commands
{
    public class CreateItemMasterCommandHandler : IRequestHandler<CreateItemMasterCommand, bool>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMediator _mediator;

        // Using DI to inject infrastructure persistence Repositories
        public CreateItemMasterCommandHandler(IMediator mediator, IItemRepository itemRepository)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreateItemMasterCommand request, CancellationToken cancellationToken)
        {
            // Add/Update the Buyer AggregateRoot
            // DDD patterns comment: Add child entities and value-objects through the Order Aggregate-Root
            // methods and constructor so validations, invariants and business logic 
            // make sure that consistency is preserved across the whole aggregate
            ItemMaster itemMaster = ItemMaster.AddItemMaster(request.Number, request.Name, request.ShortName, request.Description, request.DateTime, request.Active, request.UnitMeasureId, request.TypeId);

            _itemRepository.Add(itemMaster);

            return await _itemRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
