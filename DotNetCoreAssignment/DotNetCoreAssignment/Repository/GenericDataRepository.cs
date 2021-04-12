using DotNetCoreAssignment.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DotNetCoreAssignment.Repository
{

    /// <summary>
    /// Generic Data Repository Class implementing Generic Data Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        private readonly EmployeeDbContext context;
        public GenericDataRepository(EmployeeDbContext _context)
        {
            context = _context;
        }
        public virtual bool Add(params T[] items)
        {

            foreach (T item in items)
            {
                context.Entry(item).State = EntityState.Added;
            }
            return context.SaveChanges() > 0;

        }


        public virtual bool Update(params T[] items)
        {

            foreach (T item in items)
            {
                context.Entry(item).State = EntityState.Modified;
            }
            return context.SaveChanges() > 0;

        }

        public virtual bool Remove(params T[] items)
        {

            foreach (T item in items)
            {
                context.Entry(item).State = EntityState.Deleted;
            }
            return context.SaveChanges() > 0;

        }
        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;

            IQueryable<T> dbQuery = context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .ToList<T>();

            return list;
        }

        public virtual IList<T> GetList(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;

            IQueryable<T> dbQuery = context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .Where(where)
                .ToList<T>();
            return list;

        }

        public virtual T GetSingle(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;

            IQueryable<T> dbQuery = context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            item = dbQuery
                .AsNoTracking() //Don't track any changes for the selected item
                .FirstOrDefault(where); //Apply where clause

            return item;
        }


    }
}
