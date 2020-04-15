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
            var urlRegex = new Regex(Config.UrlRegex);

            return cells
                .Where(x => x.TextContent.Length > 0)
                .Select(x => new Entry
                {
                    Title = titleRegex.Match(x.TextContent).Value.Substring(1, x.TextContent.Length - 1),
                    Price = priceRegex.Match(x.TextContent).Value,
                    Date = dateRegex.Match(x.TextContent).Groups[1].Value,
                    Time = dateRegex.Match(x.TextContent).Groups[2].Value,
                    Url = urlRegex.Match(x.InnerHtml).Groups[0].Value
                })
                .ToList();
        }
    }
}
