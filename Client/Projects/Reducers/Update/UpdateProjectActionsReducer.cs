using System.Collections.Generic;
using System.Linq;
using Client.Projects.Actions.Update;
using Client.Projects.Dtos;
using Client.Projects.State;
using Fluxor;

namespace Client.Projects.Reducers.Update
{
    public static class UpdateProjectActionsReducer
    {
        [ReducerMethod]
        public static ProjectsState ReduceUpdateProjectAction(ProjectsState state, UpdateProjectAction _) =>
            new ProjectsState(true, null, state.CurrentProjects, state.CurrentProject);

        [ReducerMethod]
        public static ProjectsState ReduceUpdateProjectSuccessAction(ProjectsState state, UpdateProjectSuccessAction action)
        {
            // If the current projects list is null, set the state with a new list containing the
            // updated project
            if (state.CurrentProjects is null)
            {
                return new ProjectsState(false, null, new List<ProjectViewDto> { action.ProjectView }, state.CurrentProject);
            }

            // Rather than mutating in place, let's construct a new list and add our updated item
            var updatedList = state.CurrentProjects
                .Where(t => t.ProjectId != action.ProjectView.ProjectId)
                .ToList();

            // Add the project and sort the list
            updatedList.Add(action.ProjectView);
            updatedList = updatedList
                .OrderBy(t => t.ProjectId)
                .ToList();

            return new ProjectsState(false, null, updatedList, null);
        }

        [ReducerMethod]
        public static ProjectsState ReduceUpdateProjectFailureAction(ProjectsState state, UpdateProjectFailureAction action) =>
            new ProjectsState(false, action.ErrorMessage, state.CurrentProjects, state.CurrentProject);
    }
}