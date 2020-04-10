using OlxNotifier.TelegramBot.Configurations;
using OlxNotifier.TelegramBot.Contracts;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OlxNotifier.TelegramBot.Clients
{
    public class TelegramClient : ITelegramClient
    {
        public HttpClient Client { get; }

        public TelegramClient(HttpClient client, TelegramApiConfiguration config)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));

            client.BaseAddress = new Uri(config.TelegramApiUrl);
        }

        public async Task<TelegramResult> SetWebhook(SetWebhookRequest request)
        {
            var serializedRequest = JsonSerializer.Serialize(request);

            var response = await Client.PostAsync("setWebhook", new StringContent(serializedRequest));

            response.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<TelegramResult>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}
