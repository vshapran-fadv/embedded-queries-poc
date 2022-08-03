using System.Threading;
using System.Threading.Tasks;

namespace DataLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task Complete(CancellationToken ct);
    }
}