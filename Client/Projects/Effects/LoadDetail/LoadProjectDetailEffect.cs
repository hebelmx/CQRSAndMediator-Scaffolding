using System;
using System.Threading.Tasks;
using Client.Api;
using Client.Projects.Actions.LoadDetail;
using Client.Projects.Dtos;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace Client.Projects.Effects.LoadDetail
{
    public class LoadProjectDetailEffect : Effect<LoadProjectDetailAction>
    {
        private readonly ILogger<LoadProjectDetailEffect> _logger;
        private readonly ProjectApiService _apiService;

        public LoadProjectDetailEffect(ILogger<LoadProjectDetailEffect> logger, ProjectApiService httpClient) =>
            (_logger, _apiService) = (logger, httpClient);

        protected override async Task HandleAsync(LoadProjectDetailAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation($"Loading project {action.Id}...");
                var projectResponse = await _apiService.GetAsync<ProjectViewDto>($"projects/{action.Id}");

                _logger.LogInformation($"Project {action.Id} loaded successfully!");
                dispatcher.Dispatch(new LoadProjectDetailSuccessAction(projectResponse));
            }
            catch (Exception e)
            {
                _logger.LogError($"Error loading project {action.Id}, reason: {e.Message}");
                dispatcher.Dispatch(new LoadProjectDetailFailureAction(e.Message));
            }
        }
    }
}