using System.Threading.Tasks;
using System.Threading;
using WorkerSpace.Models;
using WorkerSpace.WinUtils;

namespace WorkerSpace.Interfaces
{
    public interface ITask
    {
        CancellationTokenSource CancellationToken { get; }

        TaskBits GetBits { get; }

        Task<HANDLE> StartAsync();
        Task<HANDLE> ExecuteAsync();
        Task<HANDLE> StopAsync();
    }
}
