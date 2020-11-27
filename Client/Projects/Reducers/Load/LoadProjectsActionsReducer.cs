using Client.Projects.Actions.Load;
using Client.Projects.State;
using Fluxor;

namespace Client.Projects.Reducers.Load
{
    public static class LoadProjectsActionsReducer
    {
        [ReducerMethod]
        public static ProjectsState ReduceLoadProjectsAction(ProjectsState state, LoadProjectsAction _) =>
            new ProjectsState(true, null, null, state.CurrentProject);

        [ReducerMethod]
        public static ProjectsState ReduceLoadProjectsSuccessAction(ProjectsState state, LoadProjectsSuccessAction action) =>
            new ProjectsState(false, null, action.Projects, state.CurrentProject);

        [ReducerMethod]
        public static ProjectsState ReduceLoadProjectsFailureAction(ProjectsState state, LoadProjectsFailureAction action) =>
            new ProjectsState(false, action.ErrorMessage, null, state.CurrentProject);
    }
}