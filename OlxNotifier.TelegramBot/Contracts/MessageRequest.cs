using System.Text.Json.Serialization;

namespace OlxNotifier.TelegramBot.Contracts
{
    public class MessageRequest
    {
        [JsonPropertyName("chat_id")]
        public int ChatId { get; set; } = 96032319; // TODO: remove and use the id from the sender

        public string Text { get; set; }

        [JsonPropertyName("disable_web_page_preview")]
        public bool DisablePagePreview { get; set; } = true;
    }
}
