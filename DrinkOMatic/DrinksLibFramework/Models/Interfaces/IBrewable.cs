using System.Threading;
using System.Threading.Tasks;

namespace DrinksLibFramework.Models.Interfaces
{
    interface IBrewable
    {
        Task Brew(CancellationToken ct);
    }
}
