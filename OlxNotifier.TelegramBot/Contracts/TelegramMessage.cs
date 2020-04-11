using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OlxNotifier.TelegramBot.Contracts
{
    public class TelegramMessage
    {
        [JsonPropertyName("message_id")]
        public int Id { get; set; }

        [JsonPropertyName("from")]
        public TelegramUser User { get; set; }

        [JsonPropertyName("date")]
        public int UnixDate { get; set; }

        public string Text { get; set; }

        public List<Telegramentity> Entities { get; }

        public DateTime DateTimeUtc
        {
            get => DateTimeOffset.FromUnixTimeSeconds(UnixDate).DateTime;
        }
    }
}