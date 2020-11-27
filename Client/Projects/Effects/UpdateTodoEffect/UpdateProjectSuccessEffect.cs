using System.Threading.Tasks;
using Client.Projects.Actions.Update;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Client.Projects.Effects.UpdateTodoEffect
{
    public class UpdateProjectSuccessEffect : Effect<UpdateProjectSuccessAction>
    {
        private readonly ILogger<UpdateProjectSuccessEffect> _logger;
        private readonly NavigationManager _navigation;

        public UpdateProjectSuccessEffect(ILogger<UpdateProjectSuccessEffect> logger, NavigationManager navigation) =>
            (_logger, _navigation) = (logger, navigation);

        protected override Task HandleAsync(UpdateProjectSuccessAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation("Updated project successfully, navigating back to project listing...");
            _navigation.NavigateTo("projects");

            return Task.CompletedTask;
        }
    }
}