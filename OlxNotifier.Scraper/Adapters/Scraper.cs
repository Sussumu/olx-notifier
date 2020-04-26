using AngleSharp;
using AngleSharp.Dom;
using OlxNotifier.Domain.Configurations;
using OlxNotifier.Domain.Models;
using OlxNotifier.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OlxNotifier.Scraper.Adapters
{
    public class Scraper : IScraper
    {
        public OlxConfiguration Config { get; }

        private readonly Regex titleRegex;
        private readonly Regex priceRegex;
        private readonly Regex dateRegex;
        private readonly Regex urlRegex;

        public Scraper(OlxConfiguration config)
        {
            Config = config ?? throw new System.ArgumentNullException(nameof(config));

            titleRegex = new Regex(Config.TitleRegex);
            priceRegex = new Regex(Config.PriceRegex);
            dateRegex = new Regex(Config.DateRegex);
            urlRegex = new Regex(Config.UrlRegex);
        }

        public async Task<List<Entry>> GetEntries()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = Config.Url;
            var context = BrowsingContext.New(config);

            var document = await context.OpenAsync(address);

            var cellSelector = Config.EntriesClassName;
            var cells = document.QuerySelectorAll(cellSelector);

            return cells
                .Where(x => x.TextContent.Length > 0)
                .Select(GetEntry)
                .ToList();
        }

        private Entry GetEntry(IElement x)
        {
            return new Entry
            {
                Title = TryMatch(titleRegex, x.TextContent),//.Substring(1, x.TextContent.Length - 1),
                Price = TryMatch(priceRegex, x.TextContent),
                Date = TryMatch(dateRegex, x.TextContent, 1),
                Time = TryMatch(dateRegex, x.TextContent, 2),
                Url = TryMatch(urlRegex, x.InnerHtml),
            };
        }

        private string TryMatch(Regex regex, string text, int? group = null)
        {
            try
            {
                var match = regex.Match(text);

                if (group is null)
                    return match.Value;

                return match.Groups[group.Value].Value;
            }
            catch (Exception ex)
            {

                return string.Empty;
            }
        }
    }
}
