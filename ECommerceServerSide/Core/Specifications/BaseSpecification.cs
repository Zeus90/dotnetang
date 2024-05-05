using Core.Specifications;
using System.Linq.Expressions;

namespace Infrastructure.Data.Repositorys
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> Orderby { get; private set; }

        public Expression<Func<T, object>> OrderbyDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

    protected void AddInclude(Expression<Func<T, object>> includeEx)
        {
            Includes.Add(includeEx);
        }
        protected void OrderBy(Expression<Func<T, object>> orderby)
        {
            this.Orderby = orderby;
        }
        protected void OrderByDescending(Expression<Func<T, object>> orderbyDescending)
        {
            this.OrderbyDescending = orderbyDescending;
        }
        protected void ApplyPaging(int skip, int take)
        {
            this.Skip = skip;
            this.Take = take;
            this.IsPagingEnabled = true;
        }
    }
}
