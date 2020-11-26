using System;
using Application.Domain;
using Application.ViewModels;
using AutoMapper;

using Shouldly;
using Xunit;

namespace MappingTests
{
    public class MappingProjectTests : MappingFixture
    {
        [Fact]
        public void Map_Should_Map_ProjectCreateDto_To_Project()
        {
            var vm = new ProjectCreateDto();
            var entity = Mapper.Map<Project>(vm);

            entity.ShouldNotBeNull();
            entity.ShouldBeOfType<Project>();
        }

        [Fact]
        public void Map_Should_Map_Project_To_ProjectCreateDto()
        {
            var entity = new Project();
            var vm = Mapper.Map<ProjectDto>(entity);

            vm.ShouldNotBeNull();
            vm.ShouldBeOfType<ProjectDto>();
        }
    }
}