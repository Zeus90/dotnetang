using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceContext _context;

        public ProductRepository(EcommerceContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Product>> getAllProductsAsync()
        {
            return await _context.Products.Include(p => p.ProductBrand).Include(p => p.ProductType).ToListAsync();
        }

        public async Task<Product> getProductByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.ProductType).Include(p => p.ProductBrand).SingleOrDefaultAsync(p => p.Id == id);
        }

        async Task<IReadOnlyList<ProductBrand>> IProductRepository.getBrandAsync()
        {
            return await _context.ProductBrands.ToListAsync<ProductBrand>();
        }

        async Task<IReadOnlyList<ProductType>> IProductRepository.getProductTypeAsync()
        {
            return await _context.ProductTypes.ToListAsync<ProductType>();
        }
    }
}
