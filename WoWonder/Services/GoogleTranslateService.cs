using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WoWonder.Services
{
    public class GoogleTranslateService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GoogleTranslateService(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
        }

        public async Task<string> TranslateTextAsync(string text, string sourceLang, string targetLang)
        {
            var requestBody = new
            {
                q = text,
                source = sourceLang,
                target = targetLang,
                format = "text"
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var url = $"https://translation.googleapis.com/language/translate/v2?key={_apiKey}";
            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                return $"[Error: {response.StatusCode}]";
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseBody);
            return doc.RootElement
                .GetProperty("data")
                .GetProperty("translations")[0]
                .GetProperty("translatedText")
                .GetString();
        }
    }
}
