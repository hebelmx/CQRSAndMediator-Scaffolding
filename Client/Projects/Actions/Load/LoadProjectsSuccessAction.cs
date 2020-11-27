using System.Collections.Generic;
using Client.Projects.Dtos;

namespace Client.Projects.Actions.Load
{
    public class LoadProjectsSuccessAction
    {
        public LoadProjectsSuccessAction(IEnumerable<ProjectViewDto> projects) =>
            Projects = projects;

        public IEnumerable<ProjectViewDto> Projects { get; }
    }
}