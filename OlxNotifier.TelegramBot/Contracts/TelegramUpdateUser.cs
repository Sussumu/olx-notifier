using System.Text.Json.Serialization;

namespace OlxNotifier.TelegramBot.Contracts
{
    public class TelegramUpdateUser
    {
        public int Id { get; set; }

        [JsonPropertyName("is_bot")]
        public bool Bot { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }
    }
}