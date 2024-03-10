using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PubsMartes.Domain.Repository;
using PubsMartes.Infrastructure.Context;
using System.Linq.Expressions;


namespace PubsMartes.Infrastructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly PubsMartesContext context;

        private DbSet<TEntity> entities;

        public BaseRepository(PubsMartesContext context)
        {
            this.context = context;
            this.entities = context.Set<TEntity>();
        }
        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Any(filter);
        }

        public virtual List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return this.entities.ToList();
        }

        public virtual TEntity GetEntityByID(int ID)
        {
            return this.entities.Find(ID);
        }

        public virtual void Remove(TEntity entity)
        {
            entities.Remove(entity);
        }

        public virtual void Save(TEntity entity)
        {
            entities.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            entities.Update(entity);
        }
    }
}
