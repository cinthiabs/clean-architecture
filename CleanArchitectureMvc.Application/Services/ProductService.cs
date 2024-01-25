using AutoMapper;
using CleanArchitectureMvc.Application.DTOs;
using CleanArchitectureMvc.Application.Interfaces;
using CleanArchitectureMvc.Application.Products.Queries;
using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;
       // private readonly IMediator _mediator;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        //public ProductService(IMediator mediator, IMapper mapper)
        //{
        //    _mediator = mediator;
        //    _mapper = mapper;
        //}
        //public async Task<IEnumerable<ProductDTO>> GetProducts()
        //{
        //    var productsQuery = new GetProductQuery();
        //    if (productsQuery == null)
        //        throw new Exception($"Entity could not be loaded.");
        //    var result = await _mediator.Send(productsQuery);
        //    return _mapper.Map<IEnumerable<ProductDTO>>(result);
        //}

        
      public async Task<IEnumerable<ProductDTO>> GetProducts()
      {
          var productsEntity = await _productRepository.GetProductsAsync();
          return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
      }

      public async Task Add(ProductDTO productDTO)
      {
          var productEntity = _mapper.Map<Product>(productDTO);
          await _productRepository.CreateAsync(productEntity);
      }

      public async Task<ProductDTO> GetById(int? id)
      {
          var productEntity = await _productRepository.GetByIdAsync(id);
          return _mapper.Map<ProductDTO>(productEntity);
      }

      public async Task Remove(int? id)
      {
          var productEntity = _productRepository.GetByIdAsync(id).Result;
          await _productRepository.RemoveAsync(productEntity);
      }

      public async Task Update(ProductDTO productDTO)
      {
          var productEntity = _mapper.Map<Product>(productDTO);
          await _productRepository.UpdateAsync(productEntity);
      }
    }
}
