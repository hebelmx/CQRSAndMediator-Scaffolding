using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Client.Api
{
    public class ProjectApiService
    {
        private readonly ILogger<ProjectApiService> _logger;
        private readonly HttpClient _httpClient;

        public ProjectApiService(ILogger<ProjectApiService> logger, HttpClient httpClient) =>
            (_logger, _httpClient) = (logger, httpClient);

        public Task<TResponse> GetAsync<TResponse>(string path)
        {
            _logger.LogInformation($"GET: Retrieving resource of type {typeof(TResponse).Name}");
            return _httpClient.GetFromJsonAsync<TResponse>(path);
        }

        public Task<HttpResponseMessage> PostAsync<TBody>(string path, TBody body)
        {
            _logger.LogInformation($"POST: Creating resource of type {typeof(TBody).Name}");
            return _httpClient.PostAsJsonAsync(path, body);
        }

        public Task<HttpResponseMessage> PutAsync<TBody>(string path, TBody body)
        {
            _logger.LogInformation($"PUT: Updating resource of type {typeof(TBody).Name}");
            return _httpClient.PutAsJsonAsync(path, body);
        }

        public Task<HttpResponseMessage> DeleteAsync(string path)
        {
            _logger.LogInformation("DELETE: Removing resource");
            return _httpClient.DeleteAsync(path);
        }
    }
}