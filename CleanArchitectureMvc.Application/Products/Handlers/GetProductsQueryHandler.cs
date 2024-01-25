using CleanArchitectureMvc.Application.Products.Queries;
using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureMvc.Application.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsAsync();
        }
    }
}
