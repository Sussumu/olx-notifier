using OlxNotifier.TelegramBot.Contracts;
using System.Threading.Tasks;

namespace OlxNotifier.TelegramBot.Clients
{
    public interface ITelegramClient
    {
        Task<TelegramResult> SetWebhook(SetWebhookRequest request);
    }
}