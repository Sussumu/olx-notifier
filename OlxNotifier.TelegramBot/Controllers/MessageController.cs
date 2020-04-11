using Microsoft.AspNetCore.Mvc;
using OlxNotifier.TelegramBot.Clients;
using OlxNotifier.TelegramBot.Contracts;
using System.Threading.Tasks;

namespace OlxNotifier.TelegramBot.Controllers
{
    [Route("message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public TelegramClient Client { get; }

        public MessageController(TelegramClient client)
        {
            Client = client ?? throw new System.ArgumentNullException(nameof(client));
        }

        [HttpPost]
        [Route("")]
        public async Task<TelegramResult> Post([FromBody] MessageRequest message)
        {
            return await Client.SendMessage(message);
        }
    }
}