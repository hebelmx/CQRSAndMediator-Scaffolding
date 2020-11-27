using System;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Api;
using Client.Projects.Actions.Update;
using Client.Projects.Dtos;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace Client.Projects.Effects.UpdateTodoEffect
{
    public class UpdateProjectEffect : Effect<UpdateProjectAction>
    {
        private readonly ILogger<UpdateProjectEffect> _logger;
        private readonly ProjectApiService _apiService;

        public UpdateProjectEffect(ILogger<UpdateProjectEffect> logger, ProjectApiService apiService) =>
            (_logger, _apiService) = (logger, apiService);

        protected override async Task HandleAsync(UpdateProjectAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation($"Deleting project {action.Id}...");
                var UpdateResponse = await _apiService.PutAsync($"projects/{action.Id}", action.Project);

                if (!UpdateResponse.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error deleting project: {UpdateResponse.ReasonPhrase}");
                }

                _logger.LogInformation($"Project Updated successfully!");
                dispatcher.Dispatch(new UpdateProjectSuccessAction(new ProjectViewDto()));
            }
            catch (Exception e)
            {
                _logger.LogError($"Could not create project, reason: {e.Message}");
                dispatcher.Dispatch(new UpdateProjectFailureAction(e.Message));
            }
        }
    }
}