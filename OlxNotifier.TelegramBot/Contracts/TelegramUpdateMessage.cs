using System;
using System.Collections.Generic;
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

        public List<TelegramUpdateEntities> Entities { get; }

        public DateTime DateTimeUtc
        {
            get => DateTimeOffset.FromUnixTimeSeconds(UnixDate).DateTime;
        }
    }
}