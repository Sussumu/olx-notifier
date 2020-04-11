using Microsoft.AspNetCore.Mvc;
using OlxNotifier.TelegramBot.Clients;
using OlxNotifier.TelegramBot.Contracts;
using System;
using System.Threading.Tasks;

namespace OlxNotifier.TelegramBot.Controllers
{
    [ApiController]
    [Route("webhook")]
    public class WebhookConfigurationController : ControllerBase
    {
        public TelegramClient Client { get; }

        public WebhookConfigurationController(TelegramClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        // TODO: before deploying this api make sure to add authorization to all configuration endpoints like these
        [HttpPut]
        [Route("")]
        public async Task<TelegramResult> Set([FromBody]SetWebhookRequest request)
        {
            var response = await Client.SetWebhook(request);

            return response;
        }
    }
}
