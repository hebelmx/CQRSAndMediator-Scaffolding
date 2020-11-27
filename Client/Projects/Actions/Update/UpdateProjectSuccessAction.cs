using Client.Projects.Dtos;

namespace Client.Projects.Actions.Update
{
    public class UpdateProjectSuccessAction
    {
        public UpdateProjectSuccessAction(ProjectViewDto projectView) =>
            ProjectView = projectView;

        public ProjectViewDto ProjectView { get; }
    }
}