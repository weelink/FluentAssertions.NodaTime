using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions.NodaTime.Specs.Extensions;

using NodaTime;

using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.NodaTime.Specs
{
    public static class LocalTimeAssertionsSpecs
    {
        public class Be
        {
            [Fact]
            public void When_a_local_time_is_equal_to_an_other_local_time_it_succeeds()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(now);
                LocalTime other = LocalTime.FromTicksSinceMidnight(now);

                // Act
                Action act = () => localTime.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_local_time_is_equal_to_itself_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().Be(localTime);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                LocalTime? localTime = default;
                LocalTime? other = default;

                // Act
                Action act = () => localTime.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_fails()
            {
                // Arrange
                LocalTime? localTime = default;
                LocalTime other = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to be equal to {other}, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                LocalTime? other = default;

                // Act
                Action act = () => localTime.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to be equal to <null>, but found {localTime}.");
            }
        }

        public class NotBe
        {
            [Fact]
            public void When_a_local_time_is_equal_to_an_other_local_time_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime other = LocalTime.FromTicksSinceMidnight(now);
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(now);

                // Act
                Action act = () => localTime.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to be equal to {other}.");
            }

            [Fact]
            public void When_asserting_a_local_time_is_not_equal_to_itself_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(now);

                // Act
                Action act = () => localTime.Should().NotBe(localTime);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to be equal to {localTime}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_null_it_fails()
            {
                // Arrange
                LocalTime? localTime = default;
                LocalTime? other = default;

                // Act
                Action act = () => localTime.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to be equal to <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_not_null_it_succeeds()
            {
                // Arrange
                LocalTime? localTime = default;
                LocalTime other = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                LocalTime? other = default;

                // Act
                Action act = () => localTime.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }
        }

        public class HaveClockHourOfHalfDay
        {
            [Fact]
            public void When_a_local_time_has_the_specified_clock_hour_of_half_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().HaveClockHourOfHalfDay(localTime.ClockHourOfHalfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                int time = localTime.PlusHours(1).ClockHourOfHalfDay;

                // Act
                Action act = () => localTime.Should().HaveClockHourOfHalfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have clock hour of the half-day of {time}, but found {localTime.ClockHourOfHalfDay}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_has_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                int time = new Random().Next(12);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().HaveClockHourOfHalfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have clock hour of the half-day of {time}, but found <null>.");
            }
        }

        public class NotHaveClockHourOfHalfDay
        {
            [Fact]
            public void When_a_local_time_has_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().NotHaveClockHourOfHalfDay(localTime.ClockHourOfHalfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have clock hour of the half-day of {localTime.ClockHourOfHalfDay}.");
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_clock_hour_of_half_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                int time = localTime.PlusHours(1).ClockHourOfHalfDay;

                // Act
                Action act = () => localTime.Should().NotHaveClockHourOfHalfDay(time);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_does_not_have_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                int time = new Random().Next(12);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().NotHaveClockHourOfHalfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have clock hour of the half-day of {time}, but found <null>.");
            }
        }

        public class HaveHour
        {
            [Fact]
            public void When_a_local_time_has_the_specified_hour_of_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().HaveHour(localTime.Hour);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                int hourOfDay = localTime.PlusHours(1).Hour;

                // Act
                Action act = () => localTime.Should().HaveHour(hourOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have hour of day {hourOfDay}, but found {localTime.Hour}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_has_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                int hourOfDay = new Random().Next(1, 23);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().HaveHour(hourOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have hour of day {hourOfDay}, but found <null>.");
            }
        }

        public class NotHaveHour
        {
            [Fact]
            public void When_a_local_time_has_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().NotHaveHour(localTime.Hour);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have hour of day {localTime.Hour}.");
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_hour_of_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                int hourOfDay = localTime.PlusHours(1).Hour;

                // Act
                Action act = () => localTime.Should().NotHaveHour(hourOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_does_not_have_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                int hourOfDay = new Random().Next(1, 23);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().NotHaveHour(hourOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have hour of day {hourOfDay}, but found <null>.");
            }
        }

        public class HaveMillisecond
        {
            [Fact]
            public void When_a_local_time_has_the_specified_millisecond_of_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().HaveMillisecond(localTime.Millisecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                int millisecondOfDay = localTime.PlusMilliseconds(1).Millisecond;

                // Act
                Action act = () => localTime.Should().HaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have millisecond {millisecondOfDay}, but found {localTime.Millisecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_has_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                int millisecondOfDay = new Random().Next(1, 999);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().HaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have millisecond {millisecondOfDay}, but found <null>.");
            }
        }

        public class NotHaveMillisecond
        {
            [Fact]
            public void When_a_local_time_has_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().NotHaveMillisecond(localTime.Millisecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have millisecond {localTime.Millisecond}.");
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_millisecond_of_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                int millisecondOfDay = localTime.PlusMilliseconds(1).Millisecond;

                // Act
                Action act = () => localTime.Should().NotHaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_does_not_have_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                int millisecondOfDay = new Random().Next(1, 999);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().NotHaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have millisecond {millisecondOfDay}, but found <null>.");
            }
        }

        public class HaveMinute
        {
            [Fact]
            public void When_a_local_time_has_the_specified_minute_of_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().HaveMinute(localTime.Minute);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                int minuteOfDay = localTime.PlusMinutes(1).Minute;

                // Act
                Action act = () => localTime.Should().HaveMinute(minuteOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have minute {minuteOfDay}, but found {localTime.Minute}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_has_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                int minuteOfDay = new Random().Next(1, 59);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().HaveMinute(minuteOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have minute {minuteOfDay}, but found <null>.");
            }
        }

        public class NotHaveMinute
        {
            [Fact]
            public void When_a_local_time_has_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().NotHaveMinute(localTime.Minute);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have minute {localTime.Minute}.");
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_minute_of_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                int minuteOfDay = localTime.PlusMinutes(1).Minute;

                // Act
                Action act = () => localTime.Should().NotHaveMinute(minuteOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_does_not_have_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                int minuteOfDay = new Random().Next(1, 59);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().NotHaveMinute(minuteOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have minute {minuteOfDay}, but found <null>.");
            }
        }

        public class HaveNanosecondsWithinDay
        {
            [Fact]
            public void When_a_local_time_has_the_specified_nanoseconds_within_the_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().HaveNanosecondsWithinDay(localTime.NanosecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                long nanosecondOfDay = localTime.PlusNanoseconds(1).NanosecondOfDay;

                // Act
                Action act = () => localTime.Should().HaveNanosecondsWithinDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have {nanosecondOfDay.AsFormatted()} nanoseconds within the day, but found {localTime.NanosecondOfDay.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_has_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                long nanosecondOfDay = new Random().Next(1, 999_999_999);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().HaveNanosecondsWithinDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have {nanosecondOfDay.AsFormatted()} nanoseconds within the day, but found <null>.");
            }
        }

        public class NotHaveNanosecondsWithinDay
        {
            [Fact]
            public void When_a_local_time_has_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().NotHaveNanosecondsWithinDay(localTime.NanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have {localTime.NanosecondOfDay.AsFormatted()} nanoseconds within the day.");
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_nanoseconds_within_the_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                long nanosecondOfDay = localTime.PlusNanoseconds(1).NanosecondOfDay;

                // Act
                Action act = () => localTime.Should().NotHaveNanosecondsWithinDay(nanosecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_does_not_have_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                long nanosecondOfDay = new Random().Next(1, 999_999_999);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().NotHaveNanosecondsWithinDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have {nanosecondOfDay.AsFormatted()} nanoseconds within the day, but found <null>.");
            }
        }

        public class HaveNanosecondsWithinSecond
        {
            [Fact]
            public void When_a_local_time_has_the_specified_nanoseconds_within_the_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().HaveNanosecondsWithinSecond(localTime.NanosecondOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                int nanosecondOfSecond = localTime.PlusNanoseconds(1).NanosecondOfSecond;

                // Act
                Action act = () => localTime.Should().HaveNanosecondsWithinSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have {nanosecondOfSecond} nanoseconds within the second, but found {localTime.NanosecondOfSecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_has_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                int nanosecondOfSecond = new Random().Next(1, 999_999_999);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().HaveNanosecondsWithinSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have {nanosecondOfSecond} nanoseconds within the second, but found <null>.");
            }
        }

        public class NotHaveNanosecondsWithinSecond
        {
            [Fact]
            public void When_a_local_time_has_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().NotHaveNanosecondsWithinSecond(localTime.NanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have {localTime.NanosecondOfSecond} nanoseconds within the second.");
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_nanoseconds_within_the_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                int nanosecondOfSecond = localTime.PlusNanoseconds(1).NanosecondOfSecond;

                // Act
                Action act = () => localTime.Should().NotHaveNanosecondsWithinSecond(nanosecondOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_does_not_have_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                int nanosecondOfSecond = new Random().Next(1, 999_999_999);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().NotHaveNanosecondsWithinSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have {nanosecondOfSecond} nanoseconds within the second, but found <null>.");
            }
        }

        public class HaveSecond
        {
            [Fact]
            public void When_a_local_time_has_the_specified_second_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().HaveSecond(localTime.Second);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_second_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                int second = localTime.PlusSeconds(1).Second;

                // Act
                Action act = () => localTime.Should().HaveSecond(second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have second {second}, but found {localTime.Second}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_has_the_specified_second_it_fails()
            {
                // Arrange
                int second = new Random().Next(1, 59);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().HaveSecond(second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have second {second}, but found <null>.");
            }
        }

        public class NotHaveSecond
        {
            [Fact]
            public void When_a_local_time_has_the_specified_second_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().NotHaveSecond(localTime.Second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have second {localTime.Second}.");
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_second_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                int second = localTime.PlusSeconds(1).Second;

                // Act
                Action act = () => localTime.Should().NotHaveSecond(second);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_does_not_have_the_specified_second_it_fails()
            {
                // Arrange
                int second = new Random().Next(1, 59);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().NotHaveSecond(second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have second {second}, but found <null>.");
            }
        }

        public class HaveTicksWithinDay
        {
            [Fact]
            public void When_a_local_time_has_the_specified_ticks_within_the_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().HaveTicksWithinDay(localTime.TickOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_ticks_within_the_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                long tickOfDay = localTime.PlusTicks(1).TickOfDay;

                // Act
                Action act = () => localTime.Should().HaveTicksWithinDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have {tickOfDay.AsFormatted()} ticks within the day, but found {localTime.TickOfDay.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_has_the_specified_ticks_within_the_day_it_fails()
            {
                // Arrange
                long tickOfDay = new Random().Next(1, 999_999_999);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().HaveTicksWithinDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have {tickOfDay.AsFormatted()} ticks within the day, but found <null>.");
            }
        }

        public class NotHaveTicksWithinDay
        {
            [Fact]
            public void When_a_local_time_has_the_specified_ticks_within_the_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().NotHaveTicksWithinDay(localTime.TickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have {localTime.TickOfDay.AsFormatted()} ticks within the day.");
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_ticks_within_the_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                long tickOfDay = localTime.PlusTicks(1).TickOfDay;

                // Act
                Action act = () => localTime.Should().NotHaveTicksWithinDay(tickOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_does_not_have_the_specified_ticks_within_the_day_it_fails()
            {
                // Arrange
                long tickOfDay = new Random().Next(1, 999_999_999);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().NotHaveTicksWithinDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have {tickOfDay.AsFormatted()} ticks within the day, but found <null>.");
            }
        }

        public class HaveTicksWithinSecond
        {
            [Fact]
            public void When_a_local_time_has_the_specified_tick_of_second_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().HaveTicksWithinSecond(localTime.TickOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                int tickOfSecond = localTime.PlusTicks(1).TickOfSecond;

                // Act
                Action act = () => localTime.Should().HaveTicksWithinSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have {tickOfSecond} ticks within the second, but found {localTime.TickOfSecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_has_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                int tickOfSecond = new Random().Next(1, 9_999_999);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().HaveTicksWithinSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have {tickOfSecond} ticks within the second, but found <null>.");
            }
        }

        public class NotHaveTicksWithinSecond
        {
            [Fact]
            public void When_a_local_time_has_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().NotHaveTicksWithinSecond(localTime.TickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have {localTime.TickOfSecond} ticks within the second.");
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_tick_of_second_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                int tickOfSecond = localTime.PlusTicks(1).TickOfSecond;

                // Act
                Action act = () => localTime.Should().NotHaveTicksWithinSecond(tickOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_does_not_have_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                int tickOfSecond = new Random().Next(1, 9_999_999);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().NotHaveTicksWithinSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have {tickOfSecond} ticks within the second, but found <null>.");
            }
        }

        public class BeGreaterThan
        {
            [Fact]
            public void When_a_local_time_is_greater_than_an_other_local_time_it_succeeds()
            {
                // Arrange
                LocalTime other = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                LocalTime localTime = other + Period.FromSeconds(1);

                // Act
                Action act = () => localTime.Should().BeGreaterThan(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_is_less_than_an_other_local_time_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime other = LocalTime.FromTicksSinceMidnight(now);
                LocalTime localTime = other - Period.FromSeconds(1);

                // Act
                Action act = () => localTime.Should().BeGreaterThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to be greater than {other}, but found {localTime}.");
            }

            [Fact]
            public void When_a_local_time_is_equal_to_an_other_local_time_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(now);
                LocalTime other = LocalTime.FromTicksSinceMidnight(now);

                // Act
                Action act = () => localTime.Should().BeGreaterThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to be greater than {other}, but found {localTime}.");
            }

            [Fact]
            public void When_asserting_a_local_time_is_greater_than_itself_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(now);

                // Act
                Action act = () => localTime.Should().BeGreaterThan(localTime);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to be greater than {localTime}, but found {localTime}.");
            }
        }

        public class BeGreaterThanOrEqualTo
        {
            [Fact]
            public void When_asserting_a_local_time_is_greater_than_or_equal_to_itself_it_succeeds()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(now);

                // Act
                Action act = () => localTime.Should().BeGreaterThanOrEqualTo(localTime);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_is_equal_to_an_other_local_time_it_succeeds()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(now);
                LocalTime other = LocalTime.FromTicksSinceMidnight(now);

                // Act
                Action act = () => localTime.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_is_greater_than_an_other_local_time_it_succeeds()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime other = LocalTime.FromTicksSinceMidnight(now);
                LocalTime localTime = other + Period.FromSeconds(1);

                // Act
                Action act = () => localTime.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_is_less_than_an_other_local_time_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime other = LocalTime.FromTicksSinceMidnight(now);
                LocalTime localTime = other - Period.FromSeconds(1);

                // Act
                Action act = () => localTime.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to be greater than or equal to {other}, but found {localTime}.");
            }
        }

        public class BeLessThan
        {
            [Fact]
            public void When_a_local_time_is_less_than_an_other_local_time_it_succeeds()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime other = LocalTime.FromTicksSinceMidnight(now);
                LocalTime localTime = other - Period.FromSeconds(1);

                // Act
                Action act = () => localTime.Should().BeLessThan(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_is_greater_than_an_other_local_time_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime other = LocalTime.FromTicksSinceMidnight(now);
                LocalTime localTime = other + Period.FromSeconds(1);

                // Act
                Action act = () => localTime.Should().BeLessThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to be less than {other}, but found {localTime}.");
            }

            [Fact]
            public void When_a_local_time_is_equal_to_an_other_local_time_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(now);
                LocalTime other = LocalTime.FromTicksSinceMidnight(now);

                // Act
                Action act = () => localTime.Should().BeLessThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to be less than {other}, but found {localTime}.");
            }

            [Fact]
            public void When_asserting_a_local_time_is_less_than_itself_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(now);

                // Act
                Action act = () => localTime.Should().BeLessThan(localTime);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to be less than {localTime}, but found {localTime}.");
            }
        }

        public class BeLessThanOrEqualTo
        {
            [Fact]
            public void When_asserting_a_local_time_is_less_than_or_equal_to_itself_it_succeeds()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(now);

                // Act
                Action act = () => localTime.Should().BeLessThanOrEqualTo(localTime);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_is_equal_to_an_other_local_time_it_succeeds()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(now);
                LocalTime other = LocalTime.FromTicksSinceMidnight(now);

                // Act
                Action act = () => localTime.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_is_less_than_an_other_local_time_it_succeeds()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime other = LocalTime.FromTicksSinceMidnight(now);
                LocalTime localTime = other - Period.FromSeconds(1);

                // Act
                Action act = () => localTime.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_is_greater_than_an_other_local_time_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                LocalTime other = LocalTime.FromTicksSinceMidnight(now);
                LocalTime localTime = other + Period.FromSeconds(1);

                // Act
                Action act = () => localTime.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to be less than or equal to {other}, but found {localTime}.");
            }
        }
    }
}
