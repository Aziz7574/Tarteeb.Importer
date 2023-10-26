//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================
using System.Linq.Expressions;

namespace Tarteeb.Importer.DataBase.DAL
{
    internal interface IStorageBroker<T> where T : class
    {
        public ValueTask<T> InsertAsync(T @object);

        public IQueryable<T> SelectAllAsync();

        public ValueTask<T> SelectObjectAsync(Expression<Func<T, bool>> expression);

        public ValueTask<T> UpdateObjectAsync(T @object);

        public ValueTask<T> DeleteAsync(Expression<Func<T, bool>> expression);
    }
}
