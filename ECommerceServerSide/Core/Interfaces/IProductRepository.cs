using Core.Models;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<Product>> getAllProductsAsync();
        Task<Product> getProductByIdAsync(int id);
        Task<IReadOnlyList<ProductBrand>> getBrandAsync();
        Task<IReadOnlyList<ProductType>> getProductTypeAsync();
    }
}
