using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produto.Application.Dtos;
using Produto.Application.Interfaces.Services;
using Produto.Application.Mappers;
using Produto.Application.Validation;
using Produto.Domain.Bases;
using Produto.Domain.Entities;
using Produto.Domain.Interfaces.Repository;

namespace Produto.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;            
        }

        public async Task<BaseResult<List<ProductDto>>> GetAll()
        {
            var result = new BaseResult<List<ProductDto>>();

            var products = await _productRepository.GetAll();

            if (!products.Any())
            {
                result.Messages.Add("No registers found");
                return result;
            }

            result.Data = products.Select(ProductMapper.MapDto).ToList();

            return result;
        }

        public async Task<BaseResult> Insert(ProductDto productDto)
        {
            var result = new BaseResult();

            var validator = new ProductValidator();
            var validationResults = validator.Validate(productDto);

            if (!validationResults.IsValid)
            {
                result.Messages.AddRange(validationResults.Errors.Select(x => x.ErrorMessage));
                return result;
            }

            var product = ProductMapper.Map(productDto);

            await _productRepository.Insert(product);

            return result;
        }

        public async Task<BaseResult<ProductDto>> Remove(long id)
        {
            var result = new BaseResult<ProductDto>();

            var product = await _productRepository.Get(id);

            if (product == null)
            {
                result.Messages.Add("Register not found");
                return result;
            }

            _productRepository.Remove(product);

            result.Data = ProductMapper.MapDto(product);

            return result;
        }

        public async Task<BaseResult> Update(ProductDto productDto)
        {
            var result = new BaseResult<Product>();

            var product = await _productRepository.Get(productDto.Id);

            if (product == null)
            {
                result.Messages.Add("Register not found");
                return result;
            }

            var validator = new ProductValidator();
            var validationResults = validator.Validate(productDto);

            if (!validationResults.IsValid)
            {
                result.Messages.AddRange(validationResults.Errors.Select(x => x.ErrorMessage));
                return result;
            }

            var newProduct = ProductMapper.MapUpdate(productDto);

            product.Update(newProduct);

            _productRepository.Update(product);

            return result;
        }
    }
}
