using System;
using System.Diagnostics.CodeAnalysis;

using NodaTime;

using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.NodaTime.Specs
{
    public static class DurationAssertionsSpecs
    {
        public class Be
        {
            [Fact]
            public void When_an_duration_is_equal_to_an_other_duration_it_succeeds()
            {
                // Arrange
                long ticks = new Random().Next();
                Duration duration = Duration.FromTicks(ticks);
                Duration other = Duration.FromTicks(ticks);

                // Act
                Action act = () => duration.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_an_duration_is_equal_to_itself_it_succeeds()
            {
                // Arrange
                long ticks = new Random().Next();
                Duration duration = Duration.FromTicks(ticks);

                // Act
                Action act = () => duration.Should().Be(duration);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                Duration? duration = default;
                Duration? other = default;

                // Act
                Action act = () => duration.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_fails()
            {
                // Arrange
                Duration? duration = default;
                Duration other = Duration.Zero;

                // Act
                Action act = () => duration.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be equal to {other}, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_fails()
            {
                // Arrange
                Duration duration = Duration.Zero;
                Duration? other = default;

                // Act
                Action act = () => duration.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be equal to <null>, but found {duration}.");
            }

            [Fact]
            public void When_an_duration_is_less_than_an_other_duration_it_fails()
            {
                // Arrange
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other - Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be equal to {other}, but found {duration}.");
            }

            [Fact]
            public void When_an_duration_is_greater_than_an_other_duration_it_fails()
            {
                // Arrange
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other + Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be equal to {other}, but found {duration}.");
            }

            [Fact]
            public void When_an_duration_is_equal_to_a_timespan_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());
                TimeSpan other = duration.ToTimeSpan();

                // Act
                Action act = () => duration.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_less_than_a_timespan_it_fails()
            {
                // Arrange
                TimeSpan other = DateTime.Now.TimeOfDay;
                Duration duration = Duration.FromTimeSpan(other) - Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be equal to {Duration.FromTimeSpan(other)}, but found {duration}.");
            }

            [Fact]
            public void When_an_duration_is_greater_than_a_timespan_it_fails()
            {
                // Arrange
                TimeSpan other = DateTime.Now.TimeOfDay;
                Duration duration = Duration.FromTimeSpan(other) + Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be equal to {Duration.FromTimeSpan(other)}, but found {duration}.");
            }
        }

        public class NotBe
        {
            [Fact]
            public void When_an_duration_is_less_than_an_other_duration_it_succeeds()
            {
                // Arrange
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other - Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_greater_than_an_other_duration_it_succeeds()
            {
                // Arrange
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other + Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_equal_to_an_other_duration_it_fails()
            {
                // Arrange
                long ticks = new Random().Next();
                Duration other = Duration.FromTicks(ticks);
                Duration duration = Duration.FromTicks(ticks);

                // Act
                Action act = () => duration.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to be equal to {other}, but found {duration}.");
            }

            [Fact]
            public void When_asserting_an_duration_is_not_equal_to_itself_it_fails()
            {
                // Arrange
                long ticks = new Random().Next();
                Duration duration = Duration.FromTicks(ticks);

                // Act
                Action act = () => duration.Should().NotBe(duration);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to be equal to {duration}, but found {duration}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_null_it_fails()
            {
                // Arrange
                Duration? duration = default;
                Duration? other = default;

                // Act
                Action act = () => duration.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to be equal to <null>, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_not_null_it_succeeds()
            {
                // Arrange
                Duration? duration = default;
                Duration other = Duration.Zero;

                // Act
                Action act = () => duration.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.Zero;
                Duration? other = default;

                // Act
                Action act = () => duration.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_equal_to_a_timespan_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());
                TimeSpan other = duration.ToTimeSpan();

                // Act
                Action act = () => duration.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to be equal to {Duration.FromTimeSpan(other)}, but found {duration}.");
            }

            [Fact]
            public void When_an_duration_is_less_than_a_timespan_it_succeeds()
            {
                // Arrange
                TimeSpan other = DateTime.Now.TimeOfDay;
                Duration duration = Duration.FromTimeSpan(other) - Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_greater_than_a_timespan_it_succeeds()
            {
                // Arrange
                TimeSpan other = DateTime.Now.TimeOfDay;
                Duration duration = Duration.FromTimeSpan(other) + Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }
        }

        public class BeGreaterThan
        {
            [Fact]
            public void When_an_duration_is_greater_than_an_other_duration_it_succeeds()
            {
                // Arrange
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other + Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().BeGreaterThan(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_less_than_an_other_duration_it_fails()
            {
                // Arrange
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other - Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().BeGreaterThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be greater than {other}, but found {duration}.");
            }

            [Fact]
            public void When_an_duration_is_equal_to_an_other_duration_it_fails()
            {
                // Arrange
                long ticks = new Random().Next();
                Duration other = Duration.FromTicks(ticks);
                Duration duration = Duration.FromTicks(ticks);

                // Act
                Action act = () => duration.Should().BeGreaterThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be greater than {other}, but found {duration}.");
            }

            [Fact]
            public void When_asserting_an_duration_is_greater_than_itself_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action act = () => duration.Should().BeGreaterThan(duration);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be greater than {duration}, but found {duration}.");
            }
        }

        public class BeGreaterThanOrEqualTo
        {
            [Fact]
            public void When_asserting_an_duration_is_greater_than_or_equal_to_itself_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action act = () => duration.Should().BeGreaterThanOrEqualTo(duration);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_equal_to_an_other_duration_it_succeeds()
            {
                // Arrange
                long ticks = new Random().Next();
                Duration other = Duration.FromTicks(ticks);
                Duration duration = Duration.FromTicks(ticks);

                // Act
                Action act = () => duration.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_greater_than_an_other_duration_it_succeeds()
            {
                // Arrange
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other + Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_less_than_an_other_duration_it_fails()
            {
                // Arrange
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other - Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be greater than or equal to {other}, but found {duration}.");
            }
        }

        public class BeLessThan
        {
            [Fact]
            public void When_an_duration_is_less_than_an_other_duration_it_succeeds()
            {
                // Arrange
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other - Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().BeLessThan(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_greater_than_an_other_duration_it_fails()
            {
                // Arrange
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other + Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().BeLessThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be less than {other}, but found {duration}.");
            }

            [Fact]
            public void When_an_duration_is_equal_to_an_other_duration_it_fails()
            {
                // Arrange
                long ticks = new Random().Next();
                Duration other = Duration.FromTicks(ticks);
                Duration duration = Duration.FromTicks(ticks);

                // Act
                Action act = () => duration.Should().BeLessThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be less than {other}, but found {duration}.");
            }

            [Fact]
            public void When_asserting_an_duration_is_less_than_itself_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action act = () => duration.Should().BeLessThan(duration);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be less than {duration}, but found {duration}.");
            }
        }

        public class BeLessThanOrEqualTo
        {
            [Fact]
            public void When_asserting_an_duration_is_less_than_or_equal_to_itself_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action act = () => duration.Should().BeLessThanOrEqualTo(duration);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_equal_to_an_other_duration_it_succeeds()
            {
                // Arrange
                long ticks = new Random().Next();
                Duration other = Duration.FromTicks(ticks);
                Duration duration = Duration.FromTicks(ticks);

                // Act
                Action act = () => duration.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_less_than_an_other_duration_it_succeeds()
            {
                // Arrange
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other - Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_greater_than_an_other_duration_it_fails()
            {
                // Arrange
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other + Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be less than or equal to {other}, but found {duration}.");
            }
        }

        public class BeCloseTo
        {
            [Fact]
            public void When_the_precision_is_negative_it_fails()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(-1);
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action withDuration = () => duration.Should().BeCloseTo(duration, precision);
                Action timesamp = () => duration.Should().BeCloseTo(duration, precision.ToTimeSpan());

                // Assert
                withDuration.Should().Throw<ArgumentOutOfRangeException>()
                    .WithMessage("*The value of precision must be non-negative.*");

                timesamp.Should().Throw<ArgumentOutOfRangeException>()
                    .WithMessage("*The value of precision must be non-negative.*");
            }

            [Fact]
            public void When_asserting_an_duration_is_close_to_itself_it_succeeds()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action withDuration = () => duration.Should().BeCloseTo(duration, precision);
                Action timesamp = () => duration.Should().BeCloseTo(duration, precision.ToTimeSpan());

                // Assert
                withDuration.Should().NotThrow();
                timesamp.Should().NotThrow();
            }

            [Fact]
            public void When_two_durations_are_equal_it_succeeds()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                long ticks = new Random().Next();
                Duration duration = Duration.FromTicks(ticks);
                Duration other = Duration.FromTicks(ticks);

                // Act
                Action withDuration = () => duration.Should().BeCloseTo(other, precision);
                Action timestamp = () => duration.Should().BeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withDuration.Should().NotThrow();
                timestamp.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_close_to_but_less_than_an_other_duration_it_succeeds()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other - precision;

                // Act
                Action withDuration = () => duration.Should().BeCloseTo(other, precision);
                Action timestamp = () => duration.Should().BeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withDuration.Should().NotThrow();
                timestamp.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_close_to_but_greater_than_an_other_duration_it_succeeds()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other + precision;

                // Act
                Action withDuration = () => duration.Should().BeCloseTo(other, precision);
                Action timestamp = () => duration.Should().BeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withDuration.Should().NotThrow();
                timestamp.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_not_close_to_and_less_than_an_other_duration_it_fails()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other - precision - Duration.FromSeconds(1);

                // Act
                Action withDuration = () => duration.Should().BeCloseTo(other, precision);
                Action timestamp = () => duration.Should().BeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withDuration.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be within {precision} from {other}, but it was {other - duration}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be within {precision} from {other}, but it was {other - duration}.");
            }

            [Fact]
            public void When_an_duration_is_not_close_to_and_greater_than_an_other_duration_it_fails()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other + precision + Duration.FromSeconds(1);

                // Act
                Action withDuration = () => duration.Should().BeCloseTo(other, precision);
                Action timestamp = () => duration.Should().BeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withDuration.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to be within {precision} from {other}, but it was {duration - other}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to be within {precision} from {other}, but it was {duration - other}.");
            }
        }

        public class NotBeCloseTo
        {
            [Fact]
            public void When_an_duration_is_not_close_to_and_less_than_an_other_duration_it_succeeds()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other - precision - Duration.FromSeconds(1);

                // Act
                Action withDuration = () => duration.Should().NotBeCloseTo(other, precision);
                Action timestamp = () => duration.Should().NotBeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withDuration.Should().NotThrow();
                timestamp.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_not_close_to_and_greater_than_an_other_duration_it_succeeds()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other + precision + Duration.FromSeconds(1);

                // Act
                Action withDuration = () => duration.Should().NotBeCloseTo(other, precision);
                Action timestamp = () => duration.Should().NotBeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withDuration.Should().NotThrow();
                timestamp.Should().NotThrow();
            }

            [Fact]
            public void When_the_precision_is_negative_it_fails()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(-1);
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action withDuration = () => duration.Should().NotBeCloseTo(duration, precision);
                Action timesamp = () => duration.Should().NotBeCloseTo(duration, precision.ToTimeSpan());

                // Assert
                withDuration.Should().Throw<ArgumentOutOfRangeException>()
                    .WithMessage("*The value of precision must be non-negative.*");

                timesamp.Should().Throw<ArgumentOutOfRangeException>()
                    .WithMessage("*The value of precision must be non-negative.*");
            }

            [Fact]
            public void When_asserting_an_duration_is_not_close_to_itself_it_fails()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action withDuration = () => duration.Should().NotBeCloseTo(duration, precision);
                Action timestamp = () => duration.Should().NotBeCloseTo(duration, precision.ToTimeSpan());

                // Assert
                withDuration.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to be within {precision} from {duration}, but it was {Duration.Zero}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to be within {precision} from {duration}, but it was {Duration.Zero}.");
            }

            [Fact]
            public void When_two_durations_are_equal_it_fails()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                long ticks = new Random().Next();
                Duration duration = Duration.FromTicks(ticks);
                Duration other = Duration.FromTicks(ticks);

                // Act
                Action withDuration = () => duration.Should().NotBeCloseTo(other, precision);
                Action timestamp = () => duration.Should().NotBeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withDuration.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to be within {precision} from {other}, but it was {Duration.Zero}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to be within {precision} from {other}, but it was {Duration.Zero}.");
            }

            [Fact]
            public void When_an_duration_is_close_to_but_less_than_an_other_duration_it_fails()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other - precision;

                // Act
                Action withDuration = () => duration.Should().NotBeCloseTo(other, precision);
                Action timestamp = () => duration.Should().NotBeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withDuration.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to be within {precision} from {other}, but it was {other - duration}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to be within {precision} from {other}, but it was {other - duration}.");
            }

            [Fact]
            public void When_an_duration_is_close_to_but_greater_than_an_other_duration_it_fails()
            {
                // Arrange
                Duration precision = Duration.FromSeconds(new Random().Next(1, 100));
                Duration other = Duration.FromTicks(new Random().Next());
                Duration duration = other + precision;

                // Act
                Action withDuration = () => duration.Should().NotBeCloseTo(other, precision);
                Action timestamp = () => duration.Should().NotBeCloseTo(other, precision.ToTimeSpan());

                // Assert
                withDuration.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to be within {precision} from {other}, but it was {duration - other}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to be within {precision} from {other}, but it was {duration - other}.");
            }
        }

        public class BePositive
        {
            [Fact]
            public void When_an_duration_is_positive_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().BePositive();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_negative_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromSeconds(-1);

                // Act
                Action act = () => duration.Should().BePositive();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be positive, but found {duration}.");
            }

            [Fact]
            public void When_an_duration_is_zero_it_fails()
            {
                // Arrange
                Duration duration = Duration.Zero;

                // Act
                Action act = () => duration.Should().BePositive();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be positive, but found {duration}.");
            }
        }

        public class BeNegative
        {
            [Fact]
            public void When_an_duration_is_negative_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromSeconds(-1);

                // Act
                Action act = () => duration.Should().BeNegative();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_positive_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().BeNegative();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be negative, but found {duration}.");
            }

            [Fact]
            public void When_an_duration_is_zero_it_fails()
            {
                // Arrange
                Duration duration = Duration.Zero;

                // Act
                Action act = () => duration.Should().BeNegative();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be negative, but found {duration}.");
            }
        }

        public class BeZero
        {
            [Fact]
            public void When_an_duration_is_zero_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.Zero;

                // Act
                Action act = () => duration.Should().BeZero();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_positive_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().BeZero();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be zero, but found {duration}.");
            }

            [Fact]
            public void When_an_duration_is_negative_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromSeconds(-1);

                // Act
                Action act = () => duration.Should().BeZero();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to be zero, but found {duration}.");
            }
        }

        public class NotBeZero
        {
            [Fact]
            public void When_an_duration_is_zero_it_fails()
            {
                // Arrange
                Duration duration = Duration.Zero;

                // Act
                Action act = () => duration.Should().NotBeZero();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to be zero, but found {duration}.");
            }

            [Fact]
            public void When_an_duration_is_positive_it_suceeds()
            {
                // Arrange
                Duration duration = Duration.FromSeconds(1);

                // Act
                Action act = () => duration.Should().NotBeZero();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_is_negative_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromSeconds(-1);

                // Act
                Action act = () => duration.Should().NotBeZero();

                // Assert
                act.Should().NotThrow();
            }
        }
    }
}
