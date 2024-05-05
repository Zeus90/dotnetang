using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Infrastructure.Data.Repositorys;

namespace Core.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(int id) : base(x => 
        x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
        public ProductSpecification(ProductSpecsParams specsParams)
            : base (x => ((string.IsNullOrEmpty(specsParams.Search) || x.Name.ToLower().Contains(specsParams.Search)) &&
            !specsParams.TypeId.HasValue || x.ProductTypeId == specsParams.TypeId) && (
            !specsParams.BrandId.HasValue || x.ProductBrandId == specsParams.BrandId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            OrderBy(x => x.Name);
            ApplyPaging(specsParams.PageSize * (specsParams.PageIndex - 1), specsParams.PageSize);

            if (!string.IsNullOrEmpty(specsParams.Sort))
            {
                switch (specsParams.Sort)
                {
                    case "priceAsc":
                        OrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        OrderByDescending(x => x.Price);
                        break;
                    default:
                        OrderBy(x => x.Name);
                        break;
                }
            }
        }
    }
}
