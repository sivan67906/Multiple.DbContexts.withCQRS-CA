using Domain.DbContexts.Domain.Interfaces;
using MediatR;
using Multiple.DbContexts.Application.Common.DTOs;

namespace Multiple.DbContexts.Application.Order.Queries.GetOrders;

public class GetOrdersQueryHandler(
    IRepository<Domain.DbContexts.Domain.Entities.Product> repositoryProduct,
    IRepository<Domain.DbContexts.Domain.Entities.Order> repositoryOrder
    ) : IRequestHandler<GetOrdersQuery, IEnumerable<OrderDTO>>
{
    public async Task<IEnumerable<OrderDTO>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var products = await repositoryProduct.GetAllAsync();
        var orders = await repositoryOrder.GetAllAsync();

        var orderList = from order in orders
                        join product in products on order.ProductId equals product.Id
                        select new OrderDTO
                        {
                            Id = order.Id,
                            OrderName = order.OrderName,
                            OrderDate = order.OrderDate,
                            ProductName = product.Name,
                            ProductPrice = product.Price,
                            ProductQuantity = product.Quantity
                        };

        return orderList;
    }
}
