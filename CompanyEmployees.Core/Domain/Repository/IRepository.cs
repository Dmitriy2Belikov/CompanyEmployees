using CompanyEmployees.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using X.PagedList;

namespace CompanyEmployees.Core.Domain.Repository
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        public TEntity Find(Guid id);
        public void Add(TEntity entity);
        public void AddRange(IEnumerable<TEntity> entities);
        public void Update(TEntity entity);
        public void UpdateRange(IEnumerable<TEntity> entities);
        public void Remove(TEntity entity);
        public void RemoveRange(IEnumerable<TEntity> entities);
        public TEntity[] List();
        public IPagedList<TEntity> PagedList(int pageNumber, int pageSize);
        public TResult[] Query<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> query);
        public void Load<TValue>(TEntity entity, Expression<Func<TEntity, TValue>> expression)
            where TValue : class;
        public void SaveChanges();
    }
}
