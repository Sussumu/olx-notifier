using System.Threading.Tasks;

namespace OlxNotifier
{
    class Program
    {
        // TODO: use that interface we just create
        // TODO: find a way to actually notify instead of just bring the results
        static async Task Main(string[] args)
        {
            var scraper = new Scraper.Adapters.Scraper();

            var entries = await scraper.GetEntries();
        }
    }
}
