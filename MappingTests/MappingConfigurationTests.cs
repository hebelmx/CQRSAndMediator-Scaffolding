using Xunit;

namespace MappingTests
{
    public class MappingConfigurationTests : MappingFixture
    {
        [Fact]
        public void Map_Should_HaveValidConfig()
        {
            Configuration.AssertConfigurationIsValid();
        }
    }
}