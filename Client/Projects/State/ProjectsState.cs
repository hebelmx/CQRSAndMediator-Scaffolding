using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Projects.Dtos;
using Client.Shared;

namespace Client.Projects.State
{
    public class ProjectsState : RootState
    {
        public ProjectsState(bool isLoading, string? currentErrorMessage, IEnumerable<ProjectViewDto>? currentProjects, ProjectViewDto? currentProject)
            : base(isLoading, currentErrorMessage)
        {
            CurrentProjects = currentProjects;
            CurrentProject = currentProject;
        }

        public IEnumerable<ProjectViewDto>? CurrentProjects { get; }

        public ProjectViewDto? CurrentProject { get; }
    }
}