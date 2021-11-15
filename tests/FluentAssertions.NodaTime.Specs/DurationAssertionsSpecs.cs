using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions.NodaTime.Specs.Extensions;

using NodaTime;

using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.NodaTime.Specs
{
    public static class DurationAssertionsSpecs
    {
        private const double DefaultPrecision = 0.01d;

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
                    .WithMessage(
                        $"Expected {nameof(duration)} to be equal to {Duration.FromTimeSpan(other)}, but found {duration}.");
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
                    .WithMessage(
                        $"Expected {nameof(duration)} to be equal to {Duration.FromTimeSpan(other)}, but found {duration}.");
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
                    .WithMessage($"Did not expect {nameof(duration)} to be equal to {other}.");
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
                    .WithMessage($"Did not expect {nameof(duration)} to be equal to {duration}.");
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
                    .WithMessage($"Did not expect {nameof(duration)} to be equal to <null>.");
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
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to be equal to {Duration.FromTimeSpan(other)}.");
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
                    .WithMessage(
                        $"Expected {nameof(duration)} to be within {precision} from {other}, but it was {other - duration}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to be within {precision} from {other}, but it was {other - duration}.");
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
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to be within {precision} from {duration}, but it was {Duration.Zero}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to be within {precision} from {duration}, but it was {Duration.Zero}.");
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
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to be within {precision} from {other}, but it was {Duration.Zero}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to be within {precision} from {other}, but it was {Duration.Zero}.");
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
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to be within {precision} from {other}, but it was {other - duration}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to be within {precision} from {other}, but it was {other - duration}.");
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
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to be within {precision} from {other}, but it was {duration - other}.");
                timestamp.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to be within {precision} from {other}, but it was {duration - other}.");
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

        public class HaveSeconds
        {
            [Fact]
            public void When_an_duration_has_the_specified_seconds_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action act = () => duration.Should().HaveSeconds(duration.Seconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_does_not_have_the_specified_seconds_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());
                int seconds = duration.Plus(Duration.FromSeconds(1)).Seconds;

                // Act
                Action act = () => duration.Should().HaveSeconds(seconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to have {seconds} seconds, but found {duration.Seconds}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_seconds_it_fails()
            {
                // Arrange
                int seconds = new Random().Next(1, 59);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().HaveSeconds(seconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to have {seconds} seconds, but found <null>.");
            }
        }

        public class NotHaveSeconds
        {
            [Fact]
            public void When_an_duration_has_the_specified_seconds_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action act = () => duration.Should().NotHaveSeconds(duration.Seconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to have {duration.Seconds} seconds.");
            }

            [Fact]
            public void When_an_duration_does_not_have_the_specified_seconds_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());
                int seconds = duration.Plus(Duration.FromSeconds(1)).Seconds;

                // Act
                Action act = () => duration.Should().NotHaveSeconds(seconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_seconds_it_fails()
            {
                // Arrange
                int seconds = new Random().Next(1, 59);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().NotHaveSeconds(seconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {seconds} seconds, but found <null>.");
            }
        }

        public class HaveMilliseconds
        {
            [Fact]
            public void When_an_duration_has_the_specified_milliseconds_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action act = () => duration.Should().HaveMilliseconds(duration.Milliseconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_does_not_have_the_specified_milliseconds_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());
                int milliseconds = duration.Plus(Duration.FromMilliseconds(1)).Milliseconds;

                // Act
                Action act = () => duration.Should().HaveMilliseconds(milliseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {milliseconds} milliseconds, but found {duration.Milliseconds}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_milliseconds_it_fails()
            {
                // Arrange
                int milliseconds = new Random().Next(1, 999);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().HaveMilliseconds(milliseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {milliseconds} milliseconds, but found <null>.");
            }
        }

        public class NotHaveMilliseconds
        {
            [Fact]
            public void When_an_duration_has_the_specified_milliseconds_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action act = () => duration.Should().NotHaveMilliseconds(duration.Milliseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to have {duration.Milliseconds} milliseconds.");
            }

            [Fact]
            public void When_an_duration_does_not_have_the_specified_milliseconds_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());
                int milliseconds = duration.Plus(Duration.FromMilliseconds(1)).Milliseconds;

                // Act
                Action act = () => duration.Should().NotHaveMilliseconds(milliseconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_milliseconds_it_fails()
            {
                // Arrange
                int milliseconds = new Random().Next(1, 999);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().NotHaveMilliseconds(milliseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {milliseconds} milliseconds, but found <null>.");
            }
        }

        public class HaveNanosecondsWithinDay
        {
            [Fact]
            public void When_an_duration_has_the_specified_nanoseconds_of_day_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action act = () => duration.Should().HaveNanosecondsWithinDay(duration.NanosecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_does_not_have_the_specified_nanoseconds_of_day_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());
                long nanoseconds = duration.Plus(Duration.FromNanoseconds(1)).NanosecondOfDay;

                // Act
                Action act = () => duration.Should().HaveNanosecondsWithinDay(nanoseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {nanoseconds.AsFormatted()} nanoseconds within the day, but found {duration.NanosecondOfDay.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_nanoseconds_of_day_it_fails()
            {
                // Arrange
                long nanoseconds = new Random().Next(1, 999_999_999);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().HaveNanosecondsWithinDay(nanoseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {nanoseconds.AsFormatted()} nanoseconds within the day, but found <null>.");
            }
        }

        public class NotHaveNanosecondsWithinDay
        {
            [Fact]
            public void When_an_duration_has_the_specified_nanoseconds_of_day_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action act = () => duration.Should().NotHaveNanosecondsWithinDay(duration.NanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {duration.NanosecondOfDay.AsFormatted()} nanoseconds within the day.");
            }

            [Fact]
            public void When_an_duration_does_not_have_the_specified_nanoseconds_of_day_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());
                long nanoseconds = duration.Plus(Duration.FromNanoseconds(1)).NanosecondOfDay;

                // Act
                Action act = () => duration.Should().NotHaveNanosecondsWithinDay(nanoseconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_nanoseconds_of_day_it_fails()
            {
                // Arrange
                long nanoseconds = new Random().Next(1, 999_999_999);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().NotHaveNanosecondsWithinDay(nanoseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {nanoseconds.AsFormatted()} nanoseconds within the day, but found <null>.");
            }
        }

        public class HaveTicks
        {
            [Fact]
            public void When_an_duration_has_the_specified_ticks_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action act = () => duration.Should().HaveTicks(duration.BclCompatibleTicks);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_duration_does_not_have_the_specified_ticks_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());
                long ticks = duration.Plus(Duration.FromSeconds(1)).BclCompatibleTicks;

                // Act
                Action act = () => duration.Should().HaveTicks(ticks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {ticks.AsFormatted()} ticks, but found {duration.BclCompatibleTicks.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_ticks_it_fails()
            {
                // Arrange
                long ticks = new Random().Next(1, 999_999_999);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().HaveTicks(ticks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {ticks.AsFormatted()} ticks, but found <null>.");
            }
        }

        public class NotHaveTicks
        {
            [Fact]
            public void When_an_duration_has_the_specified_ticks_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action act = () => duration.Should().NotHaveTicks(duration.BclCompatibleTicks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to have {duration.BclCompatibleTicks.AsFormatted()} ticks.");
            }

            [Fact]
            public void When_an_duration_does_not_have_the_specified_ticks_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());
                long ticks = duration.Plus(Duration.FromSeconds(1)).BclCompatibleTicks;

                // Act
                Action act = () => duration.Should().NotHaveTicks(ticks);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_ticks_it_fails()
            {
                // Arrange
                long ticks = new Random().Next(1, 999_999_999);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().NotHaveTicks(ticks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {ticks.AsFormatted()} ticks, but found <null>.");
            }
        }

        public class HaveDays
        {
            [Fact]
            public void When_a_duration_has_the_specified_days_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromDays(new Random().Next(1, 1000));

                // Act
                Action act = () => duration.Should().HaveDays(duration.Days);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_days_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromDays(new Random().Next(1, 1000));
                int days = duration.Plus(Duration.FromDays(1)).Days;

                // Act
                Action act = () => duration.Should().HaveDays(days);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to have {days} days, but found {duration.Days}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_has_the_specified_days_it_fails()
            {
                // Arrange
                int days = new Random().Next(1, 100);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().HaveDays(days);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to have {days} days, but found <null>.");
            }
        }

        public class NotHaveDays
        {
            [Fact]
            public void When_a_duration_has_the_specified_days_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromDays(new Random().Next(1, 1000));

                // Act
                Action act = () => duration.Should().NotHaveDays(duration.Days);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to have {duration.Days} days.");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_days_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromDays(new Random().Next(1, 1000));
                int days = duration.Plus(Duration.FromDays(1)).Days;

                // Act
                Action act = () => duration.Should().NotHaveDays(days);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_does_not_have_the_specified_days_it_fails()
            {
                // Arrange
                int days = new Random().Next(1, 100);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().NotHaveDays(days);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to have {days} days, but found <null>.");
            }
        }

        public class HaveHours
        {
            [Fact]
            public void When_a_duration_has_the_specified_hours_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromHours(new Random().Next(0, 23));

                // Act
                Action act = () => duration.Should().HaveHours(duration.Hours);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_hours_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromHours(new Random().Next(0, 23));
                int hours = duration.Plus(Duration.FromHours(1)).Hours;

                // Act
                Action act = () => duration.Should().HaveHours(hours);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to have {hours} hours, but found {duration.Hours}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_has_the_specified_hours_it_fails()
            {
                // Arrange
                int hours = new Random().Next(0, 23);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().HaveHours(hours);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to have {hours} hours, but found <null>.");
            }
        }

        public class NotHaveHours
        {
            [Fact]
            public void When_a_duration_has_the_specified_hours_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromHours(new Random().Next(0, 23));

                // Act
                Action act = () => duration.Should().NotHaveHours(duration.Hours);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to have {duration.Hours} hours.");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_hours_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromHours(new Random().Next(0, 23));
                int hours = duration.Plus(Duration.FromHours(1)).Hours;

                // Act
                Action act = () => duration.Should().NotHaveHours(hours);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_does_not_have_the_specified_hours_it_fails()
            {
                // Arrange
                int hours = new Random().Next(0, 23);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().NotHaveHours(hours);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to have {hours} hours, but found <null>.");
            }
        }

        public class HaveTotalDays
        {
            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_days_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromDays(new Random().Next(1, 1000));

                // Act
                Action act = () => duration.Should().HaveTotalDays(duration.TotalDays);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_days_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromDays(new Random().Next(1, 1000));
                double days = duration.Plus(Duration.FromDays(1)).TotalDays;

                // Act
                Action act = () => duration.Should().HaveTotalDays(days);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {days.AsFormatted()} total number of days (+/- {DefaultPrecision.AsFormatted()}), but found {duration.TotalDays.AsFormatted()}.");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_days_within_the_specified_precision_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromDays(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double days = duration.TotalDays + precision + precision;

                // Act
                Action act = () => duration.Should().HaveTotalDays(days, precision);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {days.AsFormatted()} total number of days (+/- {precision.AsFormatted()}), but found {duration.TotalDays.AsFormatted()}.");
            }

            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_days_within_the_specified_precision_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromDays(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double days = duration.TotalDays + precision / 2;

                // Act
                Action act = () => duration.Should().HaveTotalDays(days, precision);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_has_the_specified_total_number_of_days_it_fails()
            {
                // Arrange
                double days = new Random().Next(1, 100);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().HaveTotalDays(days);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {days.AsFormatted()} total number of days (+/- {DefaultPrecision.AsFormatted()}), but found <null>.");
            }
        }

        public class NotHaveTotalDays
        {
            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_days_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromDays(new Random().Next(1, 1000));

                // Act
                Action act = () => duration.Should().NotHaveTotalDays(duration.TotalDays);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {duration.TotalDays.AsFormatted()} total number of days (+/- {DefaultPrecision.AsFormatted()}).");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_days_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromDays(new Random().Next(1, 1000));
                double days = duration.Plus(Duration.FromDays(1)).TotalDays;

                // Act
                Action act = () => duration.Should().NotHaveTotalDays(days);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_days_within_the_specified_precision_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromDays(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double days = duration.TotalDays + precision + precision;

                // Act
                Action act = () => duration.Should().NotHaveTotalDays(days, precision);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_days_within_the_specified_precision_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromDays(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double days = duration.TotalDays + precision / 2;

                // Act
                Action act = () => duration.Should().NotHaveTotalDays(days, precision);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {days.AsFormatted()} total number of days (+/- {precision.AsFormatted()}).");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_does_not_have_the_specified_total_number_of_days_it_fails()
            {
                // Arrange
                double days = new Random().Next(1, 100);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().NotHaveTotalDays(days);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {days.AsFormatted()} total number of days (+/- {DefaultPrecision.AsFormatted()}), but found <null>.");
            }
        }

        public class HaveTotalHours
        {
            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_hours_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromHours(new Random().Next(1, 1000));

                // Act
                Action act = () => duration.Should().HaveTotalHours(duration.TotalHours);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_hours_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromHours(new Random().Next(1, 1000));
                double hours = duration.Plus(Duration.FromHours(1)).TotalHours;

                // Act
                Action act = () => duration.Should().HaveTotalHours(hours);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {hours.AsFormatted()} total number of hours (+/- {DefaultPrecision.AsFormatted()}), but found {duration.TotalHours.AsFormatted()}.");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_hours_within_the_specified_precision_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromHours(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double hours = duration.TotalHours + precision + precision;

                // Act
                Action act = () => duration.Should().HaveTotalHours(hours, precision);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {hours.AsFormatted()} total number of hours (+/- {precision.AsFormatted()}), but found {duration.TotalHours.AsFormatted()}.");
            }

            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_hours_within_the_specified_precision_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromHours(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double hours = duration.TotalHours + precision / 2;

                // Act
                Action act = () => duration.Should().HaveTotalHours(hours, precision);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_has_the_specified_total_number_of_hours_it_fails()
            {
                // Arrange
                double hours = new Random().Next(1, 100);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().HaveTotalHours(hours);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {hours.AsFormatted()} total number of hours (+/- {DefaultPrecision.AsFormatted()}), but found <null>.");
            }
        }

        public class NotHaveTotalHours
        {
            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_hours_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromHours(new Random().Next(1, 1000));

                // Act
                Action act = () => duration.Should().NotHaveTotalHours(duration.TotalHours);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {duration.TotalHours.AsFormatted()} total number of hours (+/- {DefaultPrecision.AsFormatted()}).");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_hours_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromHours(new Random().Next(1, 1000));
                double hours = duration.Plus(Duration.FromHours(1)).TotalHours;

                // Act
                Action act = () => duration.Should().NotHaveTotalHours(hours);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_hours_within_the_specified_precision_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromHours(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double hours = duration.TotalHours + precision + precision;

                // Act
                Action act = () => duration.Should().NotHaveTotalHours(hours, precision);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_hours_within_the_specified_precision_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromHours(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double hours = duration.TotalHours + precision / 2;

                // Act
                Action act = () => duration.Should().NotHaveTotalHours(hours, precision);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {hours.AsFormatted()} total number of hours (+/- {precision.AsFormatted()}).");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_does_not_have_the_specified_total_number_of_hours_it_fails()
            {
                // Arrange
                double hours = new Random().Next(1, 100);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().NotHaveTotalHours(hours);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {hours.AsFormatted()} total number of hours (+/- {DefaultPrecision.AsFormatted()}), but found <null>.");
            }
        }

        public class HaveTotalMilliseconds
        {
            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_milliseconds_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromMilliseconds(new Random().Next());

                // Act
                Action act = () => duration.Should().HaveTotalMilliseconds(duration.TotalMilliseconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_milliseconds_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromMilliseconds(new Random().Next());
                double milliseconds = duration.Plus(Duration.FromMilliseconds(1)).TotalMilliseconds;

                // Act
                Action act = () => duration.Should().HaveTotalMilliseconds(milliseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {milliseconds.AsFormatted()} total number of milliseconds (+/- {DefaultPrecision.AsFormatted()}), but found {duration.TotalMilliseconds.AsFormatted()}.");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_milliseconds_within_the_specified_precision_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromMilliseconds(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double milliseconds = duration.TotalMilliseconds + precision + precision;

                // Act
                Action act = () => duration.Should().HaveTotalMilliseconds(milliseconds, precision);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {milliseconds.AsFormatted()} total number of milliseconds (+/- {precision.AsFormatted()}), but found {duration.TotalMilliseconds.AsFormatted()}.");
            }

            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_milliseconds_within_the_specified_precision_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromMilliseconds(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double milliseconds = duration.TotalMilliseconds + precision / 2;

                // Act
                Action act = () => duration.Should().HaveTotalMilliseconds(milliseconds, precision);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_has_the_specified_total_number_of_milliseconds_it_fails()
            {
                // Arrange
                double milliseconds = new Random().Next(1, 999);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().HaveTotalMilliseconds(milliseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {milliseconds.AsFormatted()} total number of milliseconds (+/- {DefaultPrecision.AsFormatted()}), but found <null>.");
            }
        }

        public class NotHaveTotalMilliseconds
        {
            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_milliseconds_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromMilliseconds(new Random().Next());

                // Act
                Action act = () => duration.Should().NotHaveTotalMilliseconds(duration.TotalMilliseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {duration.TotalMilliseconds.AsFormatted()} total number of milliseconds (+/- {DefaultPrecision.AsFormatted()}).");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_milliseconds_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromMilliseconds(new Random().Next());
                double milliseconds = duration.Plus(Duration.FromMilliseconds(1)).TotalMilliseconds;

                // Act
                Action act = () => duration.Should().NotHaveTotalMilliseconds(milliseconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_milliseconds_within_the_specified_precision_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromMilliseconds(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double milliseconds = duration.TotalMilliseconds + precision + precision;

                // Act
                Action act = () => duration.Should().NotHaveTotalMilliseconds(milliseconds, precision);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_milliseconds_within_the_specified_precision_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromMilliseconds(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double milliseconds = duration.TotalMilliseconds + precision / 2;

                // Act
                Action act = () => duration.Should().NotHaveTotalMilliseconds(milliseconds, precision);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {milliseconds.AsFormatted()} total number of milliseconds (+/- {precision.AsFormatted()}).");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_does_not_have_the_specified_total_number_of_milliseconds_it_fails()
            {
                // Arrange
                double milliseconds = new Random().Next(1, 999);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().NotHaveTotalMilliseconds(milliseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {milliseconds.AsFormatted()} total number of milliseconds (+/- {DefaultPrecision.AsFormatted()}), but found <null>.");
            }
        }

        public class HaveTotalMinutes
        {
            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_minutes_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromMinutes(new Random().Next());

                // Act
                Action act = () => duration.Should().HaveTotalMinutes(duration.TotalMinutes);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_minutes_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromMinutes(new Random().Next());
                double minutes = duration.Plus(Duration.FromMinutes(1)).TotalMinutes;

                // Act
                Action act = () => duration.Should().HaveTotalMinutes(minutes);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {minutes.AsFormatted()} total number of minutes (+/- {DefaultPrecision.AsFormatted()}), but found {duration.TotalMinutes.AsFormatted()}.");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_minutes_within_the_specified_precision_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromMinutes(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double minutes = duration.TotalMinutes + precision + precision;

                // Act
                Action act = () => duration.Should().HaveTotalMinutes(minutes, precision);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {minutes.AsFormatted()} total number of minutes (+/- {precision.AsFormatted()}), but found {duration.TotalMinutes.AsFormatted()}.");
            }

            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_minutes_within_the_specified_precision_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromMinutes(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double minutes = duration.TotalMinutes + precision / 2;

                // Act
                Action act = () => duration.Should().HaveTotalMinutes(minutes, precision);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_has_the_specified_total_number_of_minutes_it_fails()
            {
                // Arrange
                double minutes = new Random().Next(1, 100);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().HaveTotalMinutes(minutes);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {minutes.AsFormatted()} total number of minutes (+/- {DefaultPrecision.AsFormatted()}), but found <null>.");
            }
        }

        public class NotHaveTotalMinutes
        {
            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_minutes_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromMinutes(new Random().Next());

                // Act
                Action act = () => duration.Should().NotHaveTotalMinutes(duration.TotalMinutes);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {duration.TotalMinutes.AsFormatted()} total number of minutes (+/- {DefaultPrecision.AsFormatted()}).");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_minutes_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromMinutes(new Random().Next());
                double minutes = duration.Plus(Duration.FromMinutes(1)).TotalMinutes;

                // Act
                Action act = () => duration.Should().NotHaveTotalMinutes(minutes);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_minutes_within_the_specified_precision_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromMinutes(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double minutes = duration.TotalMinutes + precision + precision;

                // Act
                Action act = () => duration.Should().NotHaveTotalMinutes(minutes, precision);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_minutes_within_the_specified_precision_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromMinutes(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double minutes = duration.TotalMinutes + precision / 2;

                // Act
                Action act = () => duration.Should().NotHaveTotalMinutes(minutes, precision);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {minutes.AsFormatted()} total number of minutes (+/- {precision.AsFormatted()}).");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_does_not_have_the_specified_total_number_of_minutes_it_fails()
            {
                // Arrange
                double minutes = new Random().Next(1, 100);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().NotHaveTotalMinutes(minutes);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {minutes.AsFormatted()} total number of minutes (+/- {DefaultPrecision.AsFormatted()}), but found <null>.");
            }
        }

        public class HaveTotalNanoseconds
        {
            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_nanoseconds_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromNanoseconds(new Random().Next());

                // Act
                Action act = () => duration.Should().HaveTotalNanoseconds(duration.TotalNanoseconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_nanoseconds_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromNanoseconds(new Random().Next());
                double nanoseconds = duration.Plus(Duration.FromNanoseconds(1)).TotalNanoseconds;

                // Act
                Action act = () => duration.Should().HaveTotalNanoseconds(nanoseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {nanoseconds.AsFormatted()} total number of nanoseconds (+/- {DefaultPrecision.AsFormatted()}), but found {duration.TotalNanoseconds.AsFormatted()}.");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_nanoseconds_within_the_specified_precision_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromNanoseconds(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double nanoseconds = duration.TotalNanoseconds + precision + precision;

                // Act
                Action act = () => duration.Should().HaveTotalNanoseconds(nanoseconds, precision);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {nanoseconds.AsFormatted()} total number of nanoseconds (+/- {precision.AsFormatted()}), but found {duration.TotalNanoseconds.AsFormatted()}.");
            }

            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_nanoseconds_within_the_specified_precision_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromNanoseconds(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double nanoseconds = duration.TotalNanoseconds + precision / 2;

                // Act
                Action act = () => duration.Should().HaveTotalNanoseconds(nanoseconds, precision);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_has_the_specified_total_number_of_nanoseconds_it_fails()
            {
                // Arrange
                double nanoseconds = new Random().Next(1, 999_999_999);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().HaveTotalNanoseconds(nanoseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {nanoseconds.AsFormatted()} total number of nanoseconds (+/- {DefaultPrecision.AsFormatted()}), but found <null>.");
            }
        }

        public class NotHaveTotalNanoseconds
        {
            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_nanoseconds_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromNanoseconds(new Random().Next());

                // Act
                Action act = () => duration.Should().NotHaveTotalNanoseconds(duration.TotalNanoseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {duration.TotalNanoseconds.AsFormatted()} total number of nanoseconds (+/- {DefaultPrecision.AsFormatted()}).");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_nanoseconds_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromNanoseconds(new Random().Next());
                double nanoseconds = duration.Plus(Duration.FromNanoseconds(1)).TotalNanoseconds;

                // Act
                Action act = () => duration.Should().NotHaveTotalNanoseconds(nanoseconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_nanoseconds_within_the_specified_precision_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromNanoseconds(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double nanoseconds = duration.TotalNanoseconds + precision + precision;

                // Act
                Action act = () => duration.Should().NotHaveTotalNanoseconds(nanoseconds, precision);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_nanoseconds_within_the_specified_precision_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromNanoseconds(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double nanoseconds = duration.TotalNanoseconds + precision / 2;

                // Act
                Action act = () => duration.Should().NotHaveTotalNanoseconds(nanoseconds, precision);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {nanoseconds.AsFormatted()} total number of nanoseconds (+/- {precision.AsFormatted()}).");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_does_not_have_the_specified_total_number_of_nanoseconds_it_fails()
            {
                // Arrange
                double nanoseconds = new Random().Next(1, 999_999_999);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().NotHaveTotalNanoseconds(nanoseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {nanoseconds.AsFormatted()} total number of nanoseconds (+/- {DefaultPrecision.AsFormatted()}), but found <null>.");
            }
        }

        public class HaveTotalSeconds
        {
            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_seconds_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromSeconds(new Random().Next());

                // Act
                Action act = () => duration.Should().HaveTotalSeconds(duration.TotalSeconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_seconds_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromSeconds(new Random().Next());
                double seconds = duration.Plus(Duration.FromSeconds(1)).TotalSeconds;

                // Act
                Action act = () => duration.Should().HaveTotalSeconds(seconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {seconds.AsFormatted()} total number of seconds (+/- {DefaultPrecision.AsFormatted()}), but found {duration.TotalSeconds.AsFormatted()}.");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_seconds_within_the_specified_precision_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromSeconds(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double seconds = duration.TotalSeconds + precision + precision;

                // Act
                Action act = () => duration.Should().HaveTotalSeconds(seconds, precision);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {seconds.AsFormatted()} total number of seconds (+/- {precision.AsFormatted()}), but found {duration.TotalSeconds.AsFormatted()}.");
            }

            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_seconds_within_the_specified_precision_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromSeconds(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double seconds = duration.TotalSeconds + precision / 2;

                // Act
                Action act = () => duration.Should().HaveTotalSeconds(seconds, precision);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_has_the_specified_total_number_of_seconds_it_fails()
            {
                // Arrange
                double seconds = new Random().Next(1, 1000);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().HaveTotalSeconds(seconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {seconds.AsFormatted()} total number of seconds (+/- {DefaultPrecision.AsFormatted()}), but found <null>.");
            }
        }

        public class NotHaveTotalSeconds
        {
            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_seconds_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromSeconds(new Random().Next());

                // Act
                Action act = () => duration.Should().NotHaveTotalSeconds(duration.TotalSeconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {duration.TotalSeconds.AsFormatted()} total number of seconds (+/- {DefaultPrecision.AsFormatted()}).");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_seconds_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromSeconds(new Random().Next());
                double seconds = duration.Plus(Duration.FromSeconds(1)).TotalSeconds;

                // Act
                Action act = () => duration.Should().NotHaveTotalSeconds(seconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_seconds_within_the_specified_precision_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromSeconds(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double seconds = duration.TotalSeconds + precision + precision;

                // Act
                Action act = () => duration.Should().NotHaveTotalSeconds(seconds, precision);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_seconds_within_the_specified_precision_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromSeconds(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double seconds = duration.TotalSeconds + precision / 2;

                // Act
                Action act = () => duration.Should().NotHaveTotalSeconds(seconds, precision);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {seconds.AsFormatted()} total number of seconds (+/- {precision.AsFormatted()}).");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_does_not_have_the_specified_total_number_of_seconds_it_fails()
            {
                // Arrange
                double seconds = new Random().Next(1, 1000);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().NotHaveTotalSeconds(seconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {seconds.AsFormatted()} total number of seconds (+/- {DefaultPrecision.AsFormatted()}), but found <null>.");
            }
        }

        public class HaveTotalTicks
        {
            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_ticks_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action act = () => duration.Should().HaveTotalTicks(duration.TotalTicks);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_ticks_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());
                double ticks = duration.Plus(Duration.FromTicks(1)).TotalTicks;

                // Act
                Action act = () => duration.Should().HaveTotalTicks(ticks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {ticks.AsFormatted()} total number of ticks (+/- {DefaultPrecision.AsFormatted()}), but found {duration.TotalTicks.AsFormatted()}.");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_ticks_within_the_specified_precision_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double ticks = duration.TotalTicks + precision + precision;

                // Act
                Action act = () => duration.Should().HaveTotalTicks(ticks, precision);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {ticks.AsFormatted()} total number of ticks (+/- {precision.AsFormatted()}), but found {duration.TotalTicks.AsFormatted()}.");
            }

            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_ticks_within_the_specified_precision_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double ticks = duration.TotalTicks + precision / 2;

                // Act
                Action act = () => duration.Should().HaveTotalTicks(ticks, precision);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_has_the_specified_total_number_of_ticks_it_fails()
            {
                // Arrange
                double ticks = new Random().Next(1, 999_999_999);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().HaveTotalTicks(ticks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {ticks.AsFormatted()} total number of ticks (+/- {DefaultPrecision.AsFormatted()}), but found <null>.");
            }
        }

        public class NotHaveTotalTicks
        {
            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_ticks_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action act = () => duration.Should().NotHaveTotalTicks(duration.TotalTicks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {duration.TotalTicks.AsFormatted()} total number of ticks (+/- {DefaultPrecision.AsFormatted()}).");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_ticks_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());
                double ticks = duration.Plus(Duration.FromTicks(1)).TotalTicks;

                // Act
                Action act = () => duration.Should().NotHaveTotalTicks(ticks);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_total_number_of_ticks_within_the_specified_precision_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double ticks = duration.TotalTicks + precision + precision;

                // Act
                Action act = () => duration.Should().NotHaveTotalTicks(ticks, precision);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_has_the_specified_total_number_of_ticks_within_the_specified_precision_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next(1, 1000));
                double precision = new Random().Next(1, 100) / 1000d;
                double ticks = duration.TotalTicks + precision / 2;

                // Act
                Action act = () => duration.Should().NotHaveTotalTicks(ticks, precision);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {ticks.AsFormatted()} total number of ticks (+/- {precision.AsFormatted()}).");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_does_not_have_the_specified_total_number_of_ticks_it_fails()
            {
                // Arrange
                double ticks = new Random().Next(1, 999_999_999);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().NotHaveTotalTicks(ticks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {ticks.AsFormatted()} total number of ticks (+/- {DefaultPrecision.AsFormatted()}), but found <null>.");
            }
        }

        public class HaveMinutes
        {
            [Fact]
            public void When_a_duration_has_the_specified_minutes_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromMinutes(new Random().Next());

                // Act
                Action act = () => duration.Should().HaveMinutes(duration.Minutes);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_minutes_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromMinutes(new Random().Next());
                int minutes = duration.Plus(Duration.FromMinutes(1)).Minutes;

                // Act
                Action act = () => duration.Should().HaveMinutes(minutes);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to have {minutes} minutes, but found {duration.Minutes}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_has_the_specified_minutes_it_fails()
            {
                // Arrange
                int minutes = new Random().Next(1, 59);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().HaveMinutes(minutes);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(duration)} to have {minutes} minutes, but found <null>.");
            }
        }

        public class NotHaveMinutes
        {
            [Fact]
            public void When_a_duration_has_the_specified_minutes_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromMinutes(new Random().Next());

                // Act
                Action act = () => duration.Should().NotHaveMinutes(duration.Minutes);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to have {duration.Minutes} minutes.");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_minutes_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromMinutes(new Random().Next());
                int minutes = duration.Plus(Duration.FromMinutes(1)).Minutes;

                // Act
                Action act = () => duration.Should().NotHaveMinutes(minutes);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_does_not_have_the_specified_minutes_it_fails()
            {
                // Arrange
                int minutes = new Random().Next(1, 59);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().NotHaveMinutes(minutes);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {minutes} minutes, but found <null>.");
            }
        }

        public class HaveSubsecondNanoseconds
        {
            [Fact]
            public void When_a_duration_has_the_specified_subseconds_in_nanoseconds_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromNanoseconds(new Random().Next());

                // Act
                Action act = () => duration.Should().HaveSubsecondInNanoseconds(duration.SubsecondNanoseconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_subseconds_in_nanoseconds_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromNanoseconds(new Random().Next());
                int nanoseconds = duration.Plus(Duration.FromNanoseconds(1)).SubsecondNanoseconds;

                // Act
                Action act = () => duration.Should().HaveSubsecondInNanoseconds(nanoseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {nanoseconds} subseconds in nanoseconds, but found {duration.SubsecondNanoseconds}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_has_the_specified_subseconds_in_nanoseconds_it_fails()
            {
                // Arrange
                int nanoseconds = new Random().Next(1, 999_999_999);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().HaveSubsecondInNanoseconds(nanoseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {nanoseconds} subseconds in nanoseconds, but found <null>.");
            }
        }

        public class NotHaveSubsecondNanoseconds
        {
            [Fact]
            public void When_a_duration_has_the_specified_subseconds_in_nanoseconds_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromNanoseconds(new Random().Next());

                // Act
                Action act = () => duration.Should().NotHaveSubsecondInNanoseconds(duration.SubsecondNanoseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to have {duration.SubsecondNanoseconds} subseconds in nanoseconds.");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_subseconds_in_nanoseconds_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromNanoseconds(new Random().Next());
                int nanoseconds = duration.Plus(Duration.FromNanoseconds(1)).SubsecondNanoseconds;

                // Act
                Action act = () => duration.Should().NotHaveSubsecondInNanoseconds(nanoseconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_does_not_have_the_specified_subseconds_in_nanoseconds_it_fails()
            {
                // Arrange
                int nanoseconds = new Random().Next(1, 999_999_999);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().NotHaveSubsecondInNanoseconds(nanoseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {nanoseconds} subseconds in nanoseconds, but found <null>.");
            }
        }

        public class HaveSubsecondTicks
        {
            [Fact]
            public void When_a_duration_has_the_specified_subseconds_in_ticks_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action act = () => duration.Should().HaveSubsecondInTicks(duration.SubsecondTicks);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_subseconds_in_ticks_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());
                int ticks = duration.Plus(Duration.FromTicks(1)).SubsecondTicks;

                // Act
                Action act = () => duration.Should().HaveSubsecondInTicks(ticks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {ticks} subseconds in ticks, but found {duration.SubsecondTicks}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_has_the_specified_subseconds_in_ticks_it_fails()
            {
                // Arrange
                int ticks = new Random().Next(1, 999_999_999);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().HaveSubsecondInTicks(ticks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(duration)} to have {ticks} subseconds in ticks, but found <null>.");
            }
        }

        public class NotHaveSubsecondTicks
        {
            [Fact]
            public void When_a_duration_has_the_specified_subseconds_in_ticks_it_fails()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());

                // Act
                Action act = () => duration.Should().NotHaveSubsecondInTicks(duration.SubsecondTicks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(duration)} to have {duration.SubsecondTicks} subseconds in ticks.");
            }

            [Fact]
            public void When_a_duration_does_not_have_the_specified_subseconds_in_ticks_it_succeeds()
            {
                // Arrange
                Duration duration = Duration.FromTicks(new Random().Next());
                int ticks = duration.Plus(Duration.FromTicks(1)).SubsecondTicks;

                // Act
                Action act = () => duration.Should().NotHaveSubsecondInTicks(ticks);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_duration_does_not_have_the_specified_subseconds_in_ticks_it_fails()
            {
                // Arrange
                int ticks = new Random().Next(1, 999_999_999);
                Duration? duration = null;

                // Act
                Action act = () => duration.Should().NotHaveSubsecondInTicks(ticks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(duration)} to have {ticks} subseconds in ticks, but found <null>.");
            }
        }
    }
}
