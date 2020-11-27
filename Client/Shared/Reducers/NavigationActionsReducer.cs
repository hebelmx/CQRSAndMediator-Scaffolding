using Client.Projects.State;
using Fluxor;
using Fluxor.Blazor.Web.Middlewares.Routing;

namespace Client.Shared.Reducers
{
    public static class NavigationActionsReducer
    {
        [ReducerMethod]
        public static ProjectsState ReduceNavigationAction(ProjectsState state, GoAction _) =>
            new ProjectsState(state.IsLoading, null, state.CurrentProjects, state.CurrentProject);
    }
}