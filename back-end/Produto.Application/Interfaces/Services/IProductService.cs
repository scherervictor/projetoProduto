using Produto.Application.Dtos;
using Produto.Domain.Bases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Produto.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<BaseResult> Insert(ProductDto product);

        Task<BaseResult<List<ProductDto>>> GetAll();

        Task<BaseResult<ProductDto>> Remove(long id);

        Task<BaseResult> Update(ProductDto productDto);
    }
}
