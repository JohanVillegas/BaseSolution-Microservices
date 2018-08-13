using Item.Application.Models;
using Item.Domain.AggregatesModel.ItemAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Item.Application.Commands
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, bool>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMediator _mediator;

        // Using DI to inject infrastructure persistence Repositories
        public CreateItemCommandHandler(IMediator mediator, IItemRepository itemRepository)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            // Add/Update the Buyer AggregateRoot
            // DDD patterns comment: Add child entities and value-objects through the Order Aggregate-Root
            // methods and constructor so validations, invariants and business logic 
            // make sure that consistency is preserved across the whole aggregate

            var item = new ItemMaster();

            item.AddItemMaster(request.Number, request.Name, request.ShortName, request.Decription, request.DateTime, request.Active, request.UnitMeasureId, request.TypeId);

            _itemRepository.Add(item);

            return await _itemRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
