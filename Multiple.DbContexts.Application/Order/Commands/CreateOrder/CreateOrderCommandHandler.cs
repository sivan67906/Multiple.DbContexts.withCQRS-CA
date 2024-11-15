using Domain.DbContexts.Domain.Interfaces;
using MediatR;
using Multiple.DbContexts.Application.Common.DTOs;

namespace Multiple.DbContexts.Application.Order.Commands.CreateOrder;

public class CreateOrderCommandHandler(
    IRepository<Domain.DbContexts.Domain.Entities.Order> repositoryOrder,
    IRepository<Domain.DbContexts.Domain.Entities.Product> repositoryProduct) 
    : IRequestHandler<CreateOrderCommand, OrderDTO>
{
    public async Task<OrderDTO> Handle(
        CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var product = await repositoryProduct.GetByIdAsync(request.ProductId);
        if(product is null) return new OrderDTO();

        var entity = new Domain.DbContexts.Domain.Entities.Order
        {
            OrderName = request.OrderName,
            OrderDate = request.OrderDate,
            ProductId = product.Id
        };
        var createOrder = await repositoryOrder.CreateAsync(entity);
        var result = new OrderDTO
        {
            Id = createOrder.Id,
            OrderName = createOrder.OrderName,
            OrderDate = createOrder.OrderDate,
            ProductName = product.Name,
            ProductQuantity = product.Quantity,
            ProductPrice = product.Price
        };
        return result;
    }
}
