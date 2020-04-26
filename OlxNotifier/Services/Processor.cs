using OlxNotifier.Domain.Models;
using OlxNotifier.Domain.Ports;
using OlxNotifier.TelegramBot.Clients;
using OlxNotifier.TelegramBot.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OlxNotifier.Console.Services
{
    public class Processor : IProcessor
    {
        public IScraper Scraper { get; }
        public TelegramClient TelegramClient { get; }

        public Processor(IScraper scraper, TelegramClient telegramClient)
        {
            Scraper = scraper ?? throw new ArgumentNullException(nameof(scraper));
            TelegramClient = telegramClient ?? throw new ArgumentNullException(nameof(telegramClient));
        }

        public async Task Run()
        {
            var oldRequestResult = await Scraper.GetEntries();

            do
            {
                var newRequestResult = await Scraper.GetEntries();

                var newEntries = GetNewEntries(oldRequestResult, newRequestResult);

                foreach (var entry in newEntries)
                {
                    await TelegramClient
                        .SendMessage(new MessageRequest
                        {
                            Text = $"{entry.Title} - {entry.Price} - {entry.Time}"
                        });
                }

                oldRequestResult = newRequestResult;

                Thread.Sleep(10000);
            }
            while (true);
        }

        private static List<Entry> GetNewEntries(List<Entry> oldRequestResult, List<Entry> newRequestResult)
        {
            var oldEntries = oldRequestResult.Select(o => o.Url);

            var newEntries = newRequestResult
                .Where(n => oldEntries.Contains(n.Url) == false)
                .ToList();

            System.Console.WriteLine($"{newEntries.Count} new entries found!");

            return newEntries;
        }
    }
}
