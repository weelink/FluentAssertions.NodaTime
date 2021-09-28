using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions.NodaTime.Specs.Extensions;

using NodaTime;
using NodaTime.Calendars;

using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.NodaTime.Specs
{
    public static class LocalDateTimeAssertionsSpecs
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
            public void When_a_local_date_time_is_equal_to_an_other_local_date_time_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(now, RandomCalendarSystem());
                LocalDateTime other = LocalDateTime.FromDateTime(now, localDateTime.Calendar);

                // Act
                Action act = () => localDateTime.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_local_date_time_is_equal_to_itself_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().Be(localDateTime);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                LocalDateTime? localDateTime = default;
                LocalDateTime? other = default;

                // Act
                Action act = () => localDateTime.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_fails()
            {
                // Arrange
                LocalDateTime? localDateTime = default;
                LocalDateTime other = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be equal to {other}, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDateTime? other = default;

                // Act
                Action act = () => localDateTime.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be equal to <null>, but found {localDateTime}.");
            }
        }

        public class BeDateTime
        {
            [Fact]
            public void When_a_local_date_time_is_equal_to_the_same_datetime_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(now);

                // Act
                Action act = () => localDateTime.Should().Be(now);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_is_not_equal_to_a_datetime_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(now);
                DateTime other = now.AddDays(1);

                // Act
                Action act = () => localDateTime.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be equal to {LocalDateTime.FromDateTime(other)}, but found {localDateTime}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                LocalDateTime? localDateTime = default;
                DateTime? other = default;

                // Act
                Action act = () => localDateTime.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_fails()
            {
                // Arrange
                LocalDateTime? localDateTime = default;
                DateTime other = DateTime.Now;

                // Act
                Action act = () => localDateTime.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be equal to {LocalDateTime.FromDateTime(other)}, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                DateTime? other = default;

                // Act
                Action act = () => localDateTime.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be equal to <null>, but found {localDateTime}.");
            }
        }

        public class BeDateTimeAndCalendar
        {
            [Fact]
            public void When_a_local_date_time_is_equal_to_the_same_datetime_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(now, calendar);

                // Act
                Action act = () => localDateTime.Should().Be(now, calendar);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_is_not_equal_to_a_datetime_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(now);
                DateTime other = now.AddDays(1);

                // Act
                Action act = () => localDateTime.Should().Be(other, calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be equal to {LocalDateTime.FromDateTime(other, calendar)}, but found {localDateTime}.");
            }

            [Fact]
            public void When_a_local_date_time_is_not_equal_to_a_datetime_because_of_a_different_calendar_system_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                (CalendarSystem calendar, CalendarSystem otherCalendar) = TwoRandomCalendarSystems();
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(now, calendar);
                DateTime other = now.AddDays(1);

                // Act
                Action act = () => localDateTime.Should().Be(other, otherCalendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be equal to {LocalDateTime.FromDateTime(other, otherCalendar)}, but found {localDateTime}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                LocalDateTime? localDateTime = default;
                DateTime? other = default;

                // Act
                Action act = () => localDateTime.Should().Be(other, RandomCalendarSystem());

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_fails()
            {
                // Arrange
                LocalDateTime? localDateTime = default;
                DateTime other = DateTime.Now;
                CalendarSystem calendar = RandomCalendarSystem();

                // Act
                Action act = () => localDateTime.Should().Be(other, calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be equal to {LocalDateTime.FromDateTime(other, calendar)}, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                DateTime? other = default;

                // Act
                Action act = () => localDateTime.Should().Be(other, RandomCalendarSystem());

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be equal to <null>, but found {localDateTime}.");
            }
        }

        public class NotBe
        {
            [Fact]
            public void When_a_local_date_time_is_equal_to_an_other_local_date_time_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDateTime other = LocalDateTime.FromDateTime(now, RandomCalendarSystem());
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(now, other.Calendar);

                // Act
                Action act = () => localDateTime.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to be equal to {other}.");
            }

            [Fact]
            public void When_asserting_a_local_date_time_is_not_equal_to_itself_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotBe(localDateTime);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to be equal to {localDateTime}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_null_it_fails()
            {
                // Arrange
                LocalDateTime? localDateTime = default;
                LocalDateTime? other = default;

                // Act
                Action act = () => localDateTime.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to be equal to <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_not_null_it_succeeds()
            {
                // Arrange
                LocalDateTime? localDateTime = default;
                LocalDateTime other = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDateTime? other = default;

                // Act
                Action act = () => localDateTime.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }
        }

        public class NotBeDateTime
        {
            [Fact]
            public void When_a_local_date_time_is_not_equal_to_the_same_datetime_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(now);

                // Act
                Action act = () => localDateTime.Should().NotBe(now);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to be equal to {localDateTime}.");
            }

            [Fact]
            public void When_a_local_date_time_is_not_equal_to_a_datetime_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(now);
                DateTime other = now.AddDays(1);

                // Act
                Action act = () => localDateTime.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to not be null for the test.")]
            public void When_asserting_null_is_not_equal_to_null_it_fails()
            {
                // Arrange
                LocalDateTime? localDateTime = default;
                DateTime? other = default;

                // Act
                Action act = () => localDateTime.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to be equal to <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to not be null for the test.")]
            public void When_asserting_null_is_not_equal_to_not_null_it_succeeds()
            {
                // Arrange
                LocalDateTime? localDateTime = default;
                DateTime other = DateTime.Now;

                // Act
                Action act = () => localDateTime.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to not be null for the test.")]
            public void When_asserting_not_null_is_not_equal_to_null_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                DateTime? other = default;

                // Act
                Action act = () => localDateTime.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }
        }

        public class NotBeDateTimeAndCalendar
        {
            [Fact]
            public void When_a_local_date_time_is_equal_to_the_same_datetime_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(now, calendar);

                // Act
                Action act = () => localDateTime.Should().NotBe(now, calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to be equal to {localDateTime}.");
            }

            [Fact]
            public void When_a_local_date_time_is_not_equal_to_a_datetime_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(now);
                DateTime other = now.AddDays(1);

                // Act
                Action act = () => localDateTime.Should().NotBe(other, calendar);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_is_not_equal_to_a_datetime_because_of_a_different_calendar_system_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                (CalendarSystem calendar, CalendarSystem otherCalendar) = TwoRandomCalendarSystems();
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(now, calendar);
                DateTime other = now.AddDays(1);

                // Act
                Action act = () => localDateTime.Should().NotBe(other, otherCalendar);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to not be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_fails()
            {
                // Arrange
                LocalDateTime? localDateTime = default;
                DateTime? other = default;

                // Act
                Action act = () => localDateTime.Should().NotBe(other, RandomCalendarSystem());

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to be equal to <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to not be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_succeeds()
            {
                // Arrange
                LocalDateTime? localDateTime = default;
                DateTime other = DateTime.Now;
                CalendarSystem calendar = RandomCalendarSystem();

                // Act
                Action act = () => localDateTime.Should().NotBe(other, calendar);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to not be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                DateTime? other = default;

                // Act
                Action act = () => localDateTime.Should().NotBe(other, RandomCalendarSystem());

                // Assert
                act.Should().NotThrow();
            }
        }

        public class BeInCalendar
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_calendar_it_succeeds()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, calendar);

                // Act
                Action act = () => localDateTime.Should().BeInCalendar(calendar);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_calendar()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, calendar);

                // Act
                CalendarSystem returned = localDateTime.Should().BeInCalendar(calendar).Which;

                // Assert
                returned.Should().Be(calendar);
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_calendar_it_fails()
            {
                // Arrange
                (CalendarSystem calendar, CalendarSystem other) = TwoRandomCalendarSystems();
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, calendar);

                // Act
                Action act = () => localDateTime.Should().BeInCalendar(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be in calendar {other}, but found {calendar}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_a_calendar_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDateTime? localDateTime = default;

                // Act
                Action act = () => localDateTime.Should().BeInCalendar(calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be in calendar {calendar}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotBeInCalendar
        {
            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_calendar_it_succeeds()
            {
                // Arrange
                (CalendarSystem calendar, CalendarSystem other) = TwoRandomCalendarSystems();
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, calendar);

                // Act
                Action act = () => localDateTime.Should().NotBeInCalendar(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_has_the_specified_calendar_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, calendar);

                // Act
                Action act = () => localDateTime.Should().NotBeInCalendar(calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to be in calendar {calendar}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_a_calendar_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDateTime? localDateTime = default;

                // Act
                Action act = () => localDateTime.Should().NotBeInCalendar(calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to be in calendar {calendar}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveDate
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_date_it_succeeds()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDate date = LocalDate.FromDateTime(DateTime.Today, calendar);
                LocalDateTime localDateTime = date.AtMidnight();

                // Act
                Action act = () => localDateTime.Should().HaveDate(date);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_local_date()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDate date = LocalDate.FromDateTime(DateTime.Today, calendar);
                LocalDateTime localDateTime = date.AtMidnight();

                // Act
                LocalDate returned = localDateTime.Should().HaveDate(date).Which;

                // Assert
                returned.Should().Be(date);
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_date_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDate date = LocalDate.FromDateTime(DateTime.Today, calendar);
                LocalDateTime localDateTime = (date + Period.FromDays(1)).AtMidnight();

                // Act
                Action act = () => localDateTime.Should().HaveDate(date);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have date {date}, but found {localDateTime.Date}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_date_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDate date = LocalDate.FromDateTime(DateTime.Today, calendar);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveDate(date);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have date {date}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveDate
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_date_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDate date = LocalDate.FromDateTime(DateTime.Today, calendar);
                LocalDateTime localDateTime = date.AtMidnight();

                // Act
                Action act = () => localDateTime.Should().NotHaveDate(date);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have date {date}.");
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_date_it_succeeds()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDate date = LocalDate.FromDateTime(DateTime.Today, calendar);
                LocalDateTime localDateTime = (date + Period.FromDays(1)).AtMidnight();

                // Act
                Action act = () => localDateTime.Should().NotHaveDate(date);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_date_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDate date = LocalDate.FromDateTime(DateTime.Today, calendar);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveDate(date);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have date {date}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveTimeOfDay
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_time_of_day_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().HaveTimeOfDay(localDateTime.TimeOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_local_time()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                LocalTime returned = localDateTime.Should().HaveTimeOfDay(localDateTime.TimeOfDay).Which;

                // Assert
                returned.Should().Be(localDateTime.TimeOfDay);
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_time_of_day_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalTime time = localDateTime.TimeOfDay + Period.FromSeconds(1);

                // Act
                Action act = () => localDateTime.Should().HaveTimeOfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have time of day {time}, but found {localDateTime.TimeOfDay}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_time_of_day_it_fails()
            {
                // Arrange
                LocalTime time = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem()).TimeOfDay;
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveTimeOfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have time of day {time}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveTimeOfDay
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_time_of_day_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotHaveTimeOfDay(localDateTime.TimeOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have time of day {localDateTime.TimeOfDay}.");
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_time_of_day_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalTime time = localDateTime.TimeOfDay + Period.FromSeconds(1);

                // Act
                Action act = () => localDateTime.Should().NotHaveTimeOfDay(time);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_time_of_day_it_fails()
            {
                // Arrange
                LocalTime time = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem()).TimeOfDay;
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveTimeOfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have time of day {time}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveClockHourOfHalfDay
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_clock_hour_of_half_day_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().HaveClockHourOfHalfDay(localDateTime.ClockHourOfHalfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int time = localDateTime.PlusHours(1).ClockHourOfHalfDay;

                // Act
                Action act = () => localDateTime.Should().HaveClockHourOfHalfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have clock hour of the half-day of {time}, but found {localDateTime.ClockHourOfHalfDay}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                int time = new Random().Next(12);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveClockHourOfHalfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have clock hour of the half-day of {time}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveClockHourOfHalfDay
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotHaveClockHourOfHalfDay(localDateTime.ClockHourOfHalfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have clock hour of the half-day of {localDateTime.ClockHourOfHalfDay}.");
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_clock_hour_of_half_day_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int time = localDateTime.PlusHours(1).ClockHourOfHalfDay;

                // Act
                Action act = () => localDateTime.Should().NotHaveClockHourOfHalfDay(time);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                int time = new Random().Next(12);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveClockHourOfHalfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have clock hour of the half-day of {time}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveDay
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_day_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().HaveDay(localDateTime.Day);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_day_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int day = localDateTime.PlusDays(1).Day;

                // Act
                Action act = () => localDateTime.Should().HaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have day {day}, but found {localDateTime.Day}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_day_it_fails()
            {
                // Arrange
                int day = new Random().Next(1, 28);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have day {day}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveDay
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_day_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotHaveDay(localDateTime.Day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have day {localDateTime.Day}.");
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_day_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int day = localDateTime.PlusDays(1).Day;

                // Act
                Action act = () => localDateTime.Should().NotHaveDay(day);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_day_it_fails()
            {
                // Arrange
                int day = new Random().Next(1, 28);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have day {day}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveDayOfWeek
        {
            [Fact]
            public void When_a_local_date_has_the_specified_day_of_week_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().HaveDayOfWeek(localDateTime.DayOfWeek);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_does_not_have_the_specified_day_of_week_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                IsoDayOfWeek dayOfWeek = localDateTime.PlusDays(1).DayOfWeek;

                // Act
                Action act = () => localDateTime.Should().HaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have day of week {dayOfWeek.AsFormatted()}, but found {localDateTime.DayOfWeek.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_has_the_specified_day_of_week_it_fails()
            {
                // Arrange
                IsoDayOfWeek dayOfWeek = RandomDayOfWeek();
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have day of week {dayOfWeek.AsFormatted()}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveDayOfWeek
        {
            [Fact]
            public void When_a_local_date_has_the_specified_day_of_week_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotHaveDayOfWeek(localDateTime.DayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have day of week {localDateTime.DayOfWeek.AsFormatted()}.");
            }

            [Fact]
            public void When_a_local_date_does_not_have_the_specified_day_of_week_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                IsoDayOfWeek dayOfWeek = localDateTime.PlusDays(1).DayOfWeek;

                // Act
                Action act = () => localDateTime.Should().NotHaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_does_not_have_the_specified_day_of_week_it_fails()
            {
                // Arrange
                IsoDayOfWeek dayOfWeek = RandomDayOfWeek();
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have day of week {dayOfWeek.AsFormatted()}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveDayOfYear
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_day_of_year_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().HaveDayOfYear(localDateTime.DayOfYear);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_day_of_year_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int dayOfYear = localDateTime.PlusDays(1).DayOfYear;

                // Act
                Action act = () => localDateTime.Should().HaveDayOfYear(dayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have day of year {dayOfYear}, but found {localDateTime.DayOfYear}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_day_of_year_it_fails()
            {
                // Arrange
                int dayOfYear = new Random().Next(1, 365);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveDayOfYear(dayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have day of year {dayOfYear}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveDayOfYear
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_day_of_year_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotHaveDayOfYear(localDateTime.DayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have day of year {localDateTime.DayOfYear}.");
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_day_of_year_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int dayOfYear = localDateTime.PlusDays(1).DayOfYear;

                // Act
                Action act = () => localDateTime.Should().NotHaveDayOfYear(dayOfYear);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_day_of_year_it_fails()
            {
                // Arrange
                int dayOfYear = new Random().Next(1, 365);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveDayOfYear(dayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have day of year {dayOfYear}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveHour
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_hour_of_day_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().HaveHour(localDateTime.Hour);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int hourOfDay = localDateTime.PlusHours(1).Hour;

                // Act
                Action act = () => localDateTime.Should().HaveHour(hourOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have hour of day {hourOfDay}, but found {localDateTime.Hour}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                int hourOfDay = new Random().Next(1, 23);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveHour(hourOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have hour of day {hourOfDay}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveHour
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotHaveHour(localDateTime.Hour);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have hour of day {localDateTime.Hour}.");
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_hour_of_day_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int hourOfDay = localDateTime.PlusHours(1).Hour;

                // Act
                Action act = () => localDateTime.Should().NotHaveHour(hourOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                int hourOfDay = new Random().Next(1, 23);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveHour(hourOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have hour of day {hourOfDay}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveEra
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_era_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().HaveEra(localDateTime.Era);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_era_it_fails()
            {
                // Arrange
                LocalDateTime ad = new LocalDate(Era.Common, 1966, 9, 8, CalendarSystem.Iso).AtMidnight();
                LocalDateTime bc = new LocalDate(Era.BeforeCommon, 384, 4, 16, CalendarSystem.Iso).AtMidnight();

                // Act
                Action act = () => ad.Should().HaveEra(bc.Era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(ad)} to have era {bc.Era}, but found {ad.Era}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_era_it_fails()
            {
                // Arrange
                Era era = Era.Common;
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveEra(era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have era {era}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveEra
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_era_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotHaveEra(localDateTime.Era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have era {localDateTime.Era}.");
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_era_it_succeeds()
            {
                // Arrange
                LocalDateTime ad = new LocalDate(Era.Common, 1966, 9, 8, CalendarSystem.Iso).AtMidnight();
                LocalDateTime bc = new LocalDate(Era.BeforeCommon, 384, 4, 16, CalendarSystem.Iso).AtMidnight();

                // Act
                Action act = () => ad.Should().NotHaveEra(bc.Era);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_era_it_fails()
            {
                // Arrange
                Era era = Era.Common;
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveEra(era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have era {era}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveMillisecond
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_millisecond_of_day_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().HaveMillisecond(localDateTime.Millisecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int millisecondOfDay = localDateTime.PlusMilliseconds(1).Millisecond;

                // Act
                Action act = () => localDateTime.Should().HaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have millisecond {millisecondOfDay}, but found {localDateTime.Millisecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                int millisecondOfDay = new Random().Next(1, 999);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have millisecond {millisecondOfDay}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveMillisecond
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotHaveMillisecond(localDateTime.Millisecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have millisecond {localDateTime.Millisecond}.");
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_millisecond_of_day_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int millisecondOfDay = localDateTime.PlusMilliseconds(1).Millisecond;

                // Act
                Action act = () => localDateTime.Should().NotHaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                int millisecondOfDay = new Random().Next(1, 999);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have millisecond {millisecondOfDay}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveMinute
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_minute_of_day_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().HaveMinute(localDateTime.Minute);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int minuteOfDay = localDateTime.PlusMinutes(1).Minute;

                // Act
                Action act = () => localDateTime.Should().HaveMinute(minuteOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have minute {minuteOfDay}, but found {localDateTime.Minute}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                int minuteOfDay = new Random().Next(1, 59);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveMinute(minuteOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have minute {minuteOfDay}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveMinute
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotHaveMinute(localDateTime.Minute);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have minute {localDateTime.Minute}.");
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_minute_of_day_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int minuteOfDay = localDateTime.PlusMinutes(1).Minute;

                // Act
                Action act = () => localDateTime.Should().NotHaveMinute(minuteOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                int minuteOfDay = new Random().Next(1, 59);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveMinute(minuteOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have minute {minuteOfDay}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveMonth
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_month_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().HaveMonth(localDateTime.Month);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_month_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int month = localDateTime.PlusMonths(1).Month;

                // Act
                Action act = () => localDateTime.Should().HaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have month {month}, but found {localDateTime.Month}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_month_it_fails()
            {
                // Arrange
                int month = new Random().Next(1, 12);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have month {month}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveMonth
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_month_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotHaveMonth(localDateTime.Month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have month {localDateTime.Month}.");
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_month_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int month = localDateTime.PlusMonths(1).Month;

                // Act
                Action act = () => localDateTime.Should().NotHaveMonth(month);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_month_it_fails()
            {
                // Arrange
                int month = new Random().Next(1, 12);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have month {month}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveNanosecondOfDay
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_nanosecond_of_day_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().HaveNanosecondOfDay(localDateTime.NanosecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_nanosecond_of_day_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                long nanosecondOfDay = localDateTime.PlusNanoseconds(1).NanosecondOfDay;

                // Act
                Action act = () => localDateTime.Should().HaveNanosecondOfDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have nanosecond of day {nanosecondOfDay.AsFormatted()}, but found {localDateTime.NanosecondOfDay.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_nanosecond_of_day_it_fails()
            {
                // Arrange
                long nanosecondOfDay = new Random().Next(1, 999_999_999);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveNanosecondOfDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have nanosecond of day {nanosecondOfDay.AsFormatted()}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveNanosecondOfDay
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_nanosecond_of_day_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotHaveNanosecondOfDay(localDateTime.NanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have nanosecond of day {localDateTime.NanosecondOfDay.AsFormatted()}.");
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_nanosecond_of_day_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                long nanosecondOfDay = localDateTime.PlusNanoseconds(1).NanosecondOfDay;

                // Act
                Action act = () => localDateTime.Should().NotHaveNanosecondOfDay(nanosecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_nanosecond_of_day_it_fails()
            {
                // Arrange
                long nanosecondOfDay = new Random().Next(1, 999_999_999);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveNanosecondOfDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have nanosecond of day {nanosecondOfDay.AsFormatted()}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveNanosecondOfSecond
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_nanosecond_of_second_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().HaveNanosecondOfSecond(localDateTime.NanosecondOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_nanosecond_of_second_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int nanosecondOfSecond = localDateTime.PlusNanoseconds(1).NanosecondOfSecond;

                // Act
                Action act = () => localDateTime.Should().HaveNanosecondOfSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have nanosecond of second {nanosecondOfSecond}, but found {localDateTime.NanosecondOfSecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_nanosecond_of_second_it_fails()
            {
                // Arrange
                int nanosecondOfSecond = new Random().Next(1, 999_999_999);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveNanosecondOfSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have nanosecond of second {nanosecondOfSecond}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveNanosecondOfSecond
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_nanosecond_of_second_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotHaveNanosecondOfSecond(localDateTime.NanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have nanosecond of second {localDateTime.NanosecondOfSecond}.");
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_nanosecond_of_second_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int nanosecondOfSecond = localDateTime.PlusNanoseconds(1).NanosecondOfSecond;

                // Act
                Action act = () => localDateTime.Should().NotHaveNanosecondOfSecond(nanosecondOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_nanosecond_of_second_it_fails()
            {
                // Arrange
                int nanosecondOfSecond = new Random().Next(1, 999_999_999);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveNanosecondOfSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have nanosecond of second {nanosecondOfSecond}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveSecond
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_second_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().HaveSecond(localDateTime.Second);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_second_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int second = localDateTime.PlusSeconds(1).Second;

                // Act
                Action act = () => localDateTime.Should().HaveSecond(second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have second {second}, but found {localDateTime.Second}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_second_it_fails()
            {
                // Arrange
                int second = new Random().Next(1, 59);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveSecond(second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have second {second}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveSecond
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_second_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotHaveSecond(localDateTime.Second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have second {localDateTime.Second}.");
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_second_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int second = localDateTime.PlusSeconds(1).Second;

                // Act
                Action act = () => localDateTime.Should().NotHaveSecond(second);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_second_it_fails()
            {
                // Arrange
                int second = new Random().Next(1, 59);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveSecond(second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have second {second}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveYear
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_year_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().HaveYear(localDateTime.Year);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_year_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int year = localDateTime.PlusYears(1).Year;

                // Act
                Action act = () => localDateTime.Should().HaveYear(year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have year {year}, but found {localDateTime.Year}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_year_it_fails()
            {
                // Arrange
                int year = new Random().Next(2001, 2020);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveYear(year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have year {year}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveYear
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_year_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotHaveYear(localDateTime.Year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have year {localDateTime.Year}.");
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_year_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int year = localDateTime.PlusYears(1).Year;

                // Act
                Action act = () => localDateTime.Should().NotHaveYear(year);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_year_it_fails()
            {
                // Arrange
                int year = new Random().Next(2001, 2020);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveYear(year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have year {year}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveTickOfDay
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_tick_of_day_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().HaveTickOfDay(localDateTime.TickOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_tick_of_day_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                long tickOfDay = localDateTime.PlusTicks(1).TickOfDay;

                // Act
                Action act = () => localDateTime.Should().HaveTickOfDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have tick of day {tickOfDay.AsFormatted()}, but found {localDateTime.TickOfDay.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_tick_of_day_it_fails()
            {
                // Arrange
                long tickOfDay = new Random().Next(1, 999_999_999);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveTickOfDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have tick of day {tickOfDay.AsFormatted()}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveTickOfDay
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_tick_of_day_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotHaveTickOfDay(localDateTime.TickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have tick of day {localDateTime.TickOfDay.AsFormatted()}.");
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_tick_of_day_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                long tickOfDay = localDateTime.PlusTicks(1).TickOfDay;

                // Act
                Action act = () => localDateTime.Should().NotHaveTickOfDay(tickOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_tick_of_day_it_fails()
            {
                // Arrange
                long tickOfDay = new Random().Next(1, 999_999_999);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveTickOfDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have tick of day {tickOfDay.AsFormatted()}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveTickOfSecond
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_tick_of_second_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().HaveTickOfSecond(localDateTime.TickOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int tickOfSecond = localDateTime.PlusTicks(1).TickOfSecond;

                // Act
                Action act = () => localDateTime.Should().HaveTickOfSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have tick of second {tickOfSecond}, but found {localDateTime.TickOfSecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                int tickOfSecond = new Random().Next(1, 9_999_999);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveTickOfSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have tick of second {tickOfSecond}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveTickOfSecond
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotHaveTickOfSecond(localDateTime.TickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have tick of second {localDateTime.TickOfSecond}.");
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_tick_of_second_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int tickOfSecond = localDateTime.PlusTicks(1).TickOfSecond;

                // Act
                Action act = () => localDateTime.Should().NotHaveTickOfSecond(tickOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                int tickOfSecond = new Random().Next(1, 9_999_999);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveTickOfSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have tick of second {tickOfSecond}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class HaveYearOfEra
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_year_of_era_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().HaveYearOfEra(localDateTime.YearOfEra);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_year_of_era_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int yearOfEra = localDateTime.PlusYears(1).YearOfEra;

                // Act
                Action act = () => localDateTime.Should().HaveYearOfEra(yearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have year of era {yearOfEra}, but found {localDateTime.YearOfEra}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_has_the_specified_year_of_era_it_fails()
            {
                // Arrange
                int yearOfEra = new Random().Next(1, 100);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().HaveYearOfEra(yearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to have year of era {yearOfEra}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class NotHaveYearOfEra
        {
            [Fact]
            public void When_a_local_date_time_has_the_specified_year_of_era_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().NotHaveYearOfEra(localDateTime.YearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have year of era {localDateTime.YearOfEra}.");
            }

            [Fact]
            public void When_a_local_date_time_does_not_have_the_specified_year_of_era_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int yearOfEra = localDateTime.PlusYears(1).YearOfEra;

                // Act
                Action act = () => localDateTime.Should().NotHaveYearOfEra(yearOfEra);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_time_does_not_have_the_specified_year_of_era_it_fails()
            {
                // Arrange
                int yearOfEra = new Random().Next(1, 100);
                LocalDateTime? localDateTime = null;

                // Act
                Action act = () => localDateTime.Should().NotHaveYearOfEra(yearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDateTime)} to have year of era {yearOfEra}, but {nameof(localDateTime)} was <null>.");
            }
        }

        public class BeGreaterThan
        {
            [Fact]
            public void When_a_local_date_time_is_greater_than_an_other_local_date_time_it_succeeds()
            {
                // Arrange
                LocalDateTime other = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDateTime localDateTime = other + Period.FromSeconds(1);

                // Act
                Action act = () => localDateTime.Should().BeGreaterThan(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_is_less_than_an_other_local_date_time_it_fails()
            {
                // Arrange
                LocalDateTime other = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDateTime localDateTime = other - Period.FromSeconds(1);

                // Act
                Action act = () => localDateTime.Should().BeGreaterThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be greater than {other}, but found {localDateTime}.");
            }

            [Fact]
            public void When_a_local_date_time_is_equal_to_an_other_local_date_time_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(now, RandomCalendarSystem());
                LocalDateTime other = LocalDateTime.FromDateTime(now, localDateTime.Calendar);

                // Act
                Action act = () => localDateTime.Should().BeGreaterThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be greater than {other}, but found {localDateTime}.");
            }

            [Fact]
            public void When_asserting_a_local_date_time_is_greater_than_itself_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().BeGreaterThan(localDateTime);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be greater than {localDateTime}, but found {localDateTime}.");
            }
        }

        public class BeGreaterThanOrEqualTo
        {
            [Fact]
            public void When_asserting_a_local_date_time_is_greater_than_or_equal_to_itself_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().BeGreaterThanOrEqualTo(localDateTime);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_is_equal_to_an_other_local_date_time_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(now, RandomCalendarSystem());
                LocalDateTime other = LocalDateTime.FromDateTime(now, localDateTime.Calendar);

                // Act
                Action act = () => localDateTime.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_is_greater_than_an_other_local_date_time_it_succeeds()
            {
                // Arrange
                LocalDateTime other = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDateTime localDateTime = other + Period.FromSeconds(1);

                // Act
                Action act = () => localDateTime.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_is_less_than_an_other_local_date_time_it_fails()
            {
                // Arrange
                LocalDateTime other = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDateTime localDateTime = other - Period.FromSeconds(1);

                // Act
                Action act = () => localDateTime.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be greater than or equal to {other}, but found {localDateTime}.");
            }
        }

        public class BeLessThan
        {
            [Fact]
            public void When_a_local_date_time_is_less_than_an_other_local_date_time_it_succeeds()
            {
                // Arrange
                LocalDateTime other = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDateTime localDateTime = other - Period.FromSeconds(1);

                // Act
                Action act = () => localDateTime.Should().BeLessThan(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_is_greater_than_an_other_local_date_time_it_fails()
            {
                // Arrange
                LocalDateTime other = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDateTime localDateTime = other + Period.FromSeconds(1);

                // Act
                Action act = () => localDateTime.Should().BeLessThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be less than {other}, but found {localDateTime}.");
            }

            [Fact]
            public void When_a_local_date_time_is_equal_to_an_other_local_date_time_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(now, RandomCalendarSystem());
                LocalDateTime other = LocalDateTime.FromDateTime(now, localDateTime.Calendar);

                // Act
                Action act = () => localDateTime.Should().BeLessThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be less than {other}, but found {localDateTime}.");
            }

            [Fact]
            public void When_asserting_a_local_date_time_is_less_than_itself_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().BeLessThan(localDateTime);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be less than {localDateTime}, but found {localDateTime}.");
            }
        }

        public class BeLessThanOrEqualTo
        {
            [Fact]
            public void When_asserting_a_local_date_time_is_less_than_or_equal_to_itself_it_succeeds()
            {
                // Arrange
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDateTime.Should().BeLessThanOrEqualTo(localDateTime);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_is_equal_to_an_other_local_date_time_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDateTime localDateTime = LocalDateTime.FromDateTime(now, RandomCalendarSystem());
                LocalDateTime other = LocalDateTime.FromDateTime(now, localDateTime.Calendar);

                // Act
                Action act = () => localDateTime.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_is_less_than_an_other_local_date_time_it_succeeds()
            {
                // Arrange
                LocalDateTime other = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDateTime localDateTime = other - Period.FromSeconds(1);

                // Act
                Action act = () => localDateTime.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_time_is_greater_than_an_other_local_date_time_it_fails()
            {
                // Arrange
                LocalDateTime other = LocalDateTime.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDateTime localDateTime = other + Period.FromSeconds(1);

                // Act
                Action act = () => localDateTime.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDateTime)} to be less than or equal to {other}, but found {localDateTime}.");
            }
        }
    }
}
