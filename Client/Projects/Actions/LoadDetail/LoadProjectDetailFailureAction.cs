using Client.Shared.Actions;

namespace Client.Projects.Actions.LoadDetail
{
    public class LoadProjectDetailFailureAction : FailureAction
    {
        public LoadProjectDetailFailureAction(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}