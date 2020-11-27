using System.Threading.Tasks;
using Client.Projects.Actions.Create;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Client.Projects.Effects.Create
{
    public class CreateProjectSuccessEffect : Effect<CreateProjectSuccessAction>
    {
        private readonly ILogger<CreateProjectSuccessEffect> _logger;
        private readonly NavigationManager _navigation;

        public CreateProjectSuccessEffect(ILogger<CreateProjectSuccessEffect> logger, NavigationManager navigation) =>
            (_logger, _navigation) = (logger, navigation);

        protected override Task HandleAsync(CreateProjectSuccessAction action, IDispatcher dispatcher)
        {
            _logger.LogInformation("Created project successfully, navigating back to project listing...");
            _navigation.NavigateTo("projects");

            return Task.CompletedTask;
        }
    }
}