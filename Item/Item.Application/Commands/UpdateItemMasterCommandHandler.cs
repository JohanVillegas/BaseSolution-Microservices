using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Item.Domain.AggregatesModel.ItemAggregate;
using MediatR;

namespace Item.Application.Commands
{
    public class UpdateItemMasterCommandHandler : IRequestHandler<UpdateItemMasterCommand, bool>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMediator _mediator;

        // Using DI to inject infrastructure persistence Repositories
        public UpdateItemMasterCommandHandler(IMediator mediator, IItemRepository itemRepository)
        {
            _itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(UpdateItemMasterCommand request, CancellationToken cancellationToken)
        {
            ItemMaster itemMaster = ItemMaster.UpdateItemMaster(request.Id,request.Number, request.Name, request.ShortName, request.Description, request.DateTime, request.Active, request.UnitMeasureId, request.TypeId);

            _itemRepository.Update(itemMaster);

            return await _itemRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
