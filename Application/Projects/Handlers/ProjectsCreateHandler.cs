using MediatR;
using AutoMapper;
using Logic.Invoices.Commands;
using Logic.Invoices.Responses;
using Application;
using Application.DB;
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
        private IMapper _mapper;
        private IApplicationDBContext _context;
        public Task<Response<ProjectDto>> Handle(ProjectsCreateCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}