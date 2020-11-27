using System.Linq;
using Client.Projects.Actions.Delete;
using Client.Projects.State;
using Fluxor;

namespace Client.Projects.Reducers.Delete
{
    public static class DeleteProjectActionsReducer
    {
        [ReducerMethod]
        public static ProjectsState ReduceDeleteProjectAction(ProjectsState state, DeleteProjectAction _) =>
            new ProjectsState(true, null, state.CurrentProjects, state.CurrentProject);

        [ReducerMethod]
        public static ProjectsState ReduceDeleteProjectSuccessAction(ProjectsState state, DeleteProjectSuccessAction action)
        {
            // Return the default state if no list of projects is found
            if (state.CurrentProjects is null)
            {
                return new ProjectsState(false, null, null, state.CurrentProject);
            }

            // Create a new list with all project items excluding the project with the deleted ID
            var updatedProjects = state.CurrentProjects.Where(t => t.ProjectId != action.Id);

            return new ProjectsState(false, null, updatedProjects, state.CurrentProject);
        }

        [ReducerMethod]
        public static ProjectsState ReduceDeleteProjectFailureAction(ProjectsState state, DeleteProjectFailureAction action) =>
            new ProjectsState(false, action.ErrorMessage, state.CurrentProjects, state.CurrentProject);
    }
}