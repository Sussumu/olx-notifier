using OlxNotifier.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlxNotifier.Console.Services
{
    public interface IProcessor
    {
        Task<List<Entry>> Run();
    }
}