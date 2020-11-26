using Application.Domain;
using Application.ViewModels;
using Shouldly;
using Xunit;

namespace MappingTests
{
    public class MappingsPersonTests : MappingFixture
    {
        [Fact]
        public void Map_Should_MapPersonToPersonViewModel()
        {
            var entity = new Person();
            var vm = Mapper.Map<PersonDto>(entity);

            vm.ShouldNotBeNull();
            vm.ShouldBeOfType<PersonDto>();
        }

        [Fact]
        public void Map_Should_MapPersonViewModelToPerson()
        {
            var vm = new PersonDto();
            var entity = Mapper.Map<Person>(vm);

            entity.ShouldNotBeNull();
            entity.ShouldBeOfType<Person>();
        }
    }
}