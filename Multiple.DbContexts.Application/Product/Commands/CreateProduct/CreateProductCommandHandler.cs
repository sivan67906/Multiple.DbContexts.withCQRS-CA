using Domain.DbContexts.Domain.Interfaces;
using MediatR;
using Multiple.DbContexts.Application.Common.DTOs;

namespace Multiple.DbContexts.Application.Product.Commands.CreateProduct;

public class CreateProductCommandHandler(IRepository<Domain.DbContexts.Domain.Entities.Product> repository)
    : IRequestHandler<CreateProductCommand, ProductDTO>
{
    public async Task<ProductDTO> Handle(
        CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.DbContexts.Domain.Entities.Product
        {
            Name = request.Name,
            Quantity = request.Quantity,
            Price = request.Price
        };
        var createProduct = await repository.CreateAsync(entity);
        var result = new ProductDTO
        {
            Id = createProduct.Id,
            Name = createProduct.Name,
            Quantity = createProduct.Quantity,
            Price = createProduct.Price
        };
        return result;
    }
}
