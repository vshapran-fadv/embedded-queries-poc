using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDbInitializer
    {
        Task Initialize();
    }
}