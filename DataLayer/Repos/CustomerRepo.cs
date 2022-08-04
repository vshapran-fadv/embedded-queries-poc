using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DataLayer.Model;

namespace DataLayer.Repos
{
    internal sealed class CustomerRepo : ICustomerRepo
    {
        private readonly DbConnection _cnn;
        private readonly DbTransaction _tran;

        public CustomerRepo(UnitOfWork.UnitOfWork unitOfWork)
        {
            _cnn = unitOfWork.Connection;
            _tran = unitOfWork.Transaction;
        }

        public async Task<IReadOnlyCollection<Customer>> LoadAll(CancellationToken ct)
        {
            var query = QueryLoader.Get("LoadAll");

            var all = await _cnn.QueryAsync<Customer>(query,
                transaction: _tran);

            return all.AsReadOnly();
        }

        public async Task<Customer?> LoadByName(string name, CancellationToken ct)
        {
            var query = QueryLoader.Get("LoadByName");
            var param = new DynamicParameters(new { name });

            var customer = await _cnn.QueryFirstOrDefaultAsync<Customer>(query,
                param, _tran);

            return customer;
        }

        public Task<int> AddNew(CustomerData customer, CancellationToken ct)
        {
            var query = QueryLoader.Get("AddNew");
            var param = new DynamicParameters(customer);

            return _cnn.ExecuteScalarAsync<int>(query, param, _tran);
        }

        public Task Delete(int id, CancellationToken ct)
        {
            var query = QueryLoader.Get("Delete");
            var param = new DynamicParameters(new { id });

            return _cnn.ExecuteAsync(query, param, _tran);
        }
    }
}