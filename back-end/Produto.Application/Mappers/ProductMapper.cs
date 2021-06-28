using Produto.Application.Dtos;
using Produto.Domain.Entities;

namespace Produto.Application.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto MapDto(Product product) =>
            new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Value = product.Value,
                ImageURL = product.ImageURL
            };

        public static Product Map(ProductDto productdto) =>
            new Product(productdto.Name, productdto.Value, productdto.ImageURL);

        public static Product MapUpdate(ProductDto productdto) =>
            new Product(productdto.Id, productdto.Name, productdto.Value, productdto.ImageURL);
    }
}
