using MediatR;
using Application;
using Application.ViewModels;
using System;
using Application.Projects.Responses;
using Application.Projects.Commands;
using Application.Projects.Dtos;

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