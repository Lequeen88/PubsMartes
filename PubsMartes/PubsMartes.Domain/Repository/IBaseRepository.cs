﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PubsMartes.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        List<TEntity> GetEntities();
        TEntity GetEntityByID(int ID);
        List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter);
        bool Exists(Expression<Func<TEntity, bool>> filter);
    }
}
