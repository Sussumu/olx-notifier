using OlxNotifier.Domain.Models;
using OlxNotifier.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlxNotifier.Console.Services
{
    public class Processor : IProcessor
    {
        public IScraper Scraper { get; }

        public Processor(IScraper scraper)
        {
            Scraper = scraper ?? throw new ArgumentNullException(nameof(scraper));
        }

        public async Task<List<Entry>> Run()
        {
            return await Scraper.GetEntries();
        }
    }
}
