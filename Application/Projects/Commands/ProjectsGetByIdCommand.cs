using MediatR;
using Application;
using Application.ViewModels;
using System;
using Application.Projects.Responses;
using Application.Projects.Commands;
using Application.Projects.Dtos;

namespace Application.Projects.Commands
{
    public class ProjectsGetByIdCommand : IRequest<Response<ProjectDto>>
    {
        public ProjectGetByIdDto Dto
        {
            get;
        }

        public ProjectsGetByIdCommand(ProjectGetByIdDto dto)
        {
            Dto = dto ?? throw new ArgumentNullException($"dto cant be null {nameof(dto)}");
        }
    }
}