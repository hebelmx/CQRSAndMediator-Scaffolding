using Client.Shared.Actions;

namespace Client.Projects.Actions.Update
{
    public class UpdateProjectFailureAction : FailureAction
    {
        public UpdateProjectFailureAction(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}