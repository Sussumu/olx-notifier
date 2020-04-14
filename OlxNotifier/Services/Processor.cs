using OlxNotifier.Domain.Ports;
using OlxNotifier.TelegramBot.Clients;
using OlxNotifier.TelegramBot.Contracts;
using System;
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
            var newRequestResult = oldRequestResult;

            do
            {
                Thread.Sleep(10000);

                newRequestResult = await Scraper.GetEntries();

                var oldEntries = oldRequestResult.Select(o => o.Time);

                var newEntries = newRequestResult
                    .Where(n => oldEntries.Contains(n.Time) == false)
                    .ToList();

                foreach (var entry in newEntries)
                {
                    await TelegramClient
                        .SendMessage(new MessageRequest
                        {
                            Text = $"{entry.Title} - {entry.Price} - {entry.Time}"
                        });
                }

                oldRequestResult = await Scraper.GetEntries();
            }
            while (true);
        }
    }
}
