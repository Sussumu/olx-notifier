﻿using OlxNotifier.TelegramBot.Contracts;
using System.Threading.Tasks;

namespace OlxNotifier.TelegramBot.Middlewares
{
    public class WebhookHandler : IWebhookHandler
    {
        public Task Process(TelegramRequest request)
        {
            // Log

            // Answer properly

            return Task.FromResult(0);
        }
    }
}
