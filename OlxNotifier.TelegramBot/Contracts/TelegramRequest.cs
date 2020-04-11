using System.Text.Json.Serialization;

namespace OlxNotifier.TelegramBot.Contracts
{
    public class TelegramRequest
    {
        [JsonPropertyName("update_id")]
        public int Id { get; set; }

        public TelegramMessage Message { get; set; }
    }
}
