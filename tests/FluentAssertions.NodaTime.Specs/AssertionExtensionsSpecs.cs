using NodaTime;

using Xunit;

namespace FluentAssertions.NodaTime.Specs
{
    public class AssertionExtensionsSpecs
    {
        [Fact]
        public void When_asserting_an_instant_it_should_return_the_correct_assertion_type()
        {
            // Arrange / Act / Assert
            default(Instant).Should().GetType().Should().Be<InstantAssertions>();
        }
    }
}
