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
                    .WithMessage($"Did not expect {nameof(localTime)} to be equal to {other}, but found {localTime}.");
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
                    .WithMessage($"Did not expect {nameof(localTime)} to be equal to {localTime}, but found {localTime}.");
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
                    .WithMessage($"Did not expect {nameof(localTime)} to be equal to <null>, but found <null>.");
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
                    .WithMessage($"Expected {nameof(localTime)} to have clock hour of the half-day of {time}, but {nameof(localTime)} was <null>.");
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
                    .WithMessage($"Did not expect {nameof(localTime)} to have clock hour of the half-day of {time}, but {nameof(localTime)} was <null>.");
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
                    .WithMessage($"Expected {nameof(localTime)} to have hour of day {hourOfDay}, but {nameof(localTime)} was <null>.");
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
                    .WithMessage($"Did not expect {nameof(localTime)} to have hour of day {hourOfDay}, but {nameof(localTime)} was <null>.");
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
                    .WithMessage($"Expected {nameof(localTime)} to have millisecond {millisecondOfDay}, but {nameof(localTime)} was <null>.");
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
                    .WithMessage($"Did not expect {nameof(localTime)} to have millisecond {millisecondOfDay}, but {nameof(localTime)} was <null>.");
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
                    .WithMessage($"Expected {nameof(localTime)} to have minute {minuteOfDay}, but {nameof(localTime)} was <null>.");
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
                    .WithMessage($"Did not expect {nameof(localTime)} to have minute {minuteOfDay}, but {nameof(localTime)} was <null>.");
            }
        }

        public class HaveNanosecondOfDay
        {
            [Fact]
            public void When_a_local_time_has_the_specified_nanosecond_of_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().HaveNanosecondOfDay(localTime.NanosecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_nanosecond_of_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                long nanosecondOfDay = localTime.PlusNanoseconds(1).NanosecondOfDay;

                // Act
                Action act = () => localTime.Should().HaveNanosecondOfDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have nanosecond of day {nanosecondOfDay.AsFormatted()}, but found {localTime.NanosecondOfDay.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_has_the_specified_nanosecond_of_day_it_fails()
            {
                // Arrange
                long nanosecondOfDay = new Random().Next(1, 999_999_999);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().HaveNanosecondOfDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have nanosecond of day {nanosecondOfDay.AsFormatted()}, but {nameof(localTime)} was <null>.");
            }
        }

        public class NotHaveNanosecondOfDay
        {
            [Fact]
            public void When_a_local_time_has_the_specified_nanosecond_of_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().NotHaveNanosecondOfDay(localTime.NanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have nanosecond of day {localTime.NanosecondOfDay.AsFormatted()}.");
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_nanosecond_of_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                long nanosecondOfDay = localTime.PlusNanoseconds(1).NanosecondOfDay;

                // Act
                Action act = () => localTime.Should().NotHaveNanosecondOfDay(nanosecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_does_not_have_the_specified_nanosecond_of_day_it_fails()
            {
                // Arrange
                long nanosecondOfDay = new Random().Next(1, 999_999_999);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().NotHaveNanosecondOfDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have nanosecond of day {nanosecondOfDay.AsFormatted()}, but {nameof(localTime)} was <null>.");
            }
        }

        public class HaveNanosecondOfSecond
        {
            [Fact]
            public void When_a_local_time_has_the_specified_nanosecond_of_second_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().HaveNanosecondOfSecond(localTime.NanosecondOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_nanosecond_of_second_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                int nanosecondOfSecond = localTime.PlusNanoseconds(1).NanosecondOfSecond;

                // Act
                Action act = () => localTime.Should().HaveNanosecondOfSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have nanosecond of second {nanosecondOfSecond}, but found {localTime.NanosecondOfSecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_has_the_specified_nanosecond_of_second_it_fails()
            {
                // Arrange
                int nanosecondOfSecond = new Random().Next(1, 999_999_999);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().HaveNanosecondOfSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have nanosecond of second {nanosecondOfSecond}, but {nameof(localTime)} was <null>.");
            }
        }

        public class NotHaveNanosecondOfSecond
        {
            [Fact]
            public void When_a_local_time_has_the_specified_nanosecond_of_second_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().NotHaveNanosecondOfSecond(localTime.NanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have nanosecond of second {localTime.NanosecondOfSecond}.");
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_nanosecond_of_second_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                int nanosecondOfSecond = localTime.PlusNanoseconds(1).NanosecondOfSecond;

                // Act
                Action act = () => localTime.Should().NotHaveNanosecondOfSecond(nanosecondOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_does_not_have_the_specified_nanosecond_of_second_it_fails()
            {
                // Arrange
                int nanosecondOfSecond = new Random().Next(1, 999_999_999);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().NotHaveNanosecondOfSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have nanosecond of second {nanosecondOfSecond}, but {nameof(localTime)} was <null>.");
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
                    .WithMessage($"Expected {nameof(localTime)} to have second {second}, but {nameof(localTime)} was <null>.");
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
                    .WithMessage($"Did not expect {nameof(localTime)} to have second {second}, but {nameof(localTime)} was <null>.");
            }
        }

        public class HaveTickOfDay
        {
            [Fact]
            public void When_a_local_time_has_the_specified_tick_of_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().HaveTickOfDay(localTime.TickOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_tick_of_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                long tickOfDay = localTime.PlusTicks(1).TickOfDay;

                // Act
                Action act = () => localTime.Should().HaveTickOfDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have tick of day {tickOfDay.AsFormatted()}, but found {localTime.TickOfDay.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_has_the_specified_tick_of_day_it_fails()
            {
                // Arrange
                long tickOfDay = new Random().Next(1, 999_999_999);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().HaveTickOfDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have tick of day {tickOfDay.AsFormatted()}, but {nameof(localTime)} was <null>.");
            }
        }

        public class NotHaveTickOfDay
        {
            [Fact]
            public void When_a_local_time_has_the_specified_tick_of_day_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().NotHaveTickOfDay(localTime.TickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have tick of day {localTime.TickOfDay.AsFormatted()}.");
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_tick_of_day_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                long tickOfDay = localTime.PlusTicks(1).TickOfDay;

                // Act
                Action act = () => localTime.Should().NotHaveTickOfDay(tickOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_does_not_have_the_specified_tick_of_day_it_fails()
            {
                // Arrange
                long tickOfDay = new Random().Next(1, 999_999_999);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().NotHaveTickOfDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have tick of day {tickOfDay.AsFormatted()}, but {nameof(localTime)} was <null>.");
            }
        }

        public class HaveTickOfSecond
        {
            [Fact]
            public void When_a_local_time_has_the_specified_tick_of_second_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().HaveTickOfSecond(localTime.TickOfSecond);

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
                Action act = () => localTime.Should().HaveTickOfSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have tick of second {tickOfSecond}, but found {localTime.TickOfSecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_time_has_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                int tickOfSecond = new Random().Next(1, 9_999_999);
                LocalTime? localTime = null;

                // Act
                Action act = () => localTime.Should().HaveTickOfSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localTime)} to have tick of second {tickOfSecond}, but {nameof(localTime)} was <null>.");
            }
        }

        public class NotHaveTickOfSecond
        {
            [Fact]
            public void When_a_local_time_has_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);

                // Act
                Action act = () => localTime.Should().NotHaveTickOfSecond(localTime.TickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have tick of second {localTime.TickOfSecond}.");
            }

            [Fact]
            public void When_a_local_time_does_not_have_the_specified_tick_of_second_it_succeeds()
            {
                // Arrange
                LocalTime localTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                int tickOfSecond = localTime.PlusTicks(1).TickOfSecond;

                // Act
                Action act = () => localTime.Should().NotHaveTickOfSecond(tickOfSecond);

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
                Action act = () => localTime.Should().NotHaveTickOfSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localTime)} to have tick of second {tickOfSecond}, but {nameof(localTime)} was <null>.");
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
