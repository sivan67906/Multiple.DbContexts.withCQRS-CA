using Domain.DbContexts.Domain.Interfaces;
using MediatR;
using Multiple.DbContexts.Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple.DbContexts.Application.Product.Commands.DeleteProduct;

public class DeleteProductCommandHandler(
    IRepository<Domain.DbContexts.Domain.Entities.Product> repositoryProduct) : IRequestHandler<DeleteProductCommand, int>
{
    public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await repositoryProduct.GetByIdAsync(request.Id);
        var result = await repositoryProduct.DeleteAsync(product);
        return result;
    }
}
