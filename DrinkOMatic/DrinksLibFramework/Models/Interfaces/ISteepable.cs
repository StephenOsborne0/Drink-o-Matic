using System.Threading;
using System.Threading.Tasks;

namespace DrinksLibFramework.Models.Interfaces
{
    public interface ISteepable
    {
        Task Steep(CancellationToken ct);
    }
}
