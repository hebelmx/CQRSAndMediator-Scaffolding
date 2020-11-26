using Application.Domain;
using Application.Mappings;
using Application.Persistency;
using Application.ViewModels;
using AutoMapper;

namespace Application.Logic.Projects.Mappers
{
    public class ProjectMappingProfile : IMapFrom<Project>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectCreateDto>();

            profile.CreateMap<ProjectCreateDto, Project>();
        }
    }
}