using AngleSharp;
using OlxNotifier.Domain.Configurations;
using OlxNotifier.Domain.Models;
using OlxNotifier.Domain.Ports;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OlxNotifier.Scraper.Adapters
{
    // TODO: move url to configuration
    // TODO: move tag to query entries to configuration
    // TODO: handle connection errors
    // TODO: handle parsing errors
    public class Scraper : IScraper
    {
        public OlxConfiguration Config { get; }

        public Scraper(OlxConfiguration config)
        {
            Config = config ?? throw new System.ArgumentNullException(nameof(config));
        }

        public async Task<List<Entry>> GetEntries()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = Config.Url;
            var context = BrowsingContext.New(config);

            var document = await context.OpenAsync(address);

            var cellSelector = Config.EntriesClassName;
            var cells = document.QuerySelectorAll(cellSelector);

            var titleRegex = new Regex(Config.TitleRegex);
            var priceRegex = new Regex(Config.PriceRegex);
            var dateRegex = new Regex(Config.DateRegex);

            return cells
                .Where(x => x.TextContent.Length > 0)
                .Select(x => x.TextContent.Substring(1, x.TextContent.Length - 1))
                .Select(x => new Entry
                {
                    Title = titleRegex.Match(x).Value,
                    Price = priceRegex.Match(x).Value,
                    Date = dateRegex.Match(x).Groups[1].Value,
                    Time = dateRegex.Match(x).Groups[2].Value,
                })
                .ToList();
        }
    }
}
