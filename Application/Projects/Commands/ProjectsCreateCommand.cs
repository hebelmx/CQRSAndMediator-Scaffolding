using MediatR;
using Application;
using Application.DB;
using System;
using Application.Projects.Responses;
using Application.Projects.Commands;

namespace Application.Projects.Commands
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