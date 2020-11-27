using Client.Projects.Dtos;

namespace Client.Projects.Actions.LoadDetail
{
    public class LoadProjectDetailSuccessAction
    {
        public LoadProjectDetailSuccessAction(ProjectViewDto projectView) =>
            ProjectView = projectView;

        public ProjectViewDto ProjectView { get; }
    }
}