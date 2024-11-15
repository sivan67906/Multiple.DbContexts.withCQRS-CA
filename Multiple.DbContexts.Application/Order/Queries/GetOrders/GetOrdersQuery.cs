using MediatR;
using Multiple.DbContexts.Application.Common.DTOs;

namespace Multiple.DbContexts.Application.Order.Queries.GetOrders;

public class GetOrdersQuery : IRequest<IEnumerable<OrderDTO>>
{
}
