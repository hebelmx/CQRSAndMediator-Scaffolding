using Client.Projects.Dtos;

namespace Client.Projects.Actions.Create
{
    public class CreateProjectSuccessAction
    {
        public CreateProjectSuccessAction(ProjectViewDto projectView) =>
            ProjectView = projectView;

        public ProjectViewDto ProjectView { get; }
    }
}