using System.Text.Json.Serialization;

namespace OlxNotifier.TelegramBot.Contracts
{
    public class TelegramUpdateRequest
    {
        [JsonPropertyName("update_id")]
        public int Id { get; set; }

        public TelegramUpdateMessage Message { get; set; }
    }
}
