using Client.Shared.Actions;

namespace Client.Projects.Actions.Load
{
    public class LoadProjectsFailureAction : FailureAction
    {
        public LoadProjectsFailureAction(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}