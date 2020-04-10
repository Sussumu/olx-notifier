using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OlxNotifier.TelegramBot.Clients;
using OlxNotifier.TelegramBot.Configurations;

namespace OlxNotifier.TelegramBot
{
    public partial class Startup
    {
        private void ConfigureDependecyInjection(IServiceCollection services)
        {
            var telegramConfig = new TelegramApiConfiguration();
            Configuration.Bind(telegramConfig);
            services.AddSingleton(telegramConfig);

            services.AddHttpClient<TelegramClient>();
        }
    }
}
