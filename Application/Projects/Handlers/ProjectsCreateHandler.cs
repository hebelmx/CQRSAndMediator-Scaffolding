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

namespace Application.Projects.Handlers
{
    public class ProjectsCreateHandler : IRequestHandler<ProjectsCreateCommand, Response<ProjectDto>>
    {
        private IApplicationDbContext _context;
        private IMapper _mapper;
        public ProjectsCreateHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "context cannot be null");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "mapper cannot be null");
        }

        public Task<Response<ProjectDto>> Handle(ProjectsCreateCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}