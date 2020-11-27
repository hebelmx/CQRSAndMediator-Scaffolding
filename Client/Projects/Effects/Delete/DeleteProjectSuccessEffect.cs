using System.Threading.Tasks;
using Client.Projects.Actions.Delete;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Client.Projects.Effects.Delete
{
    public class DeleteProjectSuccessEffect : Effect<DeleteProjectSuccessAction>
    {
        private readonly ILogger<DeleteProjectSuccessEffect> _logger;
        private readonly NavigationManager _navigation;

        public DeleteProjectSuccessEffect(ILogger<DeleteProjectSuccessEffect> logger, NavigationManager navigation) =>
            (_logger, _navigation) = (logger, navigation);

        protected override Task HandleAsync(DeleteProjectSuccessAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation("Deleted project successfully, navigating back to project listing...");
            _navigation.NavigateTo("projects");

            return Task.CompletedTask;
        }
    }
}