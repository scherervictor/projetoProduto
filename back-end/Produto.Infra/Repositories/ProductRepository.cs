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
            return await _context.Product.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Product.AsNoTracking().ToListAsync();
        }

        public async Task<Product> Insert(Product product)
        {
            var result = await _context.Product.AddAsync(product);

            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public void Remove(Product product)
        {
            _context.Product.Remove(product);
            _context.SaveChangesAsync();
        }

        public void Update(Product product)
        {
            _context.Product.Update(product);
            _context.SaveChangesAsync();
        }
    }
}
