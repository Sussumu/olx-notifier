using System.Threading.Tasks;

namespace OlxNotifier.Console.Services
{
    public interface IProcessor
    {
        Task Run();
    }
}