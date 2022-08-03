using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataLayer.Model;

namespace DataLayer.Repos
{
    public interface ICustomerRepo
    {
        Task<IReadOnlyCollection<Customer>> LoadAll(CancellationToken ct);

        Task<Customer?> LoadByName(string name, CancellationToken ct);

        Task<int> AddNew(CustomerData customer, CancellationToken ct);

        Task Delete(int id, CancellationToken ct);
    }
}