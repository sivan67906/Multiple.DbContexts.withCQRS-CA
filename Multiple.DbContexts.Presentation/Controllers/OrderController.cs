using Microsoft.AspNetCore.Mvc;
using Multiple.DbContexts.Application.Order.Commands.CreateOrder;
using Multiple.DbContexts.Application.Order.Commands.DeleteOrder;
using Multiple.DbContexts.Application.Order.Commands.UpdateOrder;
using Multiple.DbContexts.Application.Order.Queries.GetOrderById;
using Multiple.DbContexts.Application.Order.Queries.GetOrders;

namespace Multiple.DbContexts.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ApiBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orderList = await Mediator.Send(new GetOrdersQuery());
        return Ok(orderList);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommand entity)
    {
        var newOrder = await Mediator.Send(entity);

        return CreatedAtAction(nameof(GetById), new { id = newOrder.Id }, newOrder);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await Mediator.Send(new GetOrderByIdQuery() { Id = id });

        return Ok(order);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateOrderCommand entity)
    {
        if (id != entity.Id)
            return BadRequest();

        var upOrder = await Mediator.Send(entity);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var delOrder = await Mediator.Send(new DeleteOrderCommand() { Id = id });

        return NoContent();
    }
}
