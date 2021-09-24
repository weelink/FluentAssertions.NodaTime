using System;

using FluentAssertions.NodaTime.Specs.Extensions;

using NodaTime;

using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.NodaTime.Specs
{
    public static class PeriodAssertionsSpecs
    {
        public class Be
        {
            [Fact]
            public void When_an_period_is_equal_to_an_other_period_it_succeeds()
            {
                // Arrange
                long ticks = new Random().Next();
                Period period = Period.FromTicks(ticks);
                Period other = Period.FromTicks(ticks);

                // Act
                Action act = () => period.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_an_period_is_equal_to_itself_it_succeeds()
            {
                // Arrange
                long ticks = new Random().Next();
                Period period = Period.FromTicks(ticks);

                // Act
                Action act = () => period.Should().Be(period);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                Period? period = null;
                Period? other = null;

                // Act
                Action act = () => period.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_null_is_equal_to_not_null_it_fails()
            {
                // Arrange
                Period? period = null;
                Period other = Period.Zero;

                // Act
                Action act = () => period.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to be equal to {other}, but found <null>.");
            }

            [Fact]
            public void When_asserting_not_null_is_equal_to_null_it_fails()
            {
                // Arrange
                Period period = Period.Zero;
                Period? other = null;

                // Act
                Action act = () => period.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to be equal to <null>, but found {period}.");
            }

            [Fact]
            public void When_an_period_is_less_than_an_other_period_it_fails()
            {
                // Arrange
                Period other = Period.FromTicks(new Random().Next());
                Period period = other - Period.FromSeconds(new Random().Next(1, 1000));

                // Act
                Action act = () => period.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to be equal to {other}, but found {period}.");
            }

            [Fact]
            public void When_an_period_is_greater_than_an_other_period_it_fails()
            {
                // Arrange
                Period other = Period.FromTicks(new Random().Next());
                Period period = other + Period.FromSeconds(new Random().Next(1, 1000));

                // Act
                Action act = () => period.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to be equal to {other}, but found {period}.");
            }

            [Fact]
            public void When_an_period_is_equal_to_a_duration_it_succeeds()
            {
                // Arrange
                Period period = Period.FromTicks(new Random().Next());
                Duration other = period.ToDuration();

                // Act
                Action act = () => period.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_period_is_less_than_a_duration_it_fails()
            {
                // Arrange
                Period period = Period.FromTicks(new Random().Next());
                Duration other = period.ToDuration().Plus(Duration.FromSeconds(new Random().Next(1, 1000)));

                // Act
                Action act = () => period.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(period)} to be equal to {other}, but found {period}.");
            }

            [Fact]
            public void When_an_period_is_greater_than_a_duration_it_fails()
            {
                // Arrange
                Period period = Period.FromTicks(new Random().Next());
                Duration other = period.ToDuration().Minus(Duration.FromSeconds(new Random().Next(1, 1000)));

                // Act
                Action act = () => period.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(period)} to be equal to {other}, but found {period}.");
            }
        }

        public class NotBe
        {
            [Fact]
            public void When_an_period_is_less_than_an_other_period_it_succeeds()
            {
                // Arrange
                Period other = Period.FromTicks(new Random().Next());
                Period period = other - Period.FromSeconds(new Random().Next(1, 1000));

                // Act
                Action act = () => period.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_period_is_greater_than_an_other_period_it_succeeds()
            {
                // Arrange
                Period other = Period.FromTicks(new Random().Next());
                Period period = other + Period.FromSeconds(new Random().Next(1, 1000));

                // Act
                Action act = () => period.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_period_is_equal_to_an_other_period_it_fails()
            {
                // Arrange
                long ticks = new Random().Next();
                Period other = Period.FromTicks(ticks);
                Period period = Period.FromTicks(ticks);

                // Act
                Action act = () => period.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to be equal to {other}, but found {period}.");
            }

            [Fact]
            public void When_asserting_an_period_is_not_equal_to_itself_it_fails()
            {
                // Arrange
                long ticks = new Random().Next();
                Period period = Period.FromTicks(ticks);

                // Act
                Action act = () => period.Should().NotBe(period);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to be equal to {period}, but found {period}.");
            }

            [Fact]
            public void When_asserting_null_is_not_equal_to_null_it_fails()
            {
                // Arrange
                Period? period = null;
                Period? other = null;

                // Act
                Action act = () => period.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to be equal to <null>, but found <null>.");
            }

            [Fact]
            public void When_asserting_null_is_not_equal_to_not_null_it_succeeds()
            {
                // Arrange
                Period? period = null;
                Period other = Period.Zero;

                // Act
                Action act = () => period.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_not_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                Period period = Period.Zero;
                Period? other = null;

                // Act
                Action act = () => period.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_period_is_equal_to_a_duration_it_fails()
            {
                // Arrange
                Period period = Period.FromTicks(new Random().Next());
                Duration other = period.ToDuration();

                // Act
                Action act = () => period.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(period)} to be equal to {other}, but found {period}.");
            }

            [Fact]
            public void When_an_period_is_less_than_a_duration_it_succeeds()
            {
                // Arrange
                Period other = Period.FromTicks(new Random().Next());
                Period period = other - Period.FromSeconds(new Random().Next(1, 1000));

                // Act
                Action act = () => period.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_period_is_greater_than_a_duration_it_succeeds()
            {
                // Arrange
                Period other = Period.FromTicks(new Random().Next());
                Period period = other + Period.FromSeconds(new Random().Next(1, 1000));

                // Act
                Action act = () => period.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }
        }

        public class BeZero
        {
            [Fact]
            public void When_an_period_is_zero_it_succeeds()
            {
                // Arrange
                Period period = Period.Zero;

                // Act
                Action act = () => period.Should().BeZero();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_period_is_positive_it_fails()
            {
                // Arrange
                Period period = Period.FromSeconds(new Random().Next(1, 1000));

                // Act
                Action act = () => period.Should().BeZero();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to be zero, but found {period}.");
            }

            [Fact]
            public void When_an_period_is_negative_it_fails()
            {
                // Arrange
                Period period = Period.FromSeconds(-1);

                // Act
                Action act = () => period.Should().BeZero();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to be zero, but found {period}.");
            }
        }

        public class NotBeZero
        {
            [Fact]
            public void When_an_period_is_zero_it_fails()
            {
                // Arrange
                Period period = Period.Zero;

                // Act
                Action act = () => period.Should().NotBeZero();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to be zero, but found {period}.");
            }

            [Fact]
            public void When_an_period_is_positive_it_suceeds()
            {
                // Arrange
                Period period = Period.FromSeconds(new Random().Next(1, 1000));

                // Act
                Action act = () => period.Should().NotBeZero();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_period_is_negative_it_succeeds()
            {
                // Arrange
                Period period = Period.FromSeconds(-1);

                // Act
                Action act = () => period.Should().NotBeZero();

                // Assert
                act.Should().NotThrow();
            }
        }

        public class HaveSeconds
        {
            [Fact]
            public void When_an_period_has_the_specified_seconds_it_succeeds()
            {
                // Arrange
                Period period = Period.FromTicks(new Random().Next());

                // Act
                Action act = () => period.Should().HaveSeconds(period.Seconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_period_does_not_have_the_specified_seconds_it_fails()
            {
                // Arrange
                Period period = Period.FromSeconds(new Random().Next(1, 1000));
                long seconds = period.Seconds + 1;

                // Act
                Action act = () => period.Should().HaveSeconds(seconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to have {seconds.AsFormatted()} seconds, but found {period.Seconds.AsFormatted()}.");
            }

            [Fact]
            public void When_asserting_a_null_local_date_time_has_the_specified_seconds_it_fails()
            {
                // Arrange
                long seconds = new Random().Next(1, 59);
                Period? period = null;

                // Act
                Action act = () => period.Should().HaveSeconds(seconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to have {seconds.AsFormatted()} seconds, but {nameof(period)} was <null>.");
            }
        }

        public class NotHaveSeconds
        {
            [Fact]
            public void When_an_period_has_the_specified_seconds_it_fails()
            {
                // Arrange
                Period period = Period.FromTicks(new Random().Next());

                // Act
                Action act = () => period.Should().NotHaveSeconds(period.Seconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to have {period.Seconds.AsFormatted()} seconds.");
            }

            [Fact]
            public void When_an_period_does_not_have_the_specified_seconds_it_succeeds()
            {
                // Arrange
                Period period = Period.FromTicks(new Random().Next());
                long seconds = period.Seconds + 1;

                // Act
                Action act = () => period.Should().NotHaveSeconds(seconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_seconds_it_fails()
            {
                // Arrange
                long seconds = new Random().Next(1, 59);
                Period? period = null;

                // Act
                Action act = () => period.Should().NotHaveSeconds(seconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(period)} to have {seconds.AsFormatted()} seconds, but {nameof(period)} was <null>.");
            }
        }

        public class HaveMilliseconds
        {
            [Fact]
            public void When_an_period_has_the_specified_milliseconds_it_succeeds()
            {
                // Arrange
                Period period = Period.FromTicks(new Random().Next());

                // Act
                Action act = () => period.Should().HaveMilliseconds(period.Milliseconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_period_does_not_have_the_specified_milliseconds_it_fails()
            {
                // Arrange
                Period period = Period.FromMilliseconds(new Random().Next(1, 1000));
                long milliseconds = period.Milliseconds + 1;

                // Act
                Action act = () => period.Should().HaveMilliseconds(milliseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(period)} to have {milliseconds.AsFormatted()} milliseconds, but found {period.Milliseconds.AsFormatted()}.");
            }

            [Fact]
            public void When_asserting_a_null_local_date_time_has_the_specified_milliseconds_it_fails()
            {
                // Arrange
                long milliseconds = new Random().Next(1, 999);
                Period? period = null;

                // Act
                Action act = () => period.Should().HaveMilliseconds(milliseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(period)} to have {milliseconds.AsFormatted()} milliseconds, but {nameof(period)} was <null>.");
            }
        }

        public class NotHaveMilliseconds
        {
            [Fact]
            public void When_an_period_has_the_specified_milliseconds_it_fails()
            {
                // Arrange
                Period period = Period.FromTicks(new Random().Next());

                // Act
                Action act = () => period.Should().NotHaveMilliseconds(period.Milliseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to have {period.Milliseconds.AsFormatted()} milliseconds.");
            }

            [Fact]
            public void When_an_period_does_not_have_the_specified_milliseconds_it_succeeds()
            {
                // Arrange
                Period period = Period.FromMilliseconds(new Random().Next(1, 1000));
                long milliseconds = period.Milliseconds + 1;

                // Act
                Action act = () => period.Should().NotHaveMilliseconds(milliseconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_milliseconds_it_fails()
            {
                // Arrange
                long milliseconds = new Random().Next(1, 999);
                Period? period = null;

                // Act
                Action act = () => period.Should().NotHaveMilliseconds(milliseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(period)} to have {milliseconds.AsFormatted()} milliseconds, but {nameof(period)} was <null>.");
            }
        }

        public class HaveNanoseconds
        {
            [Fact]
            public void When_an_period_has_the_specified_nanoseconds_it_succeeds()
            {
                // Arrange
                Period period = Period.FromTicks(new Random().Next());

                // Act
                Action act = () => period.Should().HaveNanoseconds(period.Nanoseconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_period_does_not_have_the_specified_nanoseconds_it_fails()
            {
                // Arrange
                Period period = Period.FromNanoseconds(new Random().Next(1, 1000));
                long nanoseconds = period.Nanoseconds + 1;

                // Act
                Action act = () => period.Should().HaveNanoseconds(nanoseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(period)} to have {nanoseconds.AsFormatted()} nanoseconds, but found {period.Nanoseconds.AsFormatted()}.");
            }

            [Fact]
            public void When_asserting_a_null_local_date_time_has_the_specified_nanoseconds_it_fails()
            {
                // Arrange
                long nanoseconds = new Random().Next(1, 999_999_999);
                Period? period = null;

                // Act
                Action act = () => period.Should().HaveNanoseconds(nanoseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(period)} to have {nanoseconds.AsFormatted()} nanoseconds, but {nameof(period)} was <null>.");
            }
        }

        public class NotHaveNanoseconds
        {
            [Fact]
            public void When_an_period_has_the_specified_nanoseconds_it_fails()
            {
                // Arrange
                Period period = Period.FromTicks(new Random().Next());

                // Act
                Action act = () => period.Should().NotHaveNanoseconds(period.Nanoseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(period)} to have {period.Nanoseconds.AsFormatted()} nanoseconds.");
            }

            [Fact]
            public void When_an_period_does_not_have_the_specified_nanoseconds_it_succeeds()
            {
                // Arrange
                Period period = Period.FromNanoseconds(new Random().Next(1, 1000));
                long nanoseconds = period.Nanoseconds + 1;

                // Act
                Action act = () => period.Should().NotHaveNanoseconds(nanoseconds);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_nanoseconds_it_fails()
            {
                // Arrange
                long nanoseconds = new Random().Next(1, 999_999_999);
                Period? period = null;

                // Act
                Action act = () => period.Should().NotHaveNanoseconds(nanoseconds);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(period)} to have {nanoseconds.AsFormatted()} nanoseconds, but {nameof(period)} was <null>.");
            }
        }

        public class HaveTicks
        {
            [Fact]
            public void When_an_period_has_the_specified_ticks_it_succeeds()
            {
                // Arrange
                Period period = Period.FromTicks(new Random().Next());

                // Act
                Action act = () => period.Should().HaveTicks(period.Ticks);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_period_does_not_have_the_specified_ticks_it_fails()
            {
                // Arrange
                Period period = Period.FromTicks(new Random().Next(1, 1000));
                long ticks = period.Ticks + 1;

                // Act
                Action act = () => period.Should().HaveTicks(ticks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(period)} to have {ticks.AsFormatted()} ticks, but found {period.Ticks.AsFormatted()}.");
            }

            [Fact]
            public void When_asserting_a_null_local_date_time_has_the_specified_ticks_it_fails()
            {
                // Arrange
                long ticks = new Random().Next(1, 999_999_999);
                Period? period = null;

                // Act
                Action act = () => period.Should().HaveTicks(ticks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(period)} to have {ticks.AsFormatted()} ticks, but {nameof(period)} was <null>.");
            }
        }

        public class NotHaveTicks
        {
            [Fact]
            public void When_an_period_has_the_specified_ticks_it_fails()
            {
                // Arrange
                Period period = Period.FromTicks(new Random().Next());

                // Act
                Action act = () => period.Should().NotHaveTicks(period.Ticks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to have {period.Ticks.AsFormatted()} ticks.");
            }

            [Fact]
            public void When_an_period_does_not_have_the_specified_ticks_it_succeeds()
            {
                // Arrange
                Period period = Period.FromTicks(new Random().Next(1, 1000));
                long ticks = period.Ticks + 1;

                // Act
                Action act = () => period.Should().NotHaveTicks(ticks);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_ticks_it_fails()
            {
                // Arrange
                long ticks = new Random().Next(1, 999_999_999);
                Period? period = null;

                // Act
                Action act = () => period.Should().NotHaveTicks(ticks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(period)} to have {ticks.AsFormatted()} ticks, but {nameof(period)} was <null>.");
            }
        }

        public class HaveHours
        {
            [Fact]
            public void When_an_period_has_the_specified_hours_it_succeeds()
            {
                // Arrange
                Period period = Period.FromHours(new Random().Next());

                // Act
                Action act = () => period.Should().HaveHours(period.Hours);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_period_does_not_have_the_specified_hours_it_fails()
            {
                // Arrange
                Period period = Period.FromHours(new Random().Next(1, 1000));
                long hours = period.Hours + 1;

                // Act
                Action act = () => period.Should().HaveHours(hours);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(period)} to have {hours.AsFormatted()} hours, but found {period.Hours.AsFormatted()}.");
            }

            [Fact]
            public void When_asserting_a_null_local_date_time_has_the_specified_hours_it_fails()
            {
                // Arrange
                long hours = new Random().Next(1, 999_999_999);
                Period? period = null;

                // Act
                Action act = () => period.Should().HaveHours(hours);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(period)} to have {hours.AsFormatted()} hours, but {nameof(period)} was <null>.");
            }
        }

        public class NotHaveHours
        {
            [Fact]
            public void When_an_period_has_the_specified_hours_it_fails()
            {
                // Arrange
                Period period = Period.FromHours(new Random().Next());

                // Act
                Action act = () => period.Should().NotHaveHours(period.Hours);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to have {period.Hours.AsFormatted()} hours.");
            }

            [Fact]
            public void When_an_period_does_not_have_the_specified_hours_it_succeeds()
            {
                // Arrange
                Period period = Period.FromHours(new Random().Next(1, 1000));
                long hours = period.Hours + 1;

                // Act
                Action act = () => period.Should().NotHaveHours(hours);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_hours_it_fails()
            {
                // Arrange
                long hours = new Random().Next(1, 999_999_999);
                Period? period = null;

                // Act
                Action act = () => period.Should().NotHaveHours(hours);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(period)} to have {hours.AsFormatted()} hours, but {nameof(period)} was <null>.");
            }
        }

        public class HaveDays
        {
            [Fact]
            public void When_a_period_has_the_specified_days_it_succeeds()
            {
                // Arrange
                Period period = Period.FromDays(new Random().Next(1, 1000));

                // Act
                Action act = () => period.Should().HaveDays(period.Days);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_period_does_not_have_the_specified_days_it_fails()
            {
                // Arrange
                Period period = Period.FromDays(new Random().Next(1, 1000));
                int days = period.Days + 1;

                // Act
                Action act = () => period.Should().HaveDays(days);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to have {days} days, but found {period.Days}.");
            }

            [Fact]
            public void When_asserting_a_null_period_has_the_specified_days_it_fails()
            {
                // Arrange
                int days = new Random().Next(1, 100);
                Period? period = null;

                // Act
                Action act = () => period.Should().HaveDays(days);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to have {days} days, but {nameof(period)} was <null>.");
            }
        }

        public class NotHaveDays
        {
            [Fact]
            public void When_a_period_has_the_specified_days_it_fails()
            {
                // Arrange
                Period period = Period.FromDays(new Random().Next(1, 1000));

                // Act
                Action act = () => period.Should().NotHaveDays(period.Days);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to have {period.Days} days.");
            }

            [Fact]
            public void When_a_period_does_not_have_the_specified_days_it_succeeds()
            {
                // Arrange
                Period period = Period.FromDays(new Random().Next(1, 1000));
                int days = period.Days + 1;

                // Act
                Action act = () => period.Should().NotHaveDays(days);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_null_period_does_not_have_the_specified_days_it_fails()
            {
                // Arrange
                int days = new Random().Next(1, 100);
                Period? period = null;

                // Act
                Action act = () => period.Should().NotHaveDays(days);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to have {days} days, but {nameof(period)} was <null>.");
            }
        }

        public class HaveYears
        {
            [Fact]
            public void When_a_period_has_the_specified_years_it_succeeds()
            {
                // Arrange
                Period period = Period.FromYears(new Random().Next(1, 1000));

                // Act
                Action act = () => period.Should().HaveYears(period.Years);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_period_does_not_have_the_specified_years_it_fails()
            {
                // Arrange
                Period period = Period.FromYears(new Random().Next(1, 1000));
                int years = period.Years + 1;

                // Act
                Action act = () => period.Should().HaveYears(years);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to have {years} years, but found {period.Years}.");
            }

            [Fact]
            public void When_asserting_a_null_period_has_the_specified_years_it_fails()
            {
                // Arrange
                int years = new Random().Next(1, 100);
                Period? period = null;

                // Act
                Action act = () => period.Should().HaveYears(years);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to have {years} years, but {nameof(period)} was <null>.");
            }
        }

        public class NotHaveYears
        {
            [Fact]
            public void When_a_period_has_the_specified_years_it_fails()
            {
                // Arrange
                Period period = Period.FromYears(new Random().Next(1, 1000));

                // Act
                Action act = () => period.Should().NotHaveYears(period.Years);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to have {period.Years} years.");
            }

            [Fact]
            public void When_a_period_does_not_have_the_specified_years_it_succeeds()
            {
                // Arrange
                Period period = Period.FromYears(new Random().Next(1, 1000));
                int years = period.Years + 1;

                // Act
                Action act = () => period.Should().NotHaveYears(years);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_null_period_does_not_have_the_specified_years_it_fails()
            {
                // Arrange
                int years = new Random().Next(1, 100);
                Period? period = null;

                // Act
                Action act = () => period.Should().NotHaveYears(years);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to have {years} years, but {nameof(period)} was <null>.");
            }
        }

        public class HaveWeeks
        {
            [Fact]
            public void When_a_period_has_the_specified_weeks_it_succeeds()
            {
                // Arrange
                Period period = Period.FromWeeks(new Random().Next(1, 1000));

                // Act
                Action act = () => period.Should().HaveWeeks(period.Weeks);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_period_does_not_have_the_specified_weeks_it_fails()
            {
                // Arrange
                Period period = Period.FromWeeks(new Random().Next(1, 1000));
                int weeks = period.Weeks + 1;

                // Act
                Action act = () => period.Should().HaveWeeks(weeks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to have {weeks} weeks, but found {period.Weeks}.");
            }

            [Fact]
            public void When_asserting_a_null_period_has_the_specified_weeks_it_fails()
            {
                // Arrange
                int weeks = new Random().Next(1, 100);
                Period? period = null;

                // Act
                Action act = () => period.Should().HaveWeeks(weeks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to have {weeks} weeks, but {nameof(period)} was <null>.");
            }
        }

        public class NotHaveWeeks
        {
            [Fact]
            public void When_a_period_has_the_specified_weeks_it_fails()
            {
                // Arrange
                Period period = Period.FromWeeks(new Random().Next(1, 1000));

                // Act
                Action act = () => period.Should().NotHaveWeeks(period.Weeks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to have {period.Weeks} weeks.");
            }

            [Fact]
            public void When_a_period_does_not_have_the_specified_weeks_it_succeeds()
            {
                // Arrange
                Period period = Period.FromWeeks(new Random().Next(1, 1000));
                int weeks = period.Weeks + 1;

                // Act
                Action act = () => period.Should().NotHaveWeeks(weeks);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_null_period_does_not_have_the_specified_weeks_it_fails()
            {
                // Arrange
                int weeks = new Random().Next(1, 100);
                Period? period = null;

                // Act
                Action act = () => period.Should().NotHaveWeeks(weeks);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to have {weeks} weeks, but {nameof(period)} was <null>.");
            }
        }

        public class HaveMonths
        {
            [Fact]
            public void When_an_period_has_the_specified_months_it_succeeds()
            {
                // Arrange
                Period period = Period.FromMonths(new Random().Next());

                // Act
                Action act = () => period.Should().HaveMonths(period.Months);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_an_period_does_not_have_the_specified_months_it_fails()
            {
                // Arrange
                Period period = Period.FromMonths(new Random().Next(1, 1000));
                int months = period.Months + 1;

                // Act
                Action act = () => period.Should().HaveMonths(months);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(period)} to have {months} months, but found {period.Months}.");
            }

            [Fact]
            public void When_asserting_a_null_local_date_time_has_the_specified_months_it_fails()
            {
                // Arrange
                int months = new Random().Next(1, 100);
                Period? period = null;

                // Act
                Action act = () => period.Should().HaveMonths(months);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Expected {nameof(period)} to have {months} months, but {nameof(period)} was <null>.");
            }
        }

        public class NotHaveMonths
        {
            [Fact]
            public void When_an_period_has_the_specified_months_it_fails()
            {
                // Arrange
                Period period = Period.FromMonths(new Random().Next());

                // Act
                Action act = () => period.Should().NotHaveMonths(period.Months);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to have {period.Months} months.");
            }

            [Fact]
            public void When_an_period_does_not_have_the_specified_months_it_succeeds()
            {
                // Arrange
                Period period = Period.FromMonths(new Random().Next(1, 1000));
                int months = period.Months + 1;

                // Act
                Action act = () => period.Should().NotHaveMonths(months);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_months_it_fails()
            {
                // Arrange
                int months = new Random().Next(1, 100);
                Period? period = null;

                // Act
                Action act = () => period.Should().NotHaveMonths(months);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(period)} to have {months} months, but {nameof(period)} was <null>.");
            }
        }

        public class HaveMinutes
        {
            [Fact]
            public void When_a_period_has_the_specified_minutes_it_succeeds()
            {
                // Arrange
                Period period = Period.FromMinutes(new Random().Next());

                // Act
                Action act = () => period.Should().HaveMinutes(period.Minutes);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_period_does_not_have_the_specified_minutes_it_fails()
            {
                // Arrange
                Period period = Period.FromMinutes(new Random().Next());
                long minutes = period.Minutes + 1;

                // Act
                Action act = () => period.Should().HaveMinutes(minutes);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to have {minutes.AsFormatted()} minutes, but found {period.Minutes.AsFormatted()}.");
            }

            [Fact]
            public void When_asserting_a_null_period_has_the_specified_minutes_it_fails()
            {
                // Arrange
                long minutes = new Random().Next(1, 59);
                Period? period = null;

                // Act
                Action act = () => period.Should().HaveMinutes(minutes);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to have {minutes.AsFormatted()} minutes, but {nameof(period)} was <null>.");
            }
        }

        public class NotHaveMinutes
        {
            [Fact]
            public void When_a_period_has_the_specified_minutes_it_fails()
            {
                // Arrange
                Period period = Period.FromMinutes(new Random().Next());

                // Act
                Action act = () => period.Should().NotHaveMinutes(period.Minutes);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to have {period.Minutes.AsFormatted()} minutes.");
            }

            [Fact]
            public void When_a_period_does_not_have_the_specified_minutes_it_succeeds()
            {
                // Arrange
                Period period = Period.FromMinutes(new Random().Next());
                long minutes = period.Minutes + 1;

                // Act
                Action act = () => period.Should().NotHaveMinutes(minutes);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_null_period_does_not_have_the_specified_minutes_it_fails()
            {
                // Arrange
                long minutes = new Random().Next(1, 59);
                Period? period = null;

                // Act
                Action act = () => period.Should().NotHaveMinutes(minutes);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage(
                        $"Did not expect {nameof(period)} to have {minutes.AsFormatted()} minutes, but {nameof(period)} was <null>.");
            }
        }
        
        public class HaveDateComponent
        {
            [Fact]
            public void When_a_period_has_a_date_component_it_succeeds()
            {
                // Arrange
                Period period = Period.FromDays(new Random().Next());

                // Act
                Action act = () => period.Should().HaveDateComponent();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_period_does_not_have_a_date_component_it_fails()
            {
                // Arrange
                Period period = Period.FromMinutes(new Random().Next());

                // Act
                Action act = () => period.Should().HaveDateComponent();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to have a date component.");
            }

            [Fact]
            public void When_asserting_a_null_period_has_the_specified_minutes_it_fails()
            {
                Period? period = null;

                // Act
                Action act = () => period.Should().HaveDateComponent();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to have a date component, but {nameof(period)} was <null>.");
            }
        }
        
        public class NotHaveDateComponent
        {
            [Fact]
            public void When_a_period_does_not_have_a_date_component_it_succeeds()
            {
                // Arrange
                Period period = Period.FromMinutes(new Random().Next());

                // Act
                Action act = () => period.Should().NotHaveDateComponent();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_period_has_a_date_component_it_fails()
            {
                // Arrange
                Period period = Period.FromDays(new Random().Next());

                // Act
                Action act = () => period.Should().NotHaveDateComponent();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to have a date component.");
            }

            [Fact]
            public void When_asserting_a_null_period_has_the_specified_minutes_it_fails()
            {
                Period? period = null;

                // Act
                Action act = () => period.Should().NotHaveDateComponent();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to have a date component, but {nameof(period)} was <null>.");
            }
        }
        
        public class HaveTimeComponent
        {
            [Fact]
            public void When_a_period_has_a_time_component_it_succeeds()
            {
                // Arrange
                Period period = Period.FromMinutes(new Random().Next());

                // Act
                Action act = () => period.Should().HaveTimeComponent();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_period_does_not_have_a_time_component_it_fails()
            {
                // Arrange
                Period period = Period.FromDays(new Random().Next());

                // Act
                Action act = () => period.Should().HaveTimeComponent();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to have a time component.");
            }

            [Fact]
            public void When_asserting_a_null_period_has_the_specified_minutes_it_fails()
            {
                Period? period = null;

                // Act
                Action act = () => period.Should().HaveTimeComponent();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(period)} to have a time component, but {nameof(period)} was <null>.");
            }
        }
        
        public class NotHaveTimeComponent
        {
            [Fact]
            public void When_a_period_does_not_have_a_time_component_it_succeeds()
            {
                // Arrange
                Period period = Period.FromDays(new Random().Next());

                // Act
                Action act = () => period.Should().NotHaveTimeComponent();

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_period_has_a_time_component_it_fails()
            {
                // Arrange
                Period period = Period.FromMinutes(new Random().Next());

                // Act
                Action act = () => period.Should().NotHaveTimeComponent();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to have a time component.");
            }

            [Fact]
            public void When_asserting_a_null_period_has_the_specified_minutes_it_fails()
            {
                Period? period = null;

                // Act
                Action act = () => period.Should().NotHaveTimeComponent();

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(period)} to have a time component, but {nameof(period)} was <null>.");
            }
        }
    }
}
