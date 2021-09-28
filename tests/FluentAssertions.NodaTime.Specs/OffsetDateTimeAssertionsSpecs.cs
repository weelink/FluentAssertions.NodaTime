using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions.NodaTime.Specs.Extensions;

using NodaTime;
using NodaTime.Calendars;

using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.NodaTime.Specs
{
    public static class OffsetDateTimeAssertionsSpecs
    {
        private static CalendarSystem RandomCalendarSystem()
        {
            return CalendarSystem.ForId(CalendarSystem.Ids.Random());
        }

        private static (CalendarSystem first, CalendarSystem second) TwoRandomCalendarSystems()
        {
            CalendarSystem first = CalendarSystem.ForId(CalendarSystem.Ids.Random());
            CalendarSystem second = CalendarSystem.ForId(CalendarSystem.Ids.Except(first.Id).Random());
            return (first, second);
        }

        private static IsoDayOfWeek RandomDayOfWeek()
        {
            return (IsoDayOfWeek)new Random().Next(1, 7);
        }

        public class Be
        {
            [Fact]
            public void When_a_offset_date_time_is_equal_to_an_other_offset_date_time_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(now);
                OffsetDateTime other = OffsetDateTime.FromDateTimeOffset(now);

                // Act
                Action act = () => offsetDateTime.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_offset_date_time_is_equal_to_itself_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().Be(offsetDateTime);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                OffsetDateTime? offsetDateTime = default;
                OffsetDateTime? other = default;

                // Act
                Action act = () => offsetDateTime.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_fails()
            {
                // Arrange
                OffsetDateTime? offsetDateTime = default;
                OffsetDateTime other = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to be equal to {other}, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                OffsetDateTime? other = default;

                // Act
                Action act = () => offsetDateTime.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to be equal to <null>, but found {offsetDateTime}.");
            }
        }

        public class NotBe
        {
            [Fact]
            public void When_a_offset_date_time_is_equal_to_an_other_offset_date_time_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDateTime other = OffsetDateTime.FromDateTimeOffset(now);
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(now);

                // Act
                Action act = () => offsetDateTime.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to be equal to {other}, but found {offsetDateTime}.");
            }

            [Fact]
            public void When_asserting_a_offset_date_time_is_not_equal_to_itself_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(now);

                // Act
                Action act = () => offsetDateTime.Should().NotBe(offsetDateTime);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to be equal to {offsetDateTime}, but found {offsetDateTime}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_null_it_fails()
            {
                // Arrange
                OffsetDateTime? offsetDateTime = default;
                OffsetDateTime? other = default;

                // Act
                Action act = () => offsetDateTime.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to be equal to <null>, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_not_null_it_succeeds()
            {
                // Arrange
                OffsetDateTime? offsetDateTime = default;
                OffsetDateTime other = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                OffsetDateTime? other = default;

                // Act
                Action act = () => offsetDateTime.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }
        }


        public class BeInCalendar
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_calendar_it_succeeds()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);

                // Act
                Action act = () => offsetDateTime.Should().BeInCalendar(calendar);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_calendar()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);

                // Act
                CalendarSystem returned = offsetDateTime.Should().BeInCalendar(calendar).Which;

                // Assert
                returned.Should().Be(calendar);
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_calendar_it_fails()
            {
                // Arrange
                (CalendarSystem calendar, CalendarSystem other) = TwoRandomCalendarSystems();
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);

                // Act
                Action act = () => offsetDateTime.Should().BeInCalendar(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to be in calendar {other}, but found {calendar}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_a_calendar_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDateTime? offsetDateTime = default;

                // Act
                Action act = () => offsetDateTime.Should().BeInCalendar(calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to be in calendar {calendar}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotBeInCalendar
        {
            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_calendar_it_succeeds()
            {
                // Arrange
                (CalendarSystem calendar, CalendarSystem other) = TwoRandomCalendarSystems();
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);

                // Act
                Action act = () => offsetDateTime.Should().NotBeInCalendar(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_time_has_the_specified_calendar_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);

                // Act
                Action act = () => offsetDateTime.Should().NotBeInCalendar(calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to be in calendar {calendar}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_a_calendar_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDateTime? offsetDateTime = default;

                // Act
                Action act = () => offsetDateTime.Should().NotBeInCalendar(calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to be in calendar {calendar}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveDate
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_date_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                LocalDate date = offsetDateTime.Date;

                // Act
                Action act = () => offsetDateTime.Should().HaveDate(date);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_date()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                LocalDate date = offsetDateTime.Date;

                // Act
                LocalDate returned = offsetDateTime.Should().HaveDate(date).Which;

                // Assert
                returned.Should().Be(date);
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_date_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                LocalDate date = offsetDateTime.With(date => date.PlusDays(1)).Date;

                // Act
                Action act = () => offsetDateTime.Should().HaveDate(date);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have date {date}, but found {offsetDateTime.Date}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_date_it_fails()
            {
                // Arrange
                LocalDate date = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).Date;
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveDate(date);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have date {date}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveDate
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_date_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                LocalDate date = offsetDateTime.Date;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveDate(date);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have date {date}.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_date_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                LocalDate date = offsetDateTime.With(date => date.PlusDays(1)).Date;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveDate(date);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_date_it_fails()
            {
                // Arrange
                LocalDate date = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).Date;
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveDate(date);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have date {date}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveLocalDateTime
        {
            [Fact]
            public void When_a_offset_local_date_time_has_the_specified_local_date_time_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                LocalDateTime localDateTime = offsetDateTime.LocalDateTime;

                // Act
                Action act = () => offsetDateTime.Should().HaveLocalDateTime(localDateTime);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_date()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                LocalDateTime localDateTime = offsetDateTime.LocalDateTime;

                // Act
                LocalDateTime returned = offsetDateTime.Should().HaveLocalDateTime(localDateTime).Which;

                // Assert
                returned.Should().Be(localDateTime);
            }

            [Fact]
            public void When_a_offset_local_date_time_does_not_have_the_specified_local_date_time_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                LocalDateTime localDateTime = offsetDateTime.With(localDateTime => localDateTime.PlusDays(1)).LocalDateTime;

                // Act
                Action act = () => offsetDateTime.Should().HaveLocalDateTime(localDateTime);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have local date time {localDateTime}, but found {offsetDateTime.LocalDateTime}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_local_date_time_has_the_specified_local_date_time_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).LocalDateTime;
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveLocalDateTime(localDateTime);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have local date time {localDateTime}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveLocalDateTime
        {
            [Fact]
            public void When_a_offset_local_date_time_has_the_specified_local_date_time_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                LocalDateTime localDateTime = offsetDateTime.LocalDateTime;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveLocalDateTime(localDateTime);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have local date time {localDateTime}.");
            }

            [Fact]
            public void When_a_offset_local_date_time_does_not_have_the_specified_local_date_time_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                LocalDateTime localDateTime = offsetDateTime.With(localDateTime => localDateTime.PlusDays(1)).LocalDateTime;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveLocalDateTime(localDateTime);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_local_date_time_does_not_have_the_specified_local_date_time_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).LocalDateTime;
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveLocalDateTime(localDateTime);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have local date time {localDateTime}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveOffset
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_offset_it_succeeds()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                Offset offset = offsetDateTime.Offset;

                // Act
                Action act = () => offsetDateTime.Should().HaveOffset(offset);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_offset_date()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                Offset offset = offsetDateTime.Offset;

                // Act
                Offset returned = offsetDateTime.Should().HaveOffset(offset).Which;

                // Assert
                returned.Should().Be(offset);
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_offset_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                Offset offset = offsetDateTime.Offset.Plus(Offset.FromSeconds(1));

                // Act
                Action act = () => offsetDateTime.Should().HaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have offset {offset}, but found {offsetDateTime.Offset}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_offset_it_fails()
            {
                // Arrange
                Offset offset = Offset.FromSeconds(1);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have offset {offset}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveOffset
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_offset_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                Offset offset = offsetDateTime.Offset;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have offset {offset}.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_offset_it_succeeds()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                Offset offset = offsetDateTime.Offset.Plus(Offset.FromSeconds(1));

                // Act
                Action act = () => offsetDateTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_offset_it_fails()
            {
                // Arrange
                Offset offset = Offset.FromSeconds(1);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have offset {offset}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveOffsetTimeSpan
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_offset_it_succeeds()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                TimeSpan offset = offsetDateTime.Offset.ToTimeSpan();

                // Act
                Action act = () => offsetDateTime.Should().HaveOffset(offset);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_offset_date()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                TimeSpan offset = offsetDateTime.Offset.ToTimeSpan();

                // Act
                Offset returned = offsetDateTime.Should().HaveOffset(offset).Which;

                // Assert
                returned.Should().Be(offset);
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_offset_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                TimeSpan offset = offsetDateTime.Offset.Plus(Offset.FromSeconds(1)).ToTimeSpan();

                // Act
                Action act = () => offsetDateTime.Should().HaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have offset {Offset.FromTimeSpan(offset)}, but found {offsetDateTime.Offset}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_offset_it_fails()
            {
                // Arrange
                TimeSpan offset = TimeSpan.FromSeconds(1);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have offset {Offset.FromTimeSpan(offset)}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveOffsetTimeSpan
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_offset_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                TimeSpan offset = offsetDateTime.Offset.ToTimeSpan();

                // Act
                Action act = () => offsetDateTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have offset {Offset.FromTimeSpan(offset)}.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_offset_it_succeeds()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                TimeSpan offset = offsetDateTime.Offset.Plus(Offset.FromSeconds(1)).ToTimeSpan();

                // Act
                Action act = () => offsetDateTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_offset_it_fails()
            {
                // Arrange
                TimeSpan offset = TimeSpan.FromSeconds(1);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have offset {Offset.FromTimeSpan(offset)}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveTimeOfDay
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_time_of_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().HaveTimeOfDay(offsetDateTime.TimeOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_local_time()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                LocalTime returned = offsetDateTime.Should().HaveTimeOfDay(offsetDateTime.TimeOfDay).Which;

                // Assert
                returned.Should().Be(offsetDateTime.TimeOfDay);
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_time_of_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                LocalTime time = offsetDateTime.TimeOfDay + Period.FromSeconds(1);

                // Act
                Action act = () => offsetDateTime.Should().HaveTimeOfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have time of day {time}, but found {offsetDateTime.TimeOfDay}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_time_of_day_it_fails()
            {
                // Arrange
                LocalTime time = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).TimeOfDay;
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveTimeOfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have time of day {time}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveTimeOfDay
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_time_of_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveTimeOfDay(offsetDateTime.TimeOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have time of day {offsetDateTime.TimeOfDay}.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_time_of_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                LocalTime time = offsetDateTime.TimeOfDay + Period.FromSeconds(1);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveTimeOfDay(time);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_time_of_day_it_fails()
            {
                // Arrange
                LocalTime time = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).TimeOfDay;
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveTimeOfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have time of day {time}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveClockHourOfHalfDay
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_clock_hour_of_half_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().HaveClockHourOfHalfDay(offsetDateTime.ClockHourOfHalfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int time = offsetDateTime.PlusHours(1).ClockHourOfHalfDay;

                // Act
                Action act = () => offsetDateTime.Should().HaveClockHourOfHalfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have clock hour of the half-day of {time}, but found {offsetDateTime.ClockHourOfHalfDay}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                int time = new Random().Next(12);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveClockHourOfHalfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have clock hour of the half-day of {time}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveClockHourOfHalfDay
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveClockHourOfHalfDay(offsetDateTime.ClockHourOfHalfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have clock hour of the half-day of {offsetDateTime.ClockHourOfHalfDay}.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_clock_hour_of_half_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int time = offsetDateTime.PlusHours(1).ClockHourOfHalfDay;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveClockHourOfHalfDay(time);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                int time = new Random().Next(12);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveClockHourOfHalfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have clock hour of the half-day of {time}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveDay
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().HaveDay(offsetDateTime.Day);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int day = offsetDateTime.With(date => date.PlusDays(1)).Day;

                // Act
                Action act = () => offsetDateTime.Should().HaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have day {day}, but found {offsetDateTime.Day}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_day_it_fails()
            {
                // Arrange
                int day = new Random().Next(1, 28);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have day {day}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveDay
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveDay(offsetDateTime.Day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have day {offsetDateTime.Day}.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int day = offsetDateTime.With(date => date.PlusDays(1)).Day;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveDay(day);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_day_it_fails()
            {
                // Arrange
                int day = new Random().Next(1, 28);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have day {day}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveDayOfWeek
        {
            [Fact]
            public void When_a_offset_date_has_the_specified_day_of_week_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().HaveDayOfWeek(offsetDateTime.DayOfWeek);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_day_of_week_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                IsoDayOfWeek dayOfWeek = offsetDateTime.With(date => date.PlusDays(1)).DayOfWeek;

                // Act
                Action act = () => offsetDateTime.Should().HaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have day of week {dayOfWeek.AsFormatted()}, but found {offsetDateTime.DayOfWeek.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_has_the_specified_day_of_week_it_fails()
            {
                // Arrange
                IsoDayOfWeek dayOfWeek = RandomDayOfWeek();
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have day of week {dayOfWeek.AsFormatted()}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveDayOfWeek
        {
            [Fact]
            public void When_a_offset_date_has_the_specified_day_of_week_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveDayOfWeek(offsetDateTime.DayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have day of week {offsetDateTime.DayOfWeek.AsFormatted()}.");
            }

            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_day_of_week_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                IsoDayOfWeek dayOfWeek = offsetDateTime.With(date => date.PlusDays(1)).DayOfWeek;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_does_not_have_the_specified_day_of_week_it_fails()
            {
                // Arrange
                IsoDayOfWeek dayOfWeek = RandomDayOfWeek();
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have day of week {dayOfWeek.AsFormatted()}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveDayOfYear
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_day_of_year_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().HaveDayOfYear(offsetDateTime.DayOfYear);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_day_of_year_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int dayOfYear = offsetDateTime.With(date => date.PlusDays(1)).DayOfYear;

                // Act
                Action act = () => offsetDateTime.Should().HaveDayOfYear(dayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have day of year {dayOfYear}, but found {offsetDateTime.DayOfYear}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_day_of_year_it_fails()
            {
                // Arrange
                int dayOfYear = new Random().Next(1, 365);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveDayOfYear(dayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have day of year {dayOfYear}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveDayOfYear
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_day_of_year_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveDayOfYear(offsetDateTime.DayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have day of year {offsetDateTime.DayOfYear}.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_day_of_year_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int dayOfYear = offsetDateTime.With(date => date.PlusDays(1)).DayOfYear;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveDayOfYear(dayOfYear);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_day_of_year_it_fails()
            {
                // Arrange
                int dayOfYear = new Random().Next(1, 365);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveDayOfYear(dayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have day of year {dayOfYear}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveHour
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_hour_of_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().HaveHour(offsetDateTime.Hour);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int hourOfDay = offsetDateTime.PlusHours(1).Hour;

                // Act
                Action act = () => offsetDateTime.Should().HaveHour(hourOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have hour of day {hourOfDay}, but found {offsetDateTime.Hour}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                int hourOfDay = new Random().Next(1, 23);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveHour(hourOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have hour of day {hourOfDay}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveHour
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveHour(offsetDateTime.Hour);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have hour of day {offsetDateTime.Hour}.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_hour_of_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int hourOfDay = offsetDateTime.PlusHours(1).Hour;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveHour(hourOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                int hourOfDay = new Random().Next(1, 23);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveHour(hourOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have hour of day {hourOfDay}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveEra
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_era_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().HaveEra(offsetDateTime.Era);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_era_it_fails()
            {
                // Arrange
                OffsetDateTime ad = new OffsetDate(new LocalDate(Era.Common, 1966, 9, 8, CalendarSystem.Iso), Offset.Zero).At(LocalTime.Midnight);
                OffsetDateTime bc = new OffsetDate(new LocalDate(Era.BeforeCommon, 384, 4, 16, CalendarSystem.Iso), Offset.Zero).At(LocalTime.Midnight);

                // Act
                Action act = () => ad.Should().HaveEra(bc.Era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(ad)} to have era {bc.Era}, but found {ad.Era}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_era_it_fails()
            {
                // Arrange
                Era era = Era.Common;
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveEra(era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have era {era}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveEra
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_era_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveEra(offsetDateTime.Era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have era {offsetDateTime.Era}.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_era_it_succeeds()
            {
                // Arrange
                OffsetDateTime ad = new OffsetDate(new LocalDate(Era.Common, 1966, 9, 8, CalendarSystem.Iso), Offset.Zero).At(LocalTime.Midnight);
                OffsetDateTime bc = new OffsetDate(new LocalDate(Era.BeforeCommon, 384, 4, 16, CalendarSystem.Iso), Offset.Zero).At(LocalTime.Midnight);

                // Act
                Action act = () => ad.Should().NotHaveEra(bc.Era);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_era_it_fails()
            {
                // Arrange
                Era era = Era.Common;
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveEra(era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have era {era}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveMillisecond
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_millisecond_of_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().HaveMillisecond(offsetDateTime.Millisecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int millisecondOfDay = offsetDateTime.PlusMilliseconds(1).Millisecond;

                // Act
                Action act = () => offsetDateTime.Should().HaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have millisecond {millisecondOfDay}, but found {offsetDateTime.Millisecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                int millisecondOfDay = new Random().Next(1, 999);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have millisecond {millisecondOfDay}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveMillisecond
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveMillisecond(offsetDateTime.Millisecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have millisecond {offsetDateTime.Millisecond}.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_millisecond_of_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int millisecondOfDay = offsetDateTime.PlusMilliseconds(1).Millisecond;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                int millisecondOfDay = new Random().Next(1, 999);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have millisecond {millisecondOfDay}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveMinute
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_minute_of_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().HaveMinute(offsetDateTime.Minute);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int minuteOfDay = offsetDateTime.PlusMinutes(1).Minute;

                // Act
                Action act = () => offsetDateTime.Should().HaveMinute(minuteOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have minute {minuteOfDay}, but found {offsetDateTime.Minute}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                int minuteOfDay = new Random().Next(1, 59);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveMinute(minuteOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have minute {minuteOfDay}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveMinute
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveMinute(offsetDateTime.Minute);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have minute {offsetDateTime.Minute}.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_minute_of_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int minuteOfDay = offsetDateTime.PlusMinutes(1).Minute;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveMinute(minuteOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                int minuteOfDay = new Random().Next(1, 59);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveMinute(minuteOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have minute {minuteOfDay}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveMonth
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_month_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().HaveMonth(offsetDateTime.Month);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_month_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int month = offsetDateTime.With(date => date.PlusMonths(1)).Month;

                // Act
                Action act = () => offsetDateTime.Should().HaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have month {month}, but found {offsetDateTime.Month}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_month_it_fails()
            {
                // Arrange
                int month = new Random().Next(1, 12);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have month {month}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveMonth
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_month_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveMonth(offsetDateTime.Month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have month {offsetDateTime.Month}.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_month_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int month = offsetDateTime.With(date => date.PlusMonths(1)).Month;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveMonth(month);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_month_it_fails()
            {
                // Arrange
                int month = new Random().Next(1, 12);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have month {month}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveNanosecondsWithinDay
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_nanoseconds_within_the_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().HaveNanosecondsWithinDay(offsetDateTime.NanosecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                long nanosecondOfDay = offsetDateTime.PlusNanoseconds(1).NanosecondOfDay;

                // Act
                Action act = () => offsetDateTime.Should().HaveNanosecondsWithinDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have {nanosecondOfDay.AsFormatted()} nanoseconds within the day, but found {offsetDateTime.NanosecondOfDay.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                long nanosecondOfDay = new Random().Next(1, 999_999_999);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveNanosecondsWithinDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have {nanosecondOfDay.AsFormatted()} nanoseconds within the day, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveNanosecondsWithinDay
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveNanosecondsWithinDay(offsetDateTime.NanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have {offsetDateTime.NanosecondOfDay.AsFormatted()} nanoseconds within the day.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_nanoseconds_within_the_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                long nanosecondOfDay = offsetDateTime.PlusNanoseconds(1).NanosecondOfDay;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveNanosecondsWithinDay(nanosecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                long nanosecondOfDay = new Random().Next(1, 999_999_999);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveNanosecondsWithinDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have {nanosecondOfDay.AsFormatted()} nanoseconds within the day, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveNanosecondsWithinSecond
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_nanoseconds_within_the_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().HaveNanosecondsWithinSecond(offsetDateTime.NanosecondOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int nanosecondOfSecond = offsetDateTime.PlusNanoseconds(1).NanosecondOfSecond;

                // Act
                Action act = () => offsetDateTime.Should().HaveNanosecondsWithinSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have {nanosecondOfSecond} nanoseconds within the second, but found {offsetDateTime.NanosecondOfSecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                int nanosecondOfSecond = new Random().Next(1, 999_999_999);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveNanosecondsWithinSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have {nanosecondOfSecond} nanoseconds within the second, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveNanosecondsWithinSecond
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveNanosecondsWithinSecond(offsetDateTime.NanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have {offsetDateTime.NanosecondOfSecond} nanoseconds within the second.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_nanoseconds_within_the_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int nanosecondOfSecond = offsetDateTime.PlusNanoseconds(1).NanosecondOfSecond;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveNanosecondsWithinSecond(nanosecondOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                int nanosecondOfSecond = new Random().Next(1, 999_999_999);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveNanosecondsWithinSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have {nanosecondOfSecond} nanoseconds within the second, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveSecond
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_second_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().HaveSecond(offsetDateTime.Second);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_second_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int second = offsetDateTime.PlusSeconds(1).Second;

                // Act
                Action act = () => offsetDateTime.Should().HaveSecond(second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have second {second}, but found {offsetDateTime.Second}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_second_it_fails()
            {
                // Arrange
                int second = new Random().Next(1, 59);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveSecond(second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have second {second}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveSecond
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_second_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveSecond(offsetDateTime.Second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have second {offsetDateTime.Second}.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_second_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int second = offsetDateTime.PlusSeconds(1).Second;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveSecond(second);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_second_it_fails()
            {
                // Arrange
                int second = new Random().Next(1, 59);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveSecond(second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have second {second}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveYear
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_year_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().HaveYear(offsetDateTime.Year);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_year_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int year = offsetDateTime.With(date => date.PlusYears(1)).Year;

                // Act
                Action act = () => offsetDateTime.Should().HaveYear(year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have year {year}, but found {offsetDateTime.Year}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_year_it_fails()
            {
                // Arrange
                int year = new Random().Next(2001, 2020);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveYear(year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have year {year}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveYear
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_year_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveYear(offsetDateTime.Year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have year {offsetDateTime.Year}.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_year_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int year = offsetDateTime.With(date => date.PlusYears(1)).Year;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveYear(year);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_year_it_fails()
            {
                // Arrange
                int year = new Random().Next(2001, 2020);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveYear(year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have year {year}, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveTicksWithinDay
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_ticks_within_the_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().HaveTicksWithinDay(offsetDateTime.TickOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_ticks_within_the_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                long tickOfDay = offsetDateTime.PlusTicks(1).TickOfDay;

                // Act
                Action act = () => offsetDateTime.Should().HaveTicksWithinDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have {tickOfDay.AsFormatted()} ticks within the day, but found {offsetDateTime.TickOfDay.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_ticks_within_the_day_it_fails()
            {
                // Arrange
                long tickOfDay = new Random().Next(1, 999_999_999);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveTicksWithinDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have {tickOfDay.AsFormatted()} ticks within the day, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveTicksWithinDay
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_ticks_within_the_day_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveTicksWithinDay(offsetDateTime.TickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have {offsetDateTime.TickOfDay.AsFormatted()} ticks within the day.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_ticks_within_the_day_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                long tickOfDay = offsetDateTime.PlusTicks(1).TickOfDay;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveTicksWithinDay(tickOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_ticks_within_the_day_it_fails()
            {
                // Arrange
                long tickOfDay = new Random().Next(1, 999_999_999);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveTicksWithinDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have {tickOfDay.AsFormatted()} ticks within the day, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveTicksWithinSecond
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_tick_of_second_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().HaveTicksWithinSecond(offsetDateTime.TickOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int tickOfSecond = offsetDateTime.PlusTicks(1).TickOfSecond;

                // Act
                Action act = () => offsetDateTime.Should().HaveTicksWithinSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have {tickOfSecond} ticks within the second, but found {offsetDateTime.TickOfSecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                int tickOfSecond = new Random().Next(1, 9_999_999);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveTicksWithinSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have {tickOfSecond} ticks within the second, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveTicksWithinSecond
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveTicksWithinSecond(offsetDateTime.TickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have {offsetDateTime.TickOfSecond} ticks within the second.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_tick_of_second_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int tickOfSecond = offsetDateTime.PlusTicks(1).TickOfSecond;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveTicksWithinSecond(tickOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                int tickOfSecond = new Random().Next(1, 9_999_999);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveTicksWithinSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have {tickOfSecond} ticks within the second, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class HaveYearWithinEra
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_as_the_year_within_the_era_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().HaveYearWithinEra(offsetDateTime.YearOfEra);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_as_the_year_within_the_era_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int yearOfEra = offsetDateTime.With(date => date.PlusYears(1)).YearOfEra;

                // Act
                Action act = () => offsetDateTime.Should().HaveYearWithinEra(yearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have {yearOfEra} as the year within the era, but found {offsetDateTime.YearOfEra}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_has_the_specified_as_the_year_within_the_era_it_fails()
            {
                // Arrange
                int yearOfEra = new Random().Next(1, 100);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().HaveYearWithinEra(yearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDateTime)} to have {yearOfEra} as the year within the era, but {nameof(offsetDateTime)} was <null>.");
            }
        }

        public class NotHaveYearWithinEra
        {
            [Fact]
            public void When_a_offset_date_time_has_the_specified_as_the_year_within_the_era_it_fails()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);

                // Act
                Action act = () => offsetDateTime.Should().NotHaveYearWithinEra(offsetDateTime.YearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have {offsetDateTime.YearOfEra} as the year within the era.");
            }

            [Fact]
            public void When_a_offset_date_time_does_not_have_the_specified_as_the_year_within_the_era_it_succeeds()
            {
                // Arrange
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                int yearOfEra = offsetDateTime.With(date => date.PlusYears(1)).YearOfEra;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveYearWithinEra(yearOfEra);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_time_does_not_have_the_specified_as_the_year_within_the_era_it_fails()
            {
                // Arrange
                int yearOfEra = new Random().Next(1, 100);
                OffsetDateTime? offsetDateTime = null;

                // Act
                Action act = () => offsetDateTime.Should().NotHaveYearWithinEra(yearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDateTime)} to have {yearOfEra} as the year within the era, but {nameof(offsetDateTime)} was <null>.");
            }
        }
    }
}
