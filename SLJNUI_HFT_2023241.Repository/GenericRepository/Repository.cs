﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLJNUI_HFT_2023241.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected RestaurantDbContext ctx;
        public Repository(RestaurantDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }

        public abstract T Read(int id);

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public abstract void Update(T item);
    }
}
