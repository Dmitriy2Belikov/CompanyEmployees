using CompanyEmployees.Core.Domain.Common;
using CompanyEmployees.Core.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using X.PagedList;

namespace CompanyEmployess.Infrastructure
{
    public class EFRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected CompanyContext Context;
        private DbSet<TEntity> entities => Context.Set<TEntity>();

        public EFRepository(CompanyContext context)
        {
            Context = context;
        }

        public TEntity Find(Guid id)
        {
            return this.entities.Find(id);
        }

        public void Add(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.entities.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            this.entities.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            this.entities.UpdateRange(entities);
        }

        public TEntity[] List()
        {
            return this.entities.ToArray();
        }

        public IPagedList<TEntity> PagedList(int pageNumber, int pageSize)
        {
            return this.entities.ToPagedList(pageNumber, pageSize);
        }

        public TResult[] Query<TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> query)
        {
            return query(this.entities).ToArray();
        }

        public void Remove(TEntity entity)
        {
            this.entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.entities.RemoveRange(entities);
        }

        public void Load<TValue>(TEntity entity, Expression<Func<TEntity, TValue>> expression)
            where TValue : class
        {
            Context.Entry(entity).Reference(expression).Load();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
