using Domain.DbContexts.Domain.Interfaces;
using MediatR;

namespace Multiple.DbContexts.Application.Product.Commands.UpdateProduct;

public class UpdateProductCommandHandler(IRepository<Domain.DbContexts.Domain.Entities.Product> repository) : IRequestHandler<UpdateProductCommand, int>
{
    public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.DbContexts.Domain.Entities.Product
        {
            Id = request.Id,
            Name = request.Name,
            Quantity = request.Quantity,
            Price = request.Price
        };

        var updateProduct = await repository.UpdateAsync(request.Id, entity);
        return updateProduct;
    }
}
