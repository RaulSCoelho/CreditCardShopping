using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CreditCardShopping.Web.Utils
{
    public static class HttpClientExtensions
    {
        private static MediaTypeHeaderValue contentType
            = new MediaTypeHeaderValue("application/json");
        public static async Task<T?> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException("Ocorreu algo de errado com a API: " + $"{await response.Content.ReadAsStringAsync()}");

            var dataString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (dataString.Contains("\"value\""))
            {
                var json = JsonDocument.Parse(dataString);
                var valueExist = json.RootElement.GetProperty("value");
                dataString = valueExist.ToString();
            }

            T? deserializado = JsonSerializer.Deserialize<T>(dataString,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
                });

            return deserializado;
        }

        public static async Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data, new JsonSerializerOptions()
            {
                IgnoreNullValues = true
            });
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;
            var response = await httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException("Ocorreu algo de errado com a API: " + $"{await response.Content.ReadAsStringAsync()}");

            return response;
        }

        public static async Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;
            var response = await httpClient.PutAsync(url, content);
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException("Ocorreu algo de errado com a API: " + $"{await response.Content.ReadAsStringAsync()}");

            return response;
        }

        public static async Task<HttpResponseMessage> PatchAsJson<T>(this HttpClient httpClient, string url, T data)
        {

            var dataAsString = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            });
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;
            var response = await httpClient.PatchAsync(url, content);

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException("Ocorreu algo de errado com a API: " + $"{await response.Content.ReadAsStringAsync()}");

            return response;
        }
    }
}
