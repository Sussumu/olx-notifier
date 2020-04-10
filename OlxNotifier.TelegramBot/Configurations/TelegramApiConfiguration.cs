using System;

namespace OlxNotifier.TelegramBot.Configurations
{
    public class TelegramApiConfiguration
    {
        private string telegramApiUrl;

        public string TelegramApiUrl
        {
            get => telegramApiUrl;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Telegram Api Url cannot be empty!");

                telegramApiUrl = value;
            }
        }
    }
}
