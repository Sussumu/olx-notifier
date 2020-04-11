using System.Text.Json.Serialization;

namespace OlxNotifier.TelegramBot.Contracts
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EntityTypes
    {
        mention,
        hashtag,
        cashtag,
        bot_command,
        url,
        email,
        phone_number,
        text_link,
        text_mention
    }
}