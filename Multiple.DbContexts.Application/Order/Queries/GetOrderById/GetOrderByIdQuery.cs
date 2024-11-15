using MediatR;
using Multiple.DbContexts.Application.Common.DTOs;

namespace Multiple.DbContexts.Application.Order.Queries.GetOrderById;

public class GetOrderByIdQuery : IRequest<OrderDTO>
{
    public int Id { get; set; }
}
