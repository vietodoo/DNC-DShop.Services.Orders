﻿using System.Threading.Tasks;
using DShop.Common.Dispatchers;
using DShop.Common.Types;
using DShop.Services.Orders.Dto;
using DShop.Services.Orders.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DShop.Services.Orders.Controllers
{
    [Route("[controller]")]
    public class OrdersController : BaseController
    {
        public OrdersController(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<OrderDto>>> Get([FromQuery] BrowseOrders query)
            => Collection(await QueryAsync(query));

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailsDto>> Get([FromRoute] GetOrder query)
            => Single(await QueryAsync(query));
    }
}
