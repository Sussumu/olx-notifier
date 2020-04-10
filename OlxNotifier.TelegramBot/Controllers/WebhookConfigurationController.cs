using Microsoft.AspNetCore.Mvc;
using OlxNotifier.TelegramBot.Clients;
using OlxNotifier.TelegramBot.Contracts;
using System;
using System.Net;
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

        [HttpPut]
        [Route("")]
        public async Task<TelegramResult> Set([FromBody]SetWebhookRequest request)
        {
            var response = await Client.SetWebhook(request);

            if (response.Ok == false)
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return response;
        }
    }
}
