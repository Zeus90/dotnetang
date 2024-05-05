using Core.Models;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> Inputquery, ISpecification<TEntity> specs)
        {
            if (specs.Criteria != null)
            {
                Inputquery = Inputquery.Where(specs.Criteria);
            }

            if (specs.Orderby != null)
            {
                Inputquery = Inputquery.OrderBy(specs.Orderby);
            }

            if (specs.OrderbyDescending != null)
            {
                Inputquery = Inputquery.OrderByDescending(specs.OrderbyDescending);
            }

            if (specs.IsPagingEnabled)
            {
                Inputquery = Inputquery.Skip(specs.Skip).Take(specs.Take);
            }

            Inputquery = specs.Includes.Aggregate(Inputquery, (current, include) => current.Include(include));

            return Inputquery;
        }
    }
}
