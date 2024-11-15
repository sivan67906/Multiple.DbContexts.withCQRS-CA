using MediatR;
using Multiple.DbContexts.Application.Common.DTOs;

namespace Multiple.DbContexts.Application.Order.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<OrderDTO>
{
    public string? OrderName { get; set; }
    public int ProductId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
}
