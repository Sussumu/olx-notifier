using OlxNotifier.TelegramBot.Contracts;
using System.Threading.Tasks;

namespace OlxNotifier.TelegramBot.Middlewares
{
    public interface IWebhookHandler
    {
        Task Process(TelegramUpdateRequest request);
    }
}
