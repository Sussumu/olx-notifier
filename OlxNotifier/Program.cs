using AngleSharp;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OlxNotifier
{
    class Program
    {
        static async Task Main(string[] args)
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

            var titles = cells
                .Where(x => x.TextContent.Length > 0)
                .Select(x => x.TextContent.Substring(1, x.TextContent.Length - 1))
                .Select(x => new
                {
                    Title = titleRegex.Match(x),
                    Price = priceRegex.Match(x),
                    Date = dateRegex.Match(x).Groups[1],
                    Time = dateRegex.Match(x).Groups[2],
                })
                .ToList();
        }
    }
}
