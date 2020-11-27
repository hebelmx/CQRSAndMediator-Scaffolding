using Client.Projects.Actions.Create;
using Client.Projects.Actions.Delete;
using Client.Projects.Actions.Load;
using Client.Projects.Actions.LoadDetail;
using Client.Projects.Actions.Update;
using Client.Projects.Dtos;
using Fluxor;
using Microsoft.Extensions.Logging;

namespace Client.Projects.Services
{
    public class ProjectsService

    {
        private readonly ILogger<ProjectsService> _logger;
        private readonly IDispatcher _dispatcher;

        public ProjectsService(ILogger<ProjectsService> logger, IDispatcher dispatcher) =>
            (_logger, _dispatcher) = (logger, dispatcher);

        public void LoadProjects()
        {
            _logger.LogInformation("Issuing action to load Projects...");
            _dispatcher.Dispatch(new LoadProjectsAction());
        }

        public void LoadProjectById(int id)
        {
            _logger.LogInformation($"Issuing action to load Project {id}...");
            _dispatcher.Dispatch(new LoadProjectDetailAction(id));
        }

        public void CreateProject(string title, bool completed, int userId)
        {
            // Construct our validated Project
            var projectCreateDto = new ProjectCreateDto(title, completed, userId);

            _logger.LogInformation($"Issuing action to create Project [{title}] for user [{userId}]");
            _dispatcher.Dispatch(new CreateProjectAction(projectCreateDto));
        }

        public void UpdateProject(int id, string title, bool completed, int userId)
        {
            // Construct our validated Project
            var projectUpdateDto = new ProjectUpdateDto(title, completed, userId);

            _logger.LogInformation($"Issuing action to update Project {id}");
            _dispatcher.Dispatch(new UpdateProjectAction(id, projectUpdateDto));
        }

        public void DeleteProject(int id)
        {
            // Construct our validated Project
            var projectDeleteDto = new ProjectDeleteDto(id);

            _logger.LogInformation($"Issuing action to delete Project {id}");
            _dispatcher.Dispatch(new DeleteProjectAction(projectDeleteDto));
        }
    }
}