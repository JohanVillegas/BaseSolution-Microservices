using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Item.Domain.AggregatesModel.ItemAggregate;
using MediatR;
namespace Item.Application.Commands
{
    class DeleteItemMasterCommandHandler : IRequestHandler<DeleteItemMasterCommand>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMediator _mediator;

        // Using DI to inject infrastructure persistence Repositories
        public DeleteItemMasterCommandHandler(IMediator mediator, IItemRepository itemRepository)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Unit> Handle(DeleteItemMasterCommand request, CancellationToken cancellationToken)
        {
            var itemMaster = await _itemRepository.GetAsync(request.Id);
            _itemRepository.Delete(itemMaster);
 
            await _itemRepository.UnitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
