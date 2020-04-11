using Microsoft.AspNetCore.Http;
using OlxNotifier.TelegramBot.Configurations;
using OlxNotifier.TelegramBot.Contracts;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OlxNotifier.TelegramBot.Middlewares
{
    /// <summary>
    /// Setups a middleware that accepts dynamic route to hide it from the
    /// repository code. This is needed because Telegram webhook doesn't 
    /// have a secret key to authenticate.
    /// </summary>
    public class WebhookMiddleware
    {
        public RequestDelegate Next { get; }
        public TelegramApiConfiguration Config { get; }

        public WebhookMiddleware(
            RequestDelegate next,
            TelegramApiConfiguration config)
        {
            Next = next ?? throw new System.ArgumentNullException(nameof(next));
            Config = config ?? throw new System.ArgumentNullException(nameof(config));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path != Config.WebhookUrl)
            {
                await Next(context);
                return;
            }

            // TODO: not sure if it can happen but it needs to be handled
            if (context.Request.ContentLength.HasValue == false)
            {
                await Next(context);
                return;
            }

            var bodyLength = context.Request.ContentLength.Value;
            byte[] body = new byte[bodyLength];
            await context.Request.Body.ReadAsync(body);

            var bodyAsString = Encoding.UTF8.GetString(body);
            var parsedBody = JsonSerializer.Deserialize<TelegramUpdateRequest>(
                bodyAsString,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            context.Response.StatusCode = (int)HttpStatusCode.OK;
            return;
        }
    }
}
