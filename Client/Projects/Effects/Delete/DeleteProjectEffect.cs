using System;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Api;
using Client.Projects.Actions.Delete;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace Client.Projects.Effects.Delete
{
    public class DeleteProjectEffect : Effect<DeleteProjectAction>
    {
        private readonly ILogger<DeleteProjectEffect> _logger;
        private readonly ProjectApiService _apiService;

        public DeleteProjectEffect(ILogger<DeleteProjectEffect> logger, ProjectApiService apiService) =>
            (_logger, _apiService) = (logger, apiService);

        protected override async Task HandleAsync(DeleteProjectAction action, IDispatcher dispatcher)
        {
            try
            {
                _logger.LogInformation($"Deleting project {action.ProjectDeleteDto.Id}...");
                var deleteResponse = await _apiService.DeleteAsync($"projects/{action.ProjectDeleteDto}");

                if (!deleteResponse.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error deleting project: {deleteResponse.ReasonPhrase}");
                }

                _logger.LogInformation($"Project deleted successfully!");
                dispatcher.Dispatch(new DeleteProjectSuccessAction(action.ProjectDeleteDto.Id));
            }
            catch (Exception e)
            {
                _logger.LogError($"Could not create project, reason: {e.Message}");
                dispatcher.Dispatch(new DeleteProjectFailureAction(e.Message));
            }
        }
    }
}