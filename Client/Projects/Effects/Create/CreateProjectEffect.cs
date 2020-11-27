using System;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Api;
using Client.Projects.Actions.Create;
using Client.Projects.Dtos;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace Client.Projects.Effects.Create
{
    public class CreateProjectEffect : Effect<CreateProjectAction>
    {
        private readonly ILogger<CreateProjectEffect> _logger;
        private readonly ProjectApiService _projectApiService;

        public CreateProjectEffect(ILogger<CreateProjectEffect> logger, ProjectApiService apiService) =>
            (_logger, _projectApiService) = (logger, apiService);

        protected override async Task HandleAsync(CreateProjectAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation($"Creating project {action.Project}...");
                var createResponse = await _projectApiService.PostAsync($"projects/", action.Project);

                if (!createResponse.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error deleting project: {createResponse.ReasonPhrase}");
                }

                _logger.LogInformation($"Project Created successfully!");
                dispatcher.Dispatch(new CreateProjectSuccessAction(new ProjectViewDto()));
            }
            catch (Exception e)
            {
                _logger.LogError($"Could not create project, reason: {e.Message}");
                dispatcher.Dispatch(new CreateProjectFailureAction(e.Message));
            }
        }
    }
}