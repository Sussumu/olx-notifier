using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace OlxNotifier.TelegramBot.Controllers
{
    [ApiController]
    [Route("webhook")]
    public class WebhookController : ControllerBase
    {
        public HttpClient Client { get; }

        public WebhookController(HttpClient client)
        {
            Client = client ?? throw new System.ArgumentNullException(nameof(client));
        }

        [HttpPut]
        [Route("")]
        public IActionResult Set([FromBody]string url)
        {


            return Ok();
        }
    }
}
