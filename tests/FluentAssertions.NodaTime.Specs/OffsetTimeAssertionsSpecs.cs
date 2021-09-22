using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions.NodaTime.Specs.Extensions;

using NodaTime;

using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.NodaTime.Specs
{
    public static class OffsetTimeAssertionsSpecs
    {
        public class Be
        {
            [Fact]
            public void When_a_offset_time_is_equal_to_an_other_offset_time_it_succeeds()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));
                OffsetTime other = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_offset_time_is_equal_to_itself_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().Be(offsetTime);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                OffsetTime? offsetTime = default;
                OffsetTime? other = default;

                // Act
                Action act = () => offsetTime.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_fails()
            {
                // Arrange
                OffsetTime? offsetTime = default;
                OffsetTime other = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to be equal to {other}, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                OffsetTime? other = default;

                // Act
                Action act = () => offsetTime.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to be equal to <null>, but found {offsetTime}.");
            }
        }

        public class NotBe
        {
            [Fact]
            public void When_a_offset_time_is_equal_to_an_other_offset_time_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime other = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to be equal to {other}, but found {offsetTime}.");
            }

            [Fact]
            public void When_asserting_a_offset_time_is_not_equal_to_itself_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().NotBe(offsetTime);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to be equal to {offsetTime}, but found {offsetTime}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_null_it_fails()
            {
                // Arrange
                OffsetTime? offsetTime = default;
                OffsetTime? other = default;

                // Act
                Action act = () => offsetTime.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to be equal to <null>, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_not_null_it_succeeds()
            {
                // Arrange
                OffsetTime? offsetTime = default;
                OffsetTime other = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                OffsetTime? other = default;

                // Act
                Action act = () => offsetTime.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }
        }

        public class HaveClockHourOfHalfDay
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_clock_hour_of_half_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().HaveClockHourOfHalfDay(offsetTime.ClockHourOfHalfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                int time = offsetTime.With(time => time.PlusHours(1)).ClockHourOfHalfDay;

                // Act
                Action act = () => offsetTime.Should().HaveClockHourOfHalfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have clock hour of the half-day of {time}, but found {offsetTime.ClockHourOfHalfDay}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_has_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                int time = new Random().Next(12);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().HaveClockHourOfHalfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have clock hour of the half-day of {time}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class NotHaveClockHourOfHalfDay
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().NotHaveClockHourOfHalfDay(offsetTime.ClockHourOfHalfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have clock hour of the half-day of {offsetTime.ClockHourOfHalfDay}.");
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_clock_hour_of_half_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                int time = offsetTime.With(time => time.PlusHours(1)).ClockHourOfHalfDay;

                // Act
                Action act = () => offsetTime.Should().NotHaveClockHourOfHalfDay(time);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_does_not_have_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                int time = new Random().Next(12);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().NotHaveClockHourOfHalfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have clock hour of the half-day of {time}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class HaveHour
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_hour_of_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().HaveHour(offsetTime.Hour);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                int hourOfDay = offsetTime.With(time => time.PlusHours(1)).Hour;

                // Act
                Action act = () => offsetTime.Should().HaveHour(hourOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have hour of day {hourOfDay}, but found {offsetTime.Hour}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_has_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                int hourOfDay = new Random().Next(1, 23);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().HaveHour(hourOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have hour of day {hourOfDay}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class NotHaveHour
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().NotHaveHour(offsetTime.Hour);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have hour of day {offsetTime.Hour}.");
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_hour_of_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                int hourOfDay = offsetTime.With(time => time.PlusHours(1)).Hour;

                // Act
                Action act = () => offsetTime.Should().NotHaveHour(hourOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_does_not_have_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                int hourOfDay = new Random().Next(1, 23);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().NotHaveHour(hourOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have hour of day {hourOfDay}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class HaveMillisecond
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_millisecond_of_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().HaveMillisecond(offsetTime.Millisecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                int millisecondOfDay = offsetTime.With(time => time.PlusMilliseconds(1)).Millisecond;

                // Act
                Action act = () => offsetTime.Should().HaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have millisecond {millisecondOfDay}, but found {offsetTime.Millisecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_has_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                int millisecondOfDay = new Random().Next(1, 999);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().HaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have millisecond {millisecondOfDay}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class NotHaveMillisecond
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().NotHaveMillisecond(offsetTime.Millisecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have millisecond {offsetTime.Millisecond}.");
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_millisecond_of_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                int millisecondOfDay = offsetTime.With(time => time.PlusMilliseconds(1)).Millisecond;

                // Act
                Action act = () => offsetTime.Should().NotHaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_does_not_have_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                int millisecondOfDay = new Random().Next(1, 999);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().NotHaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have millisecond {millisecondOfDay}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class HaveMinute
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_minute_of_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().HaveMinute(offsetTime.Minute);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                int minuteOfDay = offsetTime.With(time => time.PlusMinutes(1)).Minute;

                // Act
                Action act = () => offsetTime.Should().HaveMinute(minuteOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have minute {minuteOfDay}, but found {offsetTime.Minute}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_has_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                int minuteOfDay = new Random().Next(1, 59);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().HaveMinute(minuteOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have minute {minuteOfDay}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class NotHaveMinute
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().NotHaveMinute(offsetTime.Minute);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have minute {offsetTime.Minute}.");
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_minute_of_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                int minuteOfDay = offsetTime.With(time => time.PlusMinutes(1)).Minute;

                // Act
                Action act = () => offsetTime.Should().NotHaveMinute(minuteOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_does_not_have_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                int minuteOfDay = new Random().Next(1, 59);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().NotHaveMinute(minuteOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have minute {minuteOfDay}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class HaveNanosecondOfDay
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_nanosecond_of_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().HaveNanosecondOfDay(offsetTime.NanosecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_nanosecond_of_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                long nanosecondOfDay = offsetTime.With(time => time.PlusNanoseconds(1)).NanosecondOfDay;

                // Act
                Action act = () => offsetTime.Should().HaveNanosecondOfDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have nanosecond of day {nanosecondOfDay.AsFormatted()}, but found {offsetTime.NanosecondOfDay.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_has_the_specified_nanosecond_of_day_it_fails()
            {
                // Arrange
                long nanosecondOfDay = new Random().Next(1, 999_999_999);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().HaveNanosecondOfDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have nanosecond of day {nanosecondOfDay.AsFormatted()}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class NotHaveNanosecondOfDay
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_nanosecond_of_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().NotHaveNanosecondOfDay(offsetTime.NanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have nanosecond of day {offsetTime.NanosecondOfDay.AsFormatted()}.");
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_nanosecond_of_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                long nanosecondOfDay = offsetTime.With(time => time.PlusNanoseconds(1)).NanosecondOfDay;

                // Act
                Action act = () => offsetTime.Should().NotHaveNanosecondOfDay(nanosecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_does_not_have_the_specified_nanosecond_of_day_it_fails()
            {
                // Arrange
                long nanosecondOfDay = new Random().Next(1, 999_999_999);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().NotHaveNanosecondOfDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have nanosecond of day {nanosecondOfDay.AsFormatted()}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class HaveNanosecondOfSecond
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_nanosecond_of_second_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().HaveNanosecondOfSecond(offsetTime.NanosecondOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_nanosecond_of_second_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                int nanosecondOfSecond = offsetTime.With(time => time.PlusNanoseconds(1)).NanosecondOfSecond;

                // Act
                Action act = () => offsetTime.Should().HaveNanosecondOfSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have nanosecond of second {nanosecondOfSecond}, but found {offsetTime.NanosecondOfSecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_has_the_specified_nanosecond_of_second_it_fails()
            {
                // Arrange
                int nanosecondOfSecond = new Random().Next(1, 999_999_999);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().HaveNanosecondOfSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have nanosecond of second {nanosecondOfSecond}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class NotHaveNanosecondOfSecond
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_nanosecond_of_second_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().NotHaveNanosecondOfSecond(offsetTime.NanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have nanosecond of second {offsetTime.NanosecondOfSecond}.");
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_nanosecond_of_second_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                int nanosecondOfSecond = offsetTime.With(time => time.PlusNanoseconds(1)).NanosecondOfSecond;

                // Act
                Action act = () => offsetTime.Should().NotHaveNanosecondOfSecond(nanosecondOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_does_not_have_the_specified_nanosecond_of_second_it_fails()
            {
                // Arrange
                int nanosecondOfSecond = new Random().Next(1, 999_999_999);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().NotHaveNanosecondOfSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have nanosecond of second {nanosecondOfSecond}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class HaveSecond
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_second_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().HaveSecond(offsetTime.Second);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_second_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                int second = offsetTime.With(time => time.PlusSeconds(1)).Second;

                // Act
                Action act = () => offsetTime.Should().HaveSecond(second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have second {second}, but found {offsetTime.Second}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_has_the_specified_second_it_fails()
            {
                // Arrange
                int second = new Random().Next(1, 59);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().HaveSecond(second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have second {second}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class NotHaveSecond
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_second_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().NotHaveSecond(offsetTime.Second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have second {offsetTime.Second}.");
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_second_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                int second = offsetTime.With(time => time.PlusSeconds(1)).Second;

                // Act
                Action act = () => offsetTime.Should().NotHaveSecond(second);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_does_not_have_the_specified_second_it_fails()
            {
                // Arrange
                int second = new Random().Next(1, 59);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().NotHaveSecond(second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have second {second}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class HaveTickOfDay
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_tick_of_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().HaveTickOfDay(offsetTime.TickOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_tick_of_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                long tickOfDay = offsetTime.With(time => time.PlusTicks(1)).TickOfDay;

                // Act
                Action act = () => offsetTime.Should().HaveTickOfDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have tick of day {tickOfDay.AsFormatted()}, but found {offsetTime.TickOfDay.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_has_the_specified_tick_of_day_it_fails()
            {
                // Arrange
                long tickOfDay = new Random().Next(1, 999_999_999);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().HaveTickOfDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have tick of day {tickOfDay.AsFormatted()}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class NotHaveTickOfDay
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_tick_of_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().NotHaveTickOfDay(offsetTime.TickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have tick of day {offsetTime.TickOfDay.AsFormatted()}.");
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_tick_of_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                long tickOfDay = offsetTime.With(time => time.PlusTicks(1)).TickOfDay;

                // Act
                Action act = () => offsetTime.Should().NotHaveTickOfDay(tickOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_does_not_have_the_specified_tick_of_day_it_fails()
            {
                // Arrange
                long tickOfDay = new Random().Next(1, 999_999_999);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().NotHaveTickOfDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have tick of day {tickOfDay.AsFormatted()}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class HaveTickOfSecond
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_tick_of_second_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().HaveTickOfSecond(offsetTime.TickOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                int tickOfSecond = offsetTime.With(time => time.PlusTicks(1)).TickOfSecond;

                // Act
                Action act = () => offsetTime.Should().HaveTickOfSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have tick of second {tickOfSecond}, but found {offsetTime.TickOfSecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_has_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                int tickOfSecond = new Random().Next(1, 9_999_999);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().HaveTickOfSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have tick of second {tickOfSecond}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class NotHaveTickOfSecond
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().NotHaveTickOfSecond(offsetTime.TickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have tick of second {offsetTime.TickOfSecond}.");
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_tick_of_second_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                int tickOfSecond = offsetTime.With(time => time.PlusTicks(1)).TickOfSecond;

                // Act
                Action act = () => offsetTime.Should().NotHaveTickOfSecond(tickOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_does_not_have_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                int tickOfSecond = new Random().Next(1, 9_999_999);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().NotHaveTickOfSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have tick of second {tickOfSecond}, but {nameof(offsetTime)} was <null>.");
            }
        }
    }
}
