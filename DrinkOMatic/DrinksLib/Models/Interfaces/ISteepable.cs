using System.Threading;
using System.Threading.Tasks;

namespace DrinksLib.Models
{
    public interface ISteepable
    {
        Task Steep(CancellationToken ct);
    }
}
