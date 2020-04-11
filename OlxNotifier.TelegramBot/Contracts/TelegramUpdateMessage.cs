using System.Text.Json.Serialization;

namespace OlxNotifier.TelegramBot.Contracts
{
    public class TelegramUpdateMessage
    {
        [JsonPropertyName("message_id")]
        public int Id { get; set; }

        [JsonPropertyName("from")]
        public TelegramUpdateUser User { get; set; }

        [JsonPropertyName("date")]
        public int UnixDate { get; set; }

        public string Text { get; set; }
    }
}