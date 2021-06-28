using Microsoft.EntityFrameworkCore;
using Produto.Domain.Entities;
using Produto.Domain.Interfaces.Repository;
using Produto.Infra.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Produto.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<Product> Get(long id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public Task Insert(Product product)
        {
            var result = _context.Products.AddAsync(product);

            _context.SaveChangesAsync();
            return result;
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChangesAsync();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChangesAsync();
        }
    }
}
