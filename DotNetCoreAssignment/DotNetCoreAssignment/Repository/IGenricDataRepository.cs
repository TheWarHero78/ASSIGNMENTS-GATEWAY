using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DotNetCoreAssignment.Repository
{
    /// <summary>
    /// Interface for GenericDataRepository with T as generic passing Model class when called
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericDataRepository<T> where T : class
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        bool Add(params T[] items);
        bool Update(params T[] items);
        bool Remove(params T[] items);
    }
}
