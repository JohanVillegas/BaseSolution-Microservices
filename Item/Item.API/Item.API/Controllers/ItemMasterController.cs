using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Item.Application.Commands;
using Item.Application.Models;
using Item.Application.Queries;
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

        // GET: api/Products
        [HttpGet]
        public Task<ItemMasterListViewModel> GetItemMaster()
        {
            return _mediator.Send(new GetAllItemMasterQuery());
        }

        //POST: api/ItemMaster
        [HttpPost]
        public async Task<IActionResult> PostItemMaster([FromBody] CreateItemMasterCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        //PUT: api/ItemMaster
        [HttpPut]
        public async Task<IActionResult> PutItemMaster([FromBody] UpdateItemMasterCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}