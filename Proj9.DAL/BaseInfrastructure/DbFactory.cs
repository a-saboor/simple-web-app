using Microsoft.EntityFrameworkCore;
using Proj9.DAL.Entities;
using System;

namespace Proj9.DAL.BaseInfrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        DB9Context dbContext;

        public DB9Context Init()
        {
            var contextOptions = new DbContextOptionsBuilder<DB9Context>()
                .UseSqlServer(@"Data source=.\SQLEXPRESS01;Initial Catalog=DB9;User ID=sa;Password=123")
                .Options;
            return dbContext ?? (dbContext = new DB9Context(contextOptions));
        }
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }


    }

    public class Disposable : IDisposable
    {
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        // Ovveride this to dispose custom objects
        protected virtual void DisposeCore()
        {
        }
    }

    public interface IDbFactory : IDisposable
    {
        DB9Context Init();
    }
}