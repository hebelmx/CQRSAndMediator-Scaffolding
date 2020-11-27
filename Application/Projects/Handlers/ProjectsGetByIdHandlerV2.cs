using MediatR;
using AutoMapper;
using Application.Domain;
using Application.ViewModels;
using Application.Persistence;
using System;
using Application.Projects.Queries;
using Application.Projects.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Projects.Dtos;

namespace Application.Projects.Handlers
{
    public class ProjectsGetByIdHandlerV2 : IRequestHandler<ProjectsGetByIdQuery, Response<ProjectDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProjectsGetByIdHandlerV2(IApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "context cannot be null");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "mapper cannot be null");
        }

        public async Task<Response<ProjectDto>> Handle(ProjectsGetByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Projects.FindAsync(request.Dto.id, cancellationToken);
            var response = entity is null
                ? new Response<ProjectDto>(_mapper.Map<Project, ProjectDto>(entity))
                : new Response<ProjectDto>($"entity {nameof(entity)} not found");
            return response;
        }
    }
}