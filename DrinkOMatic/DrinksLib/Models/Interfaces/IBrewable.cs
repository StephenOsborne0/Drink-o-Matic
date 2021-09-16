using System.Threading;
using System.Threading.Tasks;

namespace DrinksLib.Models
{
    interface IBrewable
    {
        Task Brew(CancellationToken ct);
    }
}
