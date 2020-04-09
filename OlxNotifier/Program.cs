using System.Threading.Tasks;

namespace OlxNotifier
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var scraper = new Scraper.Adapters.Scraper();

            var entries = await scraper.GetEntries();
        }
    }
}
