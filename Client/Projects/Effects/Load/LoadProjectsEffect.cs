using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Client.Projects.Actions.Load;
using Client.Projects.Dtos;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace Client.Projects.Effects.Load
{
    public class LoadProjectsEffect
         : Effect<LoadProjectsAction>
    {
        private readonly ILogger<LoadProjectsEffect> _logger;
        private readonly HttpClient _httpClient;

        public LoadProjectsEffect(ILogger<LoadProjectsEffect> logger, HttpClient httpClient) =>
            (_logger, _httpClient) = (logger, httpClient);

        protected override async Task HandleAsync(LoadProjectsAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation("Loading Projects...");

                // Add a little extra latency for dramatic effect...
                await Task.Delay(TimeSpan.FromMilliseconds(1000));
                var ProjectsResponse = await _httpClient.GetFromJsonAsync<IEnumerable<ProjectViewDto>>("Projects");

                _logger.LogInformation("Projects loaded successfully!");
                dispatcher.Dispatch(new LoadProjectsSuccessAction(ProjectsResponse));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error loading Projects, reason: {e.Message}");
                dispatcher.Dispatch(new LoadProjectsFailureAction(e.Message));
            }
        }
    }
}