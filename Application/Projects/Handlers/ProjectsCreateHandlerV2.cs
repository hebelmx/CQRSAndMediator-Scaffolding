using MediatR;
using AutoMapper;
using Application;
using Application.ViewModels;
using Application.Persistence;
using System;
using Application.Projects.Commands;
using Application.Projects.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Domain;

namespace Application.Projects.Handlers
{
    public class ProjectsCreateHandlerV2 : IRequestHandler<ProjectsCreateCommand, Response<ProjectDto>>
    {
        private IApplicationDbContext _context;
        private IMapper _mapper;

        public ProjectsCreateHandlerV2(IApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "context cannot be null");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "mapper cannot be null");
        }

        public async Task<Response<ProjectDto>> Handle(ProjectsCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProjectCreateDto, Project>(request.Dto);

            await _context.Projects.AddIfNotExistsAsync(entity, x => x.Name == entity.Name, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            var entitySaved = _mapper.Map<Project, ProjectDto>(entity);

            var response = new Response<ProjectDto>(entitySaved);

            return response;
        }
    }
}