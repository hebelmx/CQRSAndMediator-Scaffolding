using Client.Projects.Actions.LoadDetail;
using Client.Projects.State;
using Fluxor;

namespace Client.Projects.Reducers.LoadDetail
{
    public static class LoadProjectDetailActionsReducer
    {
        [ReducerMethod]
        public static ProjectsState ReduceLoadProjectDetailAction(ProjectsState state, LoadProjectDetailAction _) =>
            new ProjectsState(true, null, state.CurrentProjects, null);

        [ReducerMethod]
        public static ProjectsState ReduceLoadProjectDetailSuccessAction(ProjectsState state, LoadProjectDetailSuccessAction action) =>
            new ProjectsState(false, null, state.CurrentProjects, action.ProjectView);

        [ReducerMethod]
        public static ProjectsState ReduceLoadProjectDetailFailureAction(ProjectsState state, LoadProjectDetailFailureAction action) =>
            new ProjectsState(false, action.ErrorMessage, state.CurrentProjects, null);
    }
}