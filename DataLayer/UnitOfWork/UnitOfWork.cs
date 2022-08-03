using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace DataLayer.UnitOfWork
{
    internal sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(DbConnection connection)
        {
            Connection = connection;
            Transaction = connection.BeginTransaction();
        }

        public DbConnection Connection { get; }

        public DbTransaction Transaction { get; }

        public Task Complete(CancellationToken ct) =>
            Transaction.CommitAsync(ct);

        public void Dispose()
        {
            Transaction.Dispose();
            Connection.Dispose();
        }
    }
}