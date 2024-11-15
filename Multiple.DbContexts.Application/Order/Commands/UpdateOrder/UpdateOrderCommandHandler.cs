using Domain.DbContexts.Domain.Interfaces;
using MediatR;

namespace Multiple.DbContexts.Application.Order.Commands.UpdateOrder;

public class UpdateOrderCommandHandler(IRepository<Domain.DbContexts.Domain.Entities.Order> repository) : IRequestHandler<UpdateOrderCommand, int>
{
    public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.DbContexts.Domain.Entities.Order
        {
            Id = request.Id,
            OrderName = request.OrderName,
            ProductId = request.ProductId,
            OrderDate = request.OrderDate
        };

        var updateOrder = await repository.UpdateAsync(request.Id, entity);
        return updateOrder;
    }
}
