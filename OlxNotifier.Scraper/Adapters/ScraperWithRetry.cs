using OlxNotifier.Domain.Models;
using OlxNotifier.Domain.Ports;
using Polly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlxNotifier.Scraper.Adapters
{
    public class ScraperWithRetry : IScraper
    {
        public IScraper Scraper { get; }

        public ScraperWithRetry(IScraper scraper)
        {
            Scraper = scraper ?? throw new ArgumentNullException(nameof(scraper));
        }

        public async Task<List<Entry>> GetEntries()
        {
            var result = await Policy
                .Handle<Exception>()
                .RetryAsync(3)
                .ExecuteAndCaptureAsync(() => Scraper.GetEntries());

            if (result.Outcome == OutcomeType.Successful)
                return result.Result;

            // TODO: log 

            return new List<Entry>();
        }
    }
}
