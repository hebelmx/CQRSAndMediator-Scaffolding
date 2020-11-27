using Client.Shared.Actions;

namespace Client.Projects.Actions.Delete
{
    public class DeleteProjectFailureAction : FailureAction
    {
        public DeleteProjectFailureAction(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}