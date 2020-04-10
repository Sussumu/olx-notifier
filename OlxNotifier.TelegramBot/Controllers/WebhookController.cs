using Microsoft.AspNetCore.Mvc;
using OlxNotifier.TelegramBot.Clients;
using OlxNotifier.TelegramBot.Contracts;
using System;
using System.Threading.Tasks;

namespace OlxNotifier.TelegramBot.Controllers
{
    [ApiController]
    [Route("webhook")]
    public class WebhookController : ControllerBase
    {
        public TelegramClient Client { get; }

        public WebhookController(TelegramClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Set([FromBody]SetWebhookRequest request)
        {
            var response = await Client.SetWebhook(request);

            return Ok(response);
        }
    }
}
