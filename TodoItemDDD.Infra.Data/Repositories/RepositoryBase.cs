using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TodoItemDDD.Domain.Interfaces.Repositories;
using TodoItemDDD.Infra.Data.Contexto;

namespace TodoItemDDD.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected TodoItemDDDContext Db = new TodoItemDDDContext();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

       public IEnumerable<TEntity> GetAll()
       {
           return Db.Set<TEntity>().ToList();
       }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}