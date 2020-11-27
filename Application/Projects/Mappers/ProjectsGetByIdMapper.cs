using AutoMapper;
using Application;
using Application.Domain;
using Application.Mappings;
using Application.ViewModels;
using Application.Projects.Dtos;
using System;
using Application.Projects.Responses;
using Application.Projects.Commands;

namespace Application.Projects.Mappers
{
    public class ProjectGetByIdMapper : IMapFrom<ProjectGetByIdDto>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProjectGetByIdDto, Project>();
            profile.CreateMap<Project, ProjectDto>();
        }
    }
}