using System.Collections.Generic;
using System.Threading.Tasks;
using Produto.Domain.Entities;

namespace Produto.Domain.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task Insert(Product product);

        Task<IEnumerable<Product>> GetAll();

        Task<Product> Get(long id);

        void Update(Product product);

        void Remove(Product product);
    }
}
