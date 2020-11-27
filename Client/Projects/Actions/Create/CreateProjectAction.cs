using Client.Projects.Actions.Update;
using Client.Projects.Dtos;

namespace Client.Projects.Actions.Create
{
    public class CreateProjectAction
    {
        public CreateProjectAction(ProjectCreateDto project) =>
            Project = project;

        public ProjectCreateDto Project { get; }
    }
}