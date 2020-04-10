using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OlxNotifier.Console.Services;
using OlxNotifier.Domain.Configurations;
using OlxNotifier.Domain.Ports;
using System.Threading.Tasks;

namespace OlxNotifier
{
    class Program
    {
        // TODO: find a way to actually notify instead of just bring the results
        static async Task Main(string[] args)
        {
            var provider = RegisterDependencyInjection();

            var entries = await provider.GetRequiredService<IScraper>().GetEntries();
        }

        private static ServiceProvider RegisterDependencyInjection()
        {
            var serviceCollection = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var olxConfig = new OlxConfiguration();
            configuration.Bind(olxConfig);
            serviceCollection.AddSingleton(olxConfig);

            serviceCollection.AddTransient<IProcessor, Processor>();
            serviceCollection.AddTransient<IScraper, Scraper.Adapters.Scraper>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
