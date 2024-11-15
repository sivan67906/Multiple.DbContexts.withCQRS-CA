using Domain.DbContexts.Domain.Interfaces;
using MediatR;
using Multiple.DbContexts.Application.Common.DTOs;

namespace Multiple.DbContexts.Application.Order.Queries.GetOrderById;

public class GetOrderByIdQueryHandler(
    IRepository<Domain.DbContexts.Domain.Entities.Order> repositoryOrder,
    IRepository<Domain.DbContexts.Domain.Entities.Product> repositoryProduct
    ) : IRequestHandler<GetOrderByIdQuery, OrderDTO>
{
    public async Task<OrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await repositoryOrder.GetByIdAsync(request.Id);
        if(order is null) return new OrderDTO();

        var product = await repositoryProduct.GetByIdAsync(order.ProductId);
        var entity = new OrderDTO
        {
            Id = order.Id,
            OrderName = order.OrderName,
            OrderDate = order.OrderDate,
            ProductName = product.Name,
            ProductQuantity = product.Quantity,
            ProductPrice = product.Price
        };
        return entity;
    }
}
