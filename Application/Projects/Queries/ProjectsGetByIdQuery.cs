using MediatR;
using Application;
using Application.Projects.Dtos;
using System;
using Application.Projects.Responses;
using Application.Projects.Queries;

namespace Application.Projects.Queries
{
    public class ProjectsGetByIdQuery : IRequest<Response<ProjectDto>>
    {
        public ProjectGetByIdDto Dto
        {
            get;
        }

        public ProjectsGetByIdQuery(ProjectGetByIdDto dto)
        {
            Dto = dto ?? throw new ArgumentNullException($"dto cant be null {nameof(dto)}");
        }
    }
}