using AutoMapper;
using Application;
using Application.DB;
using System;
using Application.Projects.Responses;
using Application.Projects.Commands;

namespace Application.Projects.Mappers
{
    public class ProjectCreateProfile : Profile
    {
        public ProjectCreateProfile()
        {
            CreateMap<Project, ProjectCreateDto>();
        }
    }
}