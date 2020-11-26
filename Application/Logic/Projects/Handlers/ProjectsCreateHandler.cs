using System.Threading;
using System.Threading.Tasks;
using Application.Domain;
using Application.Logic.Projects.Commands;
using Application.Persistency;
using Application.ViewModels;
using AutoMapper;
using MediatR;

namespace Application.Logic.Projects.Handlers
{
    public class ProjectsCreateHandler : IRequestHandler<ProjectsCreateCommand, Response<ProjectDto>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public ProjectsCreateHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;

            _context = context;
        }

        public async Task<Response<ProjectDto>> Handle(ProjectsCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProjectCreateDto, Project>(request.Dto);

            var entityEntry = await _context.Projects.AddAsync(entity, cancellationToken);

            var result = await _context.SaveChangesAsync(cancellationToken);

            var map = _mapper.Map<Project, ProjectDto>(entity);
            return new Response<ProjectDto>(map);
        }
    }
}