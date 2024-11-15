using MediatR;
using Multiple.DbContexts.Application.Common.DTOs;

namespace Multiple.DbContexts.Application.Order.Commands.UpdateOrder;

public class UpdateOrderCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? OrderName { get; set; }
    public int ProductId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
}
