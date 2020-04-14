using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OlxNotifier.Console.Services;
using OlxNotifier.Domain.Configurations;
using OlxNotifier.Domain.Ports;
using OlxNotifier.Scraper.Adapters;
using OlxNotifier.TelegramBot.Clients;
using OlxNotifier.TelegramBot.Configurations;
using System.Threading.Tasks;

namespace OlxNotifier
{
    class Program
    {
        // TODO: find a way to actually notify instead of just bring the results
        static async Task Main(string[] args)
        {
            var provider = RegisterDependencyInjection();

            await provider.GetRequiredService<IProcessor>().Run();
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

            var telegramConfig = new TelegramApiConfiguration();
            configuration.Bind(telegramConfig);
            serviceCollection.AddSingleton(telegramConfig);

            serviceCollection.AddHttpClient<TelegramClient>();

            serviceCollection.AddTransient<IProcessor, Processor>();

            serviceCollection.AddTransient<IScraper, Scraper.Adapters.Scraper>();
            serviceCollection.Decorate<IScraper, ScraperWithRetry>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
