﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Zxw.Framework.NetCore.Models;

namespace Zxw.Framework.NetCore.EfDbContext
{
    public interface IEfDbContext:IDisposable
    {
        void Add<T>(T entity) where T : class;
        Task AddAsync<T>(T entity) where T : class;
        void AddRange<T>(ICollection<T> entities) where T : class;
        Task AddRangeAsync<T>(ICollection<T> entities) where T : class;
        int Count<T>(Expression<Func<T, bool>> @where = null) where T : class;
        Task<int> CountAsync<T>(Expression<Func<T, bool>> @where = null) where T : class;
        void Delete<T,TKey>(TKey key) where T : class;
        bool EnsureCreated();
        Task<bool> EnsureCreatedAsync();
        int ExecuteSqlWithNonQuery(string sql, params object[] parameters);
        Task<int> ExecuteSqlWithNonQueryAsync(string sql, params object[] parameters);
        void Edit<T>(T entity) where T : class;
        void EditRange<T>(ICollection<T> entities) where T : class;
        bool Exist<T>(Expression<Func<T, bool>> @where = null) where T : class;
        Task<bool> ExistAsync<T>(Expression<Func<T, bool>> @where = null) where T : class;
        T Find<T,TKey>(TKey key) where T : class;
        Task<T> FindAsync<T,TKey>(TKey key) where T : class;
        IQueryable<T> Get<T>(Expression<Func<T, bool>> @where = null) where T : class;
        DbSet<T> GetDbSet<T>() where T : class;
        T GetSingleOrDefault<T>(Expression<Func<T, bool>> @where = null) where T : class;
        T GetSingleOrDefault<T>(Func<IQueryable<T>, IQueryable<T>> includeFunc, Expression<Func<T, bool>> @where = null) where T : class;
        Task<T> GetSingleOrDefaultAsync<T>(Expression<Func<T, bool>> @where = null) where T : class;
        void Update<T>(T model, params string[] updateColumns) where T : class;
        int Update<T>(Expression<Func<T, bool>> @where, Expression<Func<T, T>> updateFactory) where T : class;
        Task<int> UpdateAsync<T>(Expression<Func<T, bool>> @where, Expression<Func<T, T>> updateFactory)
            where T : class;
        int Delete<T>(Expression<Func<T, bool>> @where) where T : class;
        Task<int> DeleteAsync<T>(Expression<Func<T, bool>> @where) where T : class;
        void BulkInsert<T, TKey>(IList<T> entities, string destinationTableName = null)
            where T : class, IBaseModel<TKey>;
        List<TView> SqlQuery<T, TView>(string sql, params object[] parameters) 
            where T : class
            where TView : class;
        Task<List<TView>> SqlQueryAsync<T, TView>(string sql, params object[] parameters)
            where T : class
            where TView : class;
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,CancellationToken cancellationToken = default(CancellationToken));
        int SaveChangesWithTriggers();
        int SaveChangesWithTriggers(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesWithTriggersAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveChangesWithTriggersAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
        //Action<IInsertedEntry<T, DbContext>> AfterInsertedTrigger<T>() where T:class;
    }
}