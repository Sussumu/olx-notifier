using AngleSharp;
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
        // TODO: move url to configuration
        // TODO: move tag to query entries to configuration
        // TODO: handle connection errors
        // TODO: handle parsing errors
        public async Task<List<Entry>> GetEntries()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://sp.olx.com.br/sao-paulo-e-regiao?q=nintendo%20switch&sf=1";
            var context = BrowsingContext.New(config);

            var document = await context.OpenAsync(address);

            var cellSelector = "li.sc-1fcmfeb-2.ggOGTJ";
            var cells = document.QuerySelectorAll(cellSelector);

            var titleRegex = new Regex("[^R$]*");
            var priceRegex = new Regex(@"(R\$ \d*\.?\d+)");
            var dateRegex = new Regex(@"([a-zA-Z]+)(\d+:\d+)");

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
