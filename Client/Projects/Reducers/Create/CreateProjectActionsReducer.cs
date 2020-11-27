using System.Collections.Generic;
using System.Linq;
using Client.Projects.Actions.Create;
using Client.Projects.Dtos;
using Client.Projects.State;
using Fluxor;

namespace Client.Projects.Reducers.Create
{
    public static class CreateProjectActionsReducer
    {
        [ReducerMethod]
        public static ProjectsState ReduceCreateProjectAction(ProjectsState state, CreateProjectAction _) =>
            new ProjectsState(true, null, state.CurrentProjects, state.CurrentProject);

        [ReducerMethod]
        public static ProjectsState ReduceCreateProjectSuccessAction(ProjectsState state, CreateProjectSuccessAction action)
        {
            // Grab a reference to the current project list, or initialize one if we do not
            // currently have any loaded
            var currentProjects = state.CurrentProjects is null ?
                new List<ProjectViewDto>() :
                state.CurrentProjects.ToList();

            // Add the newly created project to our list and sort by ID
            currentProjects.Add(action.ProjectView);
            currentProjects = currentProjects
                .OrderBy(t => t.ProjectId)
                .ToList();

            return new ProjectsState(false, null, currentProjects, state.CurrentProject);
        }

        [ReducerMethod]
        public static ProjectsState ReduceCreateProjectFailureAction(ProjectsState state, CreateProjectFailureAction action) =>
            new ProjectsState(false, action.ErrorMessage, state.CurrentProjects, state.CurrentProject);
    }
}