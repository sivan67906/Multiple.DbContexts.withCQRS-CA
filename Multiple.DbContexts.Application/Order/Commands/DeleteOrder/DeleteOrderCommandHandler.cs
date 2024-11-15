using Domain.DbContexts.Domain.Interfaces;
using MediatR;

namespace Multiple.DbContexts.Application.Order.Commands.DeleteOrder;

public class DeleteOrderCommandHandler(
    IRepository<Domain.DbContexts.Domain.Entities.Order> repositoryOrder) 
    : IRequestHandler<DeleteOrderCommand, int>
{
    public async Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await repositoryOrder.GetByIdAsync(request.Id);
        var result = await repositoryOrder.DeleteAsync(order);
        return result;
    }
}
