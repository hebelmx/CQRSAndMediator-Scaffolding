using System;
using Application.ViewModels;
using MediatR;

namespace Application.Logic.Projects.Commands
{
    public class ProjectsCreateCommand : IRequest<Response<ProjectDto>>
    {
        public ProjectCreateDto Dto
        {
            get;
        }

        public ProjectsCreateCommand(ProjectCreateDto dto)
        {
            Dto = dto ?? throw new ArgumentNullException($"dto cant be null {nameof(dto)}");
        }
    }
}