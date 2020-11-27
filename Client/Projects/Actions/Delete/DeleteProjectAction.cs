using Client.Projects.Dtos;

namespace Client.Projects.Actions.Delete
{
    public class DeleteProjectAction
    {
        public DeleteProjectAction(ProjectDeleteDto projectDeleteDto) =>
            ProjectDeleteDto = projectDeleteDto;

        public ProjectDeleteDto ProjectDeleteDto { get; init; }
    }
}