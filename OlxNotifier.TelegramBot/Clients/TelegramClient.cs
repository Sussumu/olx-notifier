using OlxNotifier.TelegramBot.Configurations;
using OlxNotifier.TelegramBot.Contracts;
using OlxNotifier.TelegramBot.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OlxNotifier.TelegramBot.Clients
{
    public class TelegramClient : ITelegramClient
    {
        public HttpClient Client { get; }
        public TelegramApiConfiguration Config { get; }

        public TelegramClient(HttpClient client, TelegramApiConfiguration config)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            Config = config ?? throw new ArgumentNullException(nameof(config));

            client.BaseAddress = new Uri(config.TelegramApiUrl);
        }

        public async Task<TelegramResult> SetWebhook(SetWebhookRequest request)
        {
            return await Client.CustomPost<TelegramResult>(
                $"{Config.TelegramApiUrl}setWebhook",
                request);
        }

        public async Task<TelegramResult> SendMessage(MessageRequest request)
        {
            return await Client.CustomPost<TelegramResult>(
                $"{Config.TelegramApiUrl}sendMessage",
                request);
        }
    }
}
