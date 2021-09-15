using System;

using NodaTime;

using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.NodaTime.Specs
{
    public class InstantAssertionsSpecs
    {
        public class Be
        {
            [Fact]
            public void When_an_instant_is_equal_to_an_other_instant_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant instant = Instant.FromDateTimeOffset(now);
                Instant other = Instant.FromDateTimeOffset(now);

                // Act
                Action act = () => instant.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_an_instant_is_equal_to_itself_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant instant = Instant.FromDateTimeOffset(now);

                // Act
                Action act = () => instant.Should().Be(instant);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_instant_is_before_an_other_instant_it_fails()
            {
                // Arrange
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other - Duration.FromNanoseconds(1);

                // Act
                Action act = () => instant.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(instant)} to be equal to {other}.");
            }

            [Fact]
            public void When_an_instant_is_after_an_other_instant_it_fails()
            {
                // Arrange
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other + Duration.FromNanoseconds(1);

                // Act
                Action act = () => instant.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(instant)} to be equal to {other}.");
            }
            
            [Fact]
            public void When_an_instant_is_equal_to_a_datetimeoffset_it_succeeds()
            {
                // Arrange
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                DateTimeOffset other = instant.ToDateTimeOffset();

                // Act
                Action act = () => instant.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_instant_is_before_a_datetimeoffset_it_fails()
            {
                // Arrange
                DateTimeOffset other = DateTimeOffset.Now;
                Instant instant = Instant.FromDateTimeOffset(other) - Duration.FromNanoseconds(1);

                // Act
                Action act = () => instant.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(instant)} to be equal to {Instant.FromDateTimeOffset(other)}.");
            }

            [Fact]
            public void When_an_instant_is_after_a_datetimeoffset_it_fails()
            {
                // Arrange
                DateTimeOffset other = DateTimeOffset.Now;
                Instant instant = Instant.FromDateTimeOffset(other) + Duration.FromNanoseconds(1);

                // Act
                Action act = () => instant.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(instant)} to be equal to {Instant.FromDateTimeOffset(other)}.");
            }
        }

        public class NotBe
        {
            [Fact]
            public void When_an_instant_is_before_an_other_instant_it_succeeds()
            {
                // Arrange
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other - Duration.FromNanoseconds(1);

                // Act
                Action act = () => instant.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_instant_is_after_an_other_instant_it_succeeds()
            {
                // Arrange
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other + Duration.FromNanoseconds(1);

                // Act
                Action act = () => instant.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_instant_is_equal_to_an_other_instant_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant other = Instant.FromDateTimeOffset(now);
                Instant instant = Instant.FromDateTimeOffset(now);

                // Act
                Action act = () => instant.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(instant)} not to be equal to {other}.");
            }

            [Fact]
            public void When_asserting_an_instant_is_not_equal_to_itself_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant instant = Instant.FromDateTimeOffset(now);

                // Act
                Action act = () => instant.Should().NotBe(instant);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(instant)} not to be equal to {instant}.");
            }
    
            [Fact]
            public void When_an_instant_is_equal_to_a_datetimeoffset_it_fails()
            {
                // Arrange
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                DateTimeOffset other = instant.ToDateTimeOffset();

                // Act
                Action act = () => instant.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(instant)} not to be equal to {Instant.FromDateTimeOffset(other)}.");
            }

            [Fact]
            public void When_an_instant_is_before_a_datetimeoffset_it_succeeds()
            {
                // Arrange
                DateTimeOffset other = DateTimeOffset.Now;
                Instant instant = Instant.FromDateTimeOffset(other) - Duration.FromNanoseconds(1);

                // Act
                Action act = () => instant.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_instant_is_after_a_datetimeoffset_it_succeeds()
            {
                // Arrange
                DateTimeOffset other = DateTimeOffset.Now;
                Instant instant = Instant.FromDateTimeOffset(other) + Duration.FromNanoseconds(1);

                // Act
                Action act = () => instant.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }
        }

        public class BeAfter
        {
            [Fact]
            public void When_an_instant_is_after_an_other_instant_it_succeeds()
            {
                // Arrange
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other + Duration.FromNanoseconds(1);

                // Act
                Action act = () => instant.Should().BeAfter(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_instant_is_before_an_other_instant_it_fails()
            {
                // Arrange
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other - Duration.FromNanoseconds(1);

                // Act
                Action act = () => instant.Should().BeAfter(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(instant)} to be after {other}.");
            }

            [Fact]
            public void When_an_instant_is_equal_to_an_other_instant_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant other = Instant.FromDateTimeOffset(now);
                Instant instant = Instant.FromDateTimeOffset(now);

                // Act
                Action act = () => instant.Should().BeAfter(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(instant)} to be after {other}.");
            }

            [Fact]
            public void When_asserting_an_instant_is_after_itself_it_fails()
            {
                // Arrange
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => instant.Should().BeAfter(instant);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(instant)} to be after {instant}.");
            }
        }

        public class BeOnOrAfter
        {
            [Fact]
            public void When_asserting_an_instant_is_on_or_after_itself_it_succeeds()
            {
                // Arrange
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => instant.Should().BeOnOrAfter(instant);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_instant_is_equal_to_an_other_instant_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant other = Instant.FromDateTimeOffset(now);
                Instant instant = Instant.FromDateTimeOffset(now);

                // Act
                Action act = () => instant.Should().BeOnOrAfter(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_instant_is_after_an_other_instant_it_succeeds()
            {
                // Arrange
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other + Duration.FromNanoseconds(1);

                // Act
                Action act = () => instant.Should().BeOnOrAfter(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_instant_is_before_an_other_instant_it_fails()
            {
                // Arrange
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other - Duration.FromNanoseconds(1);

                // Act
                Action act = () => instant.Should().BeOnOrAfter(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(instant)} to be on or after {other}.");
            }
        }

        public class BeBefore
        {
            [Fact]
            public void When_an_instant_is_before_an_other_instant_it_succeeds()
            {
                // Arrange
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other - Duration.FromNanoseconds(1);

                // Act
                Action act = () => instant.Should().BeBefore(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_instant_is_after_an_other_instant_it_fails()
            {
                // Arrange
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other + Duration.FromNanoseconds(1);

                // Act
                Action act = () => instant.Should().BeBefore(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(instant)} to be before {other}.");
            }

            [Fact]
            public void When_an_instant_is_equal_to_an_other_instant_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant other = Instant.FromDateTimeOffset(now);
                Instant instant = Instant.FromDateTimeOffset(now);

                // Act
                Action act = () => instant.Should().BeBefore(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(instant)} to be before {other}.");
            }

            [Fact]
            public void When_asserting_an_instant_is_before_itself_it_fails()
            {
                // Arrange
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => instant.Should().BeBefore(instant);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(instant)} to be before {instant}.");
            }
        }

        public class BeOnOrBefore
        {
            [Fact]
            public void When_asserting_an_instant_is_on_or_before_itself_it_succeeds()
            {
                // Arrange
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => instant.Should().BeOnOrBefore(instant);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_instant_is_equal_to_an_other_instant_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                Instant other = Instant.FromDateTimeOffset(now);
                Instant instant = Instant.FromDateTimeOffset(now);

                // Act
                Action act = () => instant.Should().BeOnOrBefore(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_instant_is_before_an_other_instant_it_succeeds()
            {
                // Arrange
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other - Duration.FromNanoseconds(1);

                // Act
                Action act = () => instant.Should().BeOnOrBefore(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_instant_is_after_an_other_instant_it_fails()
            {
                // Arrange
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other + Duration.FromNanoseconds(1);

                // Act
                Action act = () => instant.Should().BeOnOrBefore(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(instant)} to be on or before {other}.");
            }
        }

        public class BeCloseTo
        {
            [Fact]
            public void When_the_precision_is_negative_it_fails()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(-1);
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action duration = () => instant.Should().BeCloseTo(instant, precision);
                Action timesamp = () => instant.Should().BeCloseTo(instant, precision.ToTimeSpan());

                // Assert
                duration.Should().Throw<ArgumentOutOfRangeException>()
                    .WithMessage("*The value of precision must be non-negative.*");

                timesamp.Should().Throw<ArgumentOutOfRangeException>()
                    .WithMessage("*The value of precision must be non-negative.*");
            }

            [Fact]
            public void When_asserting_an_instant_is_close_to_itself_it_succeeds()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action duration = () => instant.Should().BeCloseTo(instant, precision);
                Action timesamp = () => instant.Should().BeCloseTo(instant, precision.ToTimeSpan());

                // Assert
                duration.Should().NotThrow();
                timesamp.Should().NotThrow();
            }

            [Fact]
            public void When_two_instants_are_equal_it_succeeds()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                DateTimeOffset now = DateTimeOffset.Now;
                Instant instant = Instant.FromDateTimeOffset(now);
                Instant other = Instant.FromDateTimeOffset(now);

                // Act
                Action duration = () => instant.Should().BeCloseTo(other, precision);
                Action timestamp = () => instant.Should().BeCloseTo(other, precision.ToTimeSpan());

                // Assert
                duration.Should().NotThrow();
                timestamp.Should().NotThrow();
            }

            [Fact]
            public void When_an_instant_is_close_to_but_before_an_other_instant_it_succeeds()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other - precision;

                // Act
                Action duration = () => instant.Should().BeCloseTo(other, precision);
                Action timestamp = () => instant.Should().BeCloseTo(other, precision.ToTimeSpan());

                // Assert
                duration.Should().NotThrow();
                timestamp.Should().NotThrow();
            }

            [Fact]
            public void When_an_instant_is_close_to_but_after_an_other_instant_it_succeeds()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other + precision;

                // Act
                Action duration = () => instant.Should().BeCloseTo(other, precision);
                Action timestamp = () => instant.Should().BeCloseTo(other, precision.ToTimeSpan());

                // Assert
                duration.Should().NotThrow();
                timestamp.Should().NotThrow();
            }

            [Fact]
            public void When_an_instant_is_not_close_to_and_before_an_other_instant_it_fails()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other - precision - Duration.FromSeconds(1);

                // Act
                Action duration = () => instant.Should().BeCloseTo(other, precision);
                Action timestamp = () => instant.Should().BeCloseTo(other, precision.ToTimeSpan());

                // Assert
                duration.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(instant)} to be within {precision} from {other}, but it was {other - instant}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(instant)} to be within {precision} from {other}, but it was {other - instant}.");
            }

            [Fact]
            public void When_an_instant_is_not_close_to_and_after_an_other_instant_it_fails()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other + precision + Duration.FromSeconds(1);

                // Act
                Action duration = () => instant.Should().BeCloseTo(other, precision);
                Action timestamp = () => instant.Should().BeCloseTo(other, precision.ToTimeSpan());

                // Assert
                duration.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(instant)} to be within {precision} from {other}, but it was {instant - other}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(instant)} to be within {precision} from {other}, but it was {instant - other}.");
            }
        }

        public class NotBeCloseTo
        {
            [Fact]
            public void When_an_instant_is_not_close_to_and_before_an_other_instant_it_succeeds()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other - precision - Duration.FromSeconds(1);

                // Act
                Action duration = () => instant.Should().NotBeCloseTo(other, precision);
                Action timestamp = () => instant.Should().NotBeCloseTo(other, precision.ToTimeSpan());

                // Assert
                duration.Should().NotThrow();
                timestamp.Should().NotThrow();
            }

            [Fact]
            public void When_an_instant_is_not_close_to_and_after_an_other_instant_it_succeeds()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other + precision + Duration.FromSeconds(1);

                // Act
                Action duration = () => instant.Should().NotBeCloseTo(other, precision);
                Action timestamp = () => instant.Should().NotBeCloseTo(other, precision.ToTimeSpan());

                // Assert
                duration.Should().NotThrow();
                timestamp.Should().NotThrow();
            }

            [Fact]
            public void When_the_precision_is_negative_it_fails()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(-1);
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action duration = () => instant.Should().NotBeCloseTo(instant, precision);
                Action timesamp = () => instant.Should().NotBeCloseTo(instant, precision.ToTimeSpan());

                // Assert
                duration.Should().Throw<ArgumentOutOfRangeException>()
                    .WithMessage("*The value of precision must be non-negative.*");

                timesamp.Should().Throw<ArgumentOutOfRangeException>()
                    .WithMessage("*The value of precision must be non-negative.*");
            }

            [Fact]
            public void When_asserting_an_instant_is_not_close_to_itself_it_fails()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Instant instant = Instant.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action duration = () => instant.Should().NotBeCloseTo(instant, precision);
                Action timestamp = () => instant.Should().NotBeCloseTo(instant, precision.ToTimeSpan());

                // Assert
                duration.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(instant)} to be within {precision} from {instant}, but it was {Duration.Zero}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(instant)} to be within {precision} from {instant}, but it was {Duration.Zero}.");
            }

            [Fact]
            public void When_two_instants_are_equal_it_fails()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                DateTimeOffset now = DateTimeOffset.Now;
                Instant instant = Instant.FromDateTimeOffset(now);
                Instant other = Instant.FromDateTimeOffset(now);

                // Act
                Action duration = () => instant.Should().NotBeCloseTo(other, precision);
                Action timestamp = () => instant.Should().NotBeCloseTo(other, precision.ToTimeSpan());

                // Assert
                duration.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(instant)} to be within {precision} from {other}, but it was {Duration.Zero}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(instant)} to be within {precision} from {other}, but it was {Duration.Zero}.");
            }

            [Fact]
            public void When_an_instant_is_close_to_but_before_an_other_instant_it_fails()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other - precision;

                // Act
                Action duration = () => instant.Should().NotBeCloseTo(other, precision);
                Action timestamp = () => instant.Should().NotBeCloseTo(other, precision.ToTimeSpan());

                // Assert
                duration.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(instant)} to be within {precision} from {other}, but it was {other - instant}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(instant)} to be within {precision} from {other}, but it was {other - instant}.");
            }

            [Fact]
            public void When_an_instant_is_close_to_but_after_an_other_instant_it_fails()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Instant other = Instant.FromDateTimeOffset(DateTimeOffset.Now);
                Instant instant = other + precision;

                // Act
                Action duration = () => instant.Should().NotBeCloseTo(other, precision);
                Action timestamp = () => instant.Should().NotBeCloseTo(other, precision.ToTimeSpan());

                // Assert
                duration.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(instant)} to be within {precision} from {other}, but it was {instant - other}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(instant)} to be within {precision} from {other}, but it was {instant - other}.");
            }
        }
    }
}
