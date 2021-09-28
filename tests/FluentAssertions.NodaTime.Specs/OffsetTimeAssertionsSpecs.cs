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

        public class HaveOffset
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_offset_it_succeeds()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));
                Offset offset = offsetTime.Offset;

                // Act
                Action act = () => offsetTime.Should().HaveOffset(offset);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_offset_date()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));
                Offset offset = offsetTime.Offset;

                // Act
                Offset returned = offsetTime.Should().HaveOffset(offset).Which;

                // Assert
                returned.Should().Be(offset);
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_offset_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));
                Offset offset = offsetTime.Offset.Plus(Offset.FromSeconds(1));

                // Act
                Action act = () => offsetTime.Should().HaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have offset {offset}, but found {offsetTime.Offset}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_has_the_specified_offset_it_fails()
            {
                // Arrange
                Offset offset = Offset.FromSeconds(1);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().HaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have offset {offset}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class NotHaveOffset
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_offset_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));
                Offset offset = offsetTime.Offset;

                // Act
                Action act = () => offsetTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have offset {offset}.");
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_offset_it_succeeds()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));
                Offset offset = offsetTime.Offset.Plus(Offset.FromSeconds(1));

                // Act
                Action act = () => offsetTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_does_not_have_the_specified_offset_it_fails()
            {
                // Arrange
                Offset offset = Offset.FromSeconds(1);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have offset {offset}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class HaveOffsetTimeSpan
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_offset_it_succeeds()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));
                TimeSpan offset = offsetTime.Offset.ToTimeSpan();

                // Act
                Action act = () => offsetTime.Should().HaveOffset(offset);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_offset_date()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));
                TimeSpan offset = offsetTime.Offset.ToTimeSpan();

                // Act
                Offset returned = offsetTime.Should().HaveOffset(offset).Which;

                // Assert
                returned.Should().Be(offset);
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_offset_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));
                TimeSpan offset = offsetTime.Offset.Plus(Offset.FromSeconds(1)).ToTimeSpan();

                // Act
                Action act = () => offsetTime.Should().HaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have offset {Offset.FromTimeSpan(offset)}, but found {offsetTime.Offset}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_has_the_specified_offset_it_fails()
            {
                // Arrange
                TimeSpan offset = TimeSpan.FromSeconds(1);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().HaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have offset {Offset.FromTimeSpan(offset)}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class NotHaveOffsetTimeSpan
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_offset_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));
                TimeSpan offset = offsetTime.Offset.ToTimeSpan();

                // Act
                Action act = () => offsetTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have offset {Offset.FromTimeSpan(offset)}.");
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_offset_it_succeeds()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));
                TimeSpan offset = offsetTime.Offset.Plus(Offset.FromSeconds(1)).ToTimeSpan();

                // Act
                Action act = () => offsetTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_does_not_have_the_specified_offset_it_fails()
            {
                // Arrange
                TimeSpan offset = TimeSpan.FromSeconds(1);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have offset {Offset.FromTimeSpan(offset)}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class HaveTimeOfDay
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_time_of_day_it_succeeds()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().HaveTimeOfDay(offsetTime.TimeOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_local_time()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));

                // Act
                LocalTime returned = offsetTime.Should().HaveTimeOfDay(offsetTime.TimeOfDay).Which;

                // Assert
                returned.Should().Be(offsetTime.TimeOfDay);
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_time_of_day_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));
                LocalTime time = offsetTime.TimeOfDay + Period.FromSeconds(1);

                // Act
                Action act = () => offsetTime.Should().HaveTimeOfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have time of day {time}, but found {offsetTime.TimeOfDay}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_has_the_specified_time_of_day_it_fails()
            {
                // Arrange
                LocalTime time = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().HaveTimeOfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have time of day {time}, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class NotHaveTimeOfDay
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_time_of_day_it_fails()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().NotHaveTimeOfDay(offsetTime.TimeOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have time of day {offsetTime.TimeOfDay}.");
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_time_of_day_it_succeeds()
            {
                // Arrange
                long now = DateTime.Now.TimeOfDay.Ticks;
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(now).WithOffset(Offset.FromHours(2));
                LocalTime time = offsetTime.TimeOfDay + Period.FromSeconds(1);

                // Act
                Action act = () => offsetTime.Should().NotHaveTimeOfDay(time);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_does_not_have_the_specified_time_of_day_it_fails()
            {
                // Arrange
                LocalTime time = LocalTime.Midnight;
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().NotHaveTimeOfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have time of day {time}, but {nameof(offsetTime)} was <null>.");
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

        public class HaveNanosecondsWithinDay
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_nanoseconds_within_the_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().HaveNanosecondsWithinDay(offsetTime.NanosecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                long nanosecondOfDay = offsetTime.With(time => time.PlusNanoseconds(1)).NanosecondOfDay;

                // Act
                Action act = () => offsetTime.Should().HaveNanosecondsWithinDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have {nanosecondOfDay.AsFormatted()} nanoseconds within the day, but found {offsetTime.NanosecondOfDay.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_has_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                long nanosecondOfDay = new Random().Next(1, 999_999_999);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().HaveNanosecondsWithinDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have {nanosecondOfDay.AsFormatted()} nanoseconds within the day, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class NotHaveNanosecondsWithinDay
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().NotHaveNanosecondsWithinDay(offsetTime.NanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have {offsetTime.NanosecondOfDay.AsFormatted()} nanoseconds within the day.");
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_nanoseconds_within_the_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                long nanosecondOfDay = offsetTime.With(time => time.PlusNanoseconds(1)).NanosecondOfDay;

                // Act
                Action act = () => offsetTime.Should().NotHaveNanosecondsWithinDay(nanosecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_does_not_have_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                long nanosecondOfDay = new Random().Next(1, 999_999_999);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().NotHaveNanosecondsWithinDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have {nanosecondOfDay.AsFormatted()} nanoseconds within the day, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class HaveNanosecondsWithinSecond
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_nanoseconds_within_the_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().HaveNanosecondsWithinSecond(offsetTime.NanosecondOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                int nanosecondOfSecond = offsetTime.With(time => time.PlusNanoseconds(1)).NanosecondOfSecond;

                // Act
                Action act = () => offsetTime.Should().HaveNanosecondsWithinSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have {nanosecondOfSecond} nanoseconds within the second, but found {offsetTime.NanosecondOfSecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_has_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                int nanosecondOfSecond = new Random().Next(1, 999_999_999);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().HaveNanosecondsWithinSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have {nanosecondOfSecond} nanoseconds within the second, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class NotHaveNanosecondsWithinSecond
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().NotHaveNanosecondsWithinSecond(offsetTime.NanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have {offsetTime.NanosecondOfSecond} nanoseconds within the second.");
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_nanoseconds_within_the_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                int nanosecondOfSecond = offsetTime.With(time => time.PlusNanoseconds(1)).NanosecondOfSecond;

                // Act
                Action act = () => offsetTime.Should().NotHaveNanosecondsWithinSecond(nanosecondOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_does_not_have_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                int nanosecondOfSecond = new Random().Next(1, 999_999_999);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().NotHaveNanosecondsWithinSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have {nanosecondOfSecond} nanoseconds within the second, but {nameof(offsetTime)} was <null>.");
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

        public class HaveTicksWithinDay
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_ticks_within_the_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().HaveTicksWithinDay(offsetTime.TickOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_ticks_within_the_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                long tickOfDay = offsetTime.With(time => time.PlusTicks(1)).TickOfDay;

                // Act
                Action act = () => offsetTime.Should().HaveTicksWithinDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have {tickOfDay.AsFormatted()} ticks within the day, but found {offsetTime.TickOfDay.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_has_the_specified_ticks_within_the_day_it_fails()
            {
                // Arrange
                long tickOfDay = new Random().Next(1, 999_999_999);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().HaveTicksWithinDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have {tickOfDay.AsFormatted()} ticks within the day, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class NotHaveTicksWithinDay
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_ticks_within_the_day_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().NotHaveTicksWithinDay(offsetTime.TickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have {offsetTime.TickOfDay.AsFormatted()} ticks within the day.");
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_ticks_within_the_day_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                long tickOfDay = offsetTime.With(time => time.PlusTicks(1)).TickOfDay;

                // Act
                Action act = () => offsetTime.Should().NotHaveTicksWithinDay(tickOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_does_not_have_the_specified_ticks_within_the_day_it_fails()
            {
                // Arrange
                long tickOfDay = new Random().Next(1, 999_999_999);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().NotHaveTicksWithinDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have {tickOfDay.AsFormatted()} ticks within the day, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class HaveTicksWithinSecond
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_tick_of_second_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().HaveTicksWithinSecond(offsetTime.TickOfSecond);

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
                Action act = () => offsetTime.Should().HaveTicksWithinSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have {tickOfSecond} ticks within the second, but found {offsetTime.TickOfSecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_time_has_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                int tickOfSecond = new Random().Next(1, 9_999_999);
                OffsetTime? offsetTime = null;

                // Act
                Action act = () => offsetTime.Should().HaveTicksWithinSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetTime)} to have {tickOfSecond} ticks within the second, but {nameof(offsetTime)} was <null>.");
            }
        }

        public class NotHaveTicksWithinSecond
        {
            [Fact]
            public void When_a_offset_time_has_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));

                // Act
                Action act = () => offsetTime.Should().NotHaveTicksWithinSecond(offsetTime.TickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have {offsetTime.TickOfSecond} ticks within the second.");
            }

            [Fact]
            public void When_a_offset_time_does_not_have_the_specified_tick_of_second_it_succeeds()
            {
                // Arrange
                OffsetTime offsetTime = LocalTime.FromTicksSinceMidnight(DateTime.Now.TimeOfDay.Ticks).WithOffset(Offset.FromHours(2));
                int tickOfSecond = offsetTime.With(time => time.PlusTicks(1)).TickOfSecond;

                // Act
                Action act = () => offsetTime.Should().NotHaveTicksWithinSecond(tickOfSecond);

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
                Action act = () => offsetTime.Should().NotHaveTicksWithinSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetTime)} to have {tickOfSecond} ticks within the second, but {nameof(offsetTime)} was <null>.");
            }
        }
    }
}
