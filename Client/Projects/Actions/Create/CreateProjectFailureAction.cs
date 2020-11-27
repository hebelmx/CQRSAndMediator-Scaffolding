using Client.Shared.Actions;

namespace Client.Projects.Actions.Create
{
    public class CreateProjectFailureAction : FailureAction
    {
        public CreateProjectFailureAction(string errorMessage)
            : base(errorMessage)
        {
        }
    }
}