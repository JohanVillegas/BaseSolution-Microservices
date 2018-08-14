using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Item.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Item.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemMasterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemMasterController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        //POST: api/ItemMaster
        [HttpPost]
        public async Task<IActionResult> PostItemMaster([FromBody] CreateItemCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}