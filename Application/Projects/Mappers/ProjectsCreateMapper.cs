using AutoMapper;
using Application;
using Application.Domain;
using Application.Mappings;
using Application.ViewModels;
using System;
using Application.Projects.Responses;
using Application.Projects.Commands;
using Application.Projects.Dtos;

namespace Application.Projects.Mappers
{
    public class ProjectCreateMapper : IMapFrom<ProjectCreateDto>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProjectCreateDto, Project>();
            profile.CreateMap<Project, ProjectDto>();
        }
    }
}