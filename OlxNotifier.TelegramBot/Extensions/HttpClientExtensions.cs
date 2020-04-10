using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OlxNotifier.TelegramBot.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> CustomPost<T>(this HttpClient client, string url, object requestBody)
        {
            var serializedRequest = JsonSerializer.Serialize(
                requestBody,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            var response = await client.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Content = new StringContent(serializedRequest, Encoding.UTF8, "application/json")
            });

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<T>(content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

            return result;
        }
    }
}
