using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions.NodaTime.Specs.Extensions;

using NodaTime;
using NodaTime.Calendars;

using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.NodaTime.Specs
{
    public static class LocalDateAssertionsSpecs
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
            public void When_a_local_date_is_equal_to_an_other_local_date_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate localDate = LocalDate.FromDateTime(now, RandomCalendarSystem());
                LocalDate other = LocalDate.FromDateTime(now, localDate.Calendar);

                // Act
                Action act = () => localDate.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_local_date_is_equal_to_itself_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().Be(localDate);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_is_not_equal_to_an_other_local_date_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate localDate = LocalDate.FromDateTime(now, RandomCalendarSystem());
                LocalDate other = LocalDate.FromDateTime(now.AddDays(1), localDate.Calendar);

                // Act
                Action act = () => localDate.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be equal to {other}, but found {localDate}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                LocalDate? localDate = default;
                LocalDate? other = default;

                // Act
                Action act = () => localDate.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_fails()
            {
                // Arrange
                LocalDate? localDate = default;
                LocalDate other = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be equal to {other}, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDate? other = default;

                // Act
                Action act = () => localDate.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be equal to <null>, but found {localDate}.");
            }
        }

        public class BeDateTime
        {
            [Fact]
            public void When_a_local_date_is_equal_to_the_same_datetime_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate localDate = LocalDate.FromDateTime(now);

                // Act
                Action act = () => localDate.Should().Be(now);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_is_not_equal_to_a_datetime_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate localDate = LocalDate.FromDateTime(now);
                DateTime other = now.AddDays(1);

                // Act
                Action act = () => localDate.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be equal to {LocalDate.FromDateTime(other)}, but found {localDate}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                LocalDate? localDate = default;
                DateTime? other = default;

                // Act
                Action act = () => localDate.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_fails()
            {
                // Arrange
                LocalDate? localDate = default;
                DateTime other = DateTime.Now;

                // Act
                Action act = () => localDate.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be equal to {LocalDate.FromDateTime(other)}, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                DateTime? other = default;

                // Act
                Action act = () => localDate.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be equal to <null>, but found {localDate}.");
            }
        }

        public class BeDateTimeAndCalendar
        {
            [Fact]
            public void When_a_local_date_is_equal_to_the_same_datetime_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDate localDate = LocalDate.FromDateTime(now, calendar);

                // Act
                Action act = () => localDate.Should().Be(now, calendar);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_is_not_equal_to_a_datetime_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDate localDate = LocalDate.FromDateTime(now);
                DateTime other = now.AddDays(1);

                // Act
                Action act = () => localDate.Should().Be(other, calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be equal to {LocalDate.FromDateTime(other, calendar)}, but found {localDate}.");
            }

            [Fact]
            public void When_a_local_date_is_not_equal_to_a_datetime_because_of_a_different_calendar_system_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                (CalendarSystem calendar, CalendarSystem otherCalendar) = TwoRandomCalendarSystems();
                LocalDate localDate = LocalDate.FromDateTime(now, calendar);
                DateTime other = now.AddDays(1);

                // Act
                Action act = () => localDate.Should().Be(other, otherCalendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be equal to {LocalDate.FromDateTime(other, otherCalendar)}, but found {localDate}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                LocalDate? localDate = default;
                DateTime? other = default;

                // Act
                Action act = () => localDate.Should().Be(other, RandomCalendarSystem());

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_fails()
            {
                // Arrange
                LocalDate? localDate = default;
                DateTime other = DateTime.Now;
                CalendarSystem calendar = RandomCalendarSystem();

                // Act
                Action act = () => localDate.Should().Be(other, calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be equal to {LocalDate.FromDateTime(other, calendar)}, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                DateTime? other = default;

                // Act
                Action act = () => localDate.Should().Be(other, RandomCalendarSystem());

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be equal to <null>, but found {localDate}.");
            }
        }

        public class NotBe
        {
            [Fact]
            public void When_a_local_date_is_equal_to_an_other_local_date_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate other = LocalDate.FromDateTime(now, RandomCalendarSystem());
                LocalDate localDate = LocalDate.FromDateTime(now, other.Calendar);

                // Act
                Action act = () => localDate.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to be equal to {other}.");
            }

            [Fact]
            public void When_asserting_a_local_date_is_not_equal_to_itself_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate localDate = LocalDate.FromDateTime(now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().NotBe(localDate);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to be equal to {localDate}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_null_it_fails()
            {
                // Arrange
                LocalDate? localDate = default;
                LocalDate? other = default;

                // Act
                Action act = () => localDate.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to be equal to <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_not_null_it_succeeds()
            {
                // Arrange
                LocalDate? localDate = default;
                LocalDate other = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDate? other = default;

                // Act
                Action act = () => localDate.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }
        }

        public class NotBeDateTime
        {
            [Fact]
            public void When_a_local_date_is_not_equal_to_the_same_datetime_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate localDate = LocalDate.FromDateTime(now);

                // Act
                Action act = () => localDate.Should().NotBe(now);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to be equal to {localDate}.");
            }

            [Fact]
            public void When_a_local_date_is_not_equal_to_a_datetime_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate localDate = LocalDate.FromDateTime(now);
                DateTime other = now.AddDays(1);

                // Act
                Action act = () => localDate.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to not be null for the test.")]
            public void When_asserting_null_is_not_equal_to_null_it_fails()
            {
                // Arrange
                LocalDate? localDate = default;
                DateTime? other = default;

                // Act
                Action act = () => localDate.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to be equal to <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to not be null for the test.")]
            public void When_asserting_null_is_not_equal_to_not_null_it_succeeds()
            {
                // Arrange
                LocalDate? localDate = default;
                DateTime other = DateTime.Now;

                // Act
                Action act = () => localDate.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to not be null for the test.")]
            public void When_asserting_not_null_is_not_equal_to_null_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                DateTime? other = default;

                // Act
                Action act = () => localDate.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }
        }

        public class NotBeDateTimeAndCalendar
        {
            [Fact]
            public void When_a_local_date_is_equal_to_the_same_datetime_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDate localDate = LocalDate.FromDateTime(now, calendar);

                // Act
                Action act = () => localDate.Should().NotBe(now, calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to be equal to {localDate}.");
            }

            [Fact]
            public void When_a_local_date_is_not_equal_to_a_datetime_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDate localDate = LocalDate.FromDateTime(now);
                DateTime other = now.AddDays(1);

                // Act
                Action act = () => localDate.Should().NotBe(other, calendar);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_is_not_equal_to_a_datetime_because_of_a_different_calendar_system_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                (CalendarSystem calendar, CalendarSystem otherCalendar) = TwoRandomCalendarSystems();
                LocalDate localDate = LocalDate.FromDateTime(now, calendar);
                DateTime other = now.AddDays(1);

                // Act
                Action act = () => localDate.Should().NotBe(other, otherCalendar);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to not be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_fails()
            {
                // Arrange
                LocalDate? localDate = default;
                DateTime? other = default;

                // Act
                Action act = () => localDate.Should().NotBe(other, RandomCalendarSystem());

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to be equal to <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to not be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_succeeds()
            {
                // Arrange
                LocalDate? localDate = default;
                DateTime other = DateTime.Now;
                CalendarSystem calendar = RandomCalendarSystem();

                // Act
                Action act = () => localDate.Should().NotBe(other, calendar);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to not be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                DateTime? other = default;

                // Act
                Action act = () => localDate.Should().NotBe(other, RandomCalendarSystem());

                // Assert
                act.Should().NotThrow();
            }
        }

        public class BeInCalendar
        {
            [Fact]
            public void When_a_local_date_has_the_specified_calendar_it_succeeds()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, calendar);

                // Act
                Action act = () => localDate.Should().BeInCalendar(calendar);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_calendar()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, calendar);

                // Act
                CalendarSystem returned = localDate.Should().BeInCalendar(calendar).Which;

                // Assert
                returned.Should().Be(calendar);
            }

            [Fact]
            public void When_a_local_date_does_not_have_the_specified_calendar_it_fails()
            {
                // Arrange
                (CalendarSystem calendar, CalendarSystem other) = TwoRandomCalendarSystems();
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, calendar);

                // Act
                Action act = () => localDate.Should().BeInCalendar(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be in calendar {other}, but found {calendar}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_has_a_calendar_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDate? localDate = default;

                // Act
                Action act = () => localDate.Should().BeInCalendar(calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be in calendar {calendar}, but found <null>.");
            }
        }

        public class NotBeInCalendar
        {
            [Fact]
            public void When_a_local_date_does_not_have_the_specified_calendar_it_succeeds()
            {
                // Arrange
                (CalendarSystem calendar, CalendarSystem other) = TwoRandomCalendarSystems();
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, calendar);

                // Act
                Action act = () => localDate.Should().NotBeInCalendar(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_has_the_specified_calendar_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, calendar);

                // Act
                Action act = () => localDate.Should().NotBeInCalendar(calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to be in calendar {calendar}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_has_a_calendar_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                LocalDate? localDate = default;

                // Act
                Action act = () => localDate.Should().NotBeInCalendar(calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to be in calendar {calendar}, but found <null>.");
            }
        }

        public class HaveDay
        {
            [Fact]
            public void When_a_local_date_has_the_specified_day_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().HaveDay(localDate.Day);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_does_not_have_the_specified_day_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int day = localDate.PlusDays(1).Day;

                // Act
                Action act = () => localDate.Should().HaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to have day {day}, but found {localDate.Day}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_has_the_specified_day_it_fails()
            {
                // Arrange
                int day = new Random().Next(1, 28);
                LocalDate? localDate = null;

                // Act
                Action act = () => localDate.Should().HaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to have day {day}, but found <null>.");
            }
        }

        public class NotHaveDay
        {
            [Fact]
            public void When_a_local_date_has_the_specified_day_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().NotHaveDay(localDate.Day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to have day {localDate.Day}.");
            }

            [Fact]
            public void When_a_local_date_does_not_have_the_specified_day_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int day = localDate.PlusDays(1).Day;

                // Act
                Action act = () => localDate.Should().NotHaveDay(day);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_does_not_have_the_specified_day_it_fails()
            {
                // Arrange
                int day = new Random().Next(1, 28);
                LocalDate? localDate = null;

                // Act
                Action act = () => localDate.Should().NotHaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to have day {day}, but found <null>.");
            }
        }

        public class HaveDayOfWeek
        {
            [Fact]
            public void When_a_local_date_has_the_specified_day_of_week_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().HaveDayOfWeek(localDate.DayOfWeek);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_does_not_have_the_specified_day_of_week_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                IsoDayOfWeek dayOfWeek = localDate.PlusDays(1).DayOfWeek;

                // Act
                Action act = () => localDate.Should().HaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to have day of week {dayOfWeek.AsFormatted()}, but found {localDate.DayOfWeek.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_has_the_specified_day_of_week_it_fails()
            {
                // Arrange
                IsoDayOfWeek dayOfWeek = RandomDayOfWeek();
                LocalDate? localDate = null;

                // Act
                Action act = () => localDate.Should().HaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to have day of week {dayOfWeek.AsFormatted()}, but found <null>.");
            }
        }

        public class NotHaveDayOfWeek
        {
            [Fact]
            public void When_a_local_date_has_the_specified_day_of_week_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().NotHaveDayOfWeek(localDate.DayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to have day of week {localDate.DayOfWeek.AsFormatted()}.");
            }

            [Fact]
            public void When_a_local_date_does_not_have_the_specified_day_of_week_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                IsoDayOfWeek dayOfWeek = localDate.PlusDays(1).DayOfWeek;

                // Act
                Action act = () => localDate.Should().NotHaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_does_not_have_the_specified_day_of_week_it_fails()
            {
                // Arrange
                IsoDayOfWeek dayOfWeek = RandomDayOfWeek();
                LocalDate? localDate = null;

                // Act
                Action act = () => localDate.Should().NotHaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to have day of week {dayOfWeek.AsFormatted()}, but found <null>.");
            }
        }

        public class HaveDayOfYear
        {
            [Fact]
            public void When_a_local_date_has_the_specified_day_of_year_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().HaveDayOfYear(localDate.DayOfYear);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_does_not_have_the_specified_day_of_year_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int dayOfYear = localDate.PlusDays(1).DayOfYear;

                // Act
                Action act = () => localDate.Should().HaveDayOfYear(dayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to have day of year {dayOfYear}, but found {localDate.DayOfYear}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_has_the_specified_day_of_year_it_fails()
            {
                // Arrange
                int dayOfYear = new Random().Next(1, 365);
                LocalDate? localDate = null;

                // Act
                Action act = () => localDate.Should().HaveDayOfYear(dayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to have day of year {dayOfYear}, but found <null>.");
            }
        }

        public class NotHaveDayOfYear
        {
            [Fact]
            public void When_a_local_date_has_the_specified_day_of_year_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().NotHaveDayOfYear(localDate.DayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to have day of year {localDate.DayOfYear}.");
            }

            [Fact]
            public void When_a_local_date_does_not_have_the_specified_day_of_year_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int dayOfYear = localDate.PlusDays(1).DayOfYear;

                // Act
                Action act = () => localDate.Should().NotHaveDayOfYear(dayOfYear);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_does_not_have_the_specified_day_of_year_it_fails()
            {
                // Arrange
                int dayOfYear = new Random().Next(1, 365);
                LocalDate? localDate = null;

                // Act
                Action act = () => localDate.Should().NotHaveDayOfYear(dayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to have day of year {dayOfYear}, but found <null>.");
            }
        }

        public class HaveEra
        {
            [Fact]
            public void When_a_local_date_has_the_specified_era_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().HaveEra(localDate.Era);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_does_not_have_the_specified_era_it_fails()
            {
                // Arrange
                LocalDate ad = new LocalDate(Era.Common, 1966, 9, 8, CalendarSystem.Iso);
                LocalDate bc = new LocalDate(Era.BeforeCommon, 384, 4, 16, CalendarSystem.Iso);

                // Act
                Action act = () => ad.Should().HaveEra(bc.Era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(ad)} to have era {bc.Era}, but found {ad.Era}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_has_the_specified_era_it_fails()
            {
                // Arrange
                Era era = Era.Common;
                LocalDate? localDate = null;

                // Act
                Action act = () => localDate.Should().HaveEra(era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to have era {era}, but found <null>.");
            }
        }

        public class NotHaveEra
        {
            [Fact]
            public void When_a_local_date_has_the_specified_era_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().NotHaveEra(localDate.Era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to have era {localDate.Era}.");
            }

            [Fact]
            public void When_a_local_date_does_not_have_the_specified_era_it_succeeds()
            {
                // Arrange
                LocalDate ad = new LocalDate(Era.Common, 1966, 9, 8, CalendarSystem.Iso);
                LocalDate bc = new LocalDate(Era.BeforeCommon, 384, 4, 16, CalendarSystem.Iso);

                // Act
                Action act = () => ad.Should().NotHaveEra(bc.Era);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_does_not_have_the_specified_era_it_fails()
            {
                // Arrange
                Era era = Era.Common;
                LocalDate? localDate = null;

                // Act
                Action act = () => localDate.Should().NotHaveEra(era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to have era {era}, but found <null>.");
            }
        }

        public class HaveMonth
        {
            [Fact]
            public void When_a_local_date_has_the_specified_month_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().HaveMonth(localDate.Month);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_does_not_have_the_specified_month_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int month = localDate.PlusMonths(1).Month;

                // Act
                Action act = () => localDate.Should().HaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to have month {month}, but found {localDate.Month}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_has_the_specified_month_it_fails()
            {
                // Arrange
                int month = new Random().Next(1, 12);
                LocalDate? localDate = null;

                // Act
                Action act = () => localDate.Should().HaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to have month {month}, but found <null>.");
            }
        }

        public class NotHaveMonth
        {
            [Fact]
            public void When_a_local_date_has_the_specified_month_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().NotHaveMonth(localDate.Month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to have month {localDate.Month}.");
            }

            [Fact]
            public void When_a_local_date_does_not_have_the_specified_month_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int month = localDate.PlusMonths(1).Month;

                // Act
                Action act = () => localDate.Should().NotHaveMonth(month);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_does_not_have_the_specified_month_it_fails()
            {
                // Arrange
                int month = new Random().Next(1, 12);
                LocalDate? localDate = null;

                // Act
                Action act = () => localDate.Should().NotHaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to have month {month}, but found <null>.");
            }
        }

        public class HaveYear
        {
            [Fact]
            public void When_a_local_date_has_the_specified_year_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().HaveYear(localDate.Year);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_does_not_have_the_specified_year_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int year = localDate.PlusYears(1).Year;

                // Act
                Action act = () => localDate.Should().HaveYear(year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to have year {year}, but found {localDate.Year}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_has_the_specified_year_it_fails()
            {
                // Arrange
                int year = new Random().Next(2001, 2020);
                LocalDate? localDate = null;

                // Act
                Action act = () => localDate.Should().HaveYear(year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to have year {year}, but found <null>.");
            }
        }

        public class NotHaveYear
        {
            [Fact]
            public void When_a_local_date_has_the_specified_year_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().NotHaveYear(localDate.Year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to have year {localDate.Year}.");
            }

            [Fact]
            public void When_a_local_date_does_not_have_the_specified_year_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int year = localDate.PlusYears(1).Year;

                // Act
                Action act = () => localDate.Should().NotHaveYear(year);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_does_not_have_the_specified_year_it_fails()
            {
                // Arrange
                int year = new Random().Next(2001, 2020);
                LocalDate? localDate = null;

                // Act
                Action act = () => localDate.Should().NotHaveYear(year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to have year {year}, but found <null>.");
            }
        }

        public class HaveYearWithinEra
        {
            [Fact]
            public void When_a_local_date_has_the_specified_as_the_year_within_the_era_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().HaveYearWithinEra(localDate.YearOfEra);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_does_not_have_the_specified_as_the_year_within_the_era_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int yearOfEra = localDate.PlusYears(1).YearOfEra;

                // Act
                Action act = () => localDate.Should().HaveYearWithinEra(yearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to have {yearOfEra} as the year within the era, but found {localDate.YearOfEra}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_has_the_specified_as_the_year_within_the_era_it_fails()
            {
                // Arrange
                int yearOfEra = new Random().Next(1, 100);
                LocalDate? localDate = null;

                // Act
                Action act = () => localDate.Should().HaveYearWithinEra(yearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to have {yearOfEra} as the year within the era, but found <null>.");
            }
        }

        public class NotHaveYearWithinEra
        {
            [Fact]
            public void When_a_local_date_has_the_specified_as_the_year_within_the_era_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().NotHaveYearWithinEra(localDate.YearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to have {localDate.YearOfEra} as the year within the era.");
            }

            [Fact]
            public void When_a_local_date_does_not_have_the_specified_as_the_year_within_the_era_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                int yearOfEra = localDate.PlusYears(1).YearOfEra;

                // Act
                Action act = () => localDate.Should().NotHaveYearWithinEra(yearOfEra);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_local_date_does_not_have_the_specified_as_the_year_within_the_era_it_fails()
            {
                // Arrange
                int yearOfEra = new Random().Next(1, 100);
                LocalDate? localDate = null;

                // Act
                Action act = () => localDate.Should().NotHaveYearWithinEra(yearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(localDate)} to have {yearOfEra} as the year within the era, but found <null>.");
            }
        }

        public class BeGreaterThan
        {
            [Fact]
            public void When_a_local_date_is_greater_than_an_other_local_date_it_succeeds()
            {
                // Arrange
                LocalDate other = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDate localDate = other + Period.FromDays(1);

                // Act
                Action act = () => localDate.Should().BeGreaterThan(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_is_less_than_an_other_local_date_it_fails()
            {
                // Arrange
                LocalDate other = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDate localDate = other - Period.FromDays(1);

                // Act
                Action act = () => localDate.Should().BeGreaterThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be greater than {other}, but found {localDate}.");
            }

            [Fact]
            public void When_a_local_date_is_equal_to_an_other_local_date_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate localDate = LocalDate.FromDateTime(now, RandomCalendarSystem());
                LocalDate other = LocalDate.FromDateTime(now, localDate.Calendar);

                // Act
                Action act = () => localDate.Should().BeGreaterThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be greater than {other}, but found {localDate}.");
            }

            [Fact]
            public void When_asserting_a_local_date_is_greater_than_itself_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().BeGreaterThan(localDate);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be greater than {localDate}, but found {localDate}.");
            }
        }

        public class BeGreaterThanOrEqualTo
        {
            [Fact]
            public void When_asserting_a_local_date_is_greater_than_or_equal_to_itself_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().BeGreaterThanOrEqualTo(localDate);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_is_equal_to_an_other_local_date_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate localDate = LocalDate.FromDateTime(now, RandomCalendarSystem());
                LocalDate other = LocalDate.FromDateTime(now, localDate.Calendar);

                // Act
                Action act = () => localDate.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_is_greater_than_an_other_local_date_it_succeeds()
            {
                // Arrange
                LocalDate other = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDate localDate = other + Period.FromDays(1);

                // Act
                Action act = () => localDate.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_is_less_than_an_other_local_date_it_fails()
            {
                // Arrange
                LocalDate other = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDate localDate = other - Period.FromDays(1);

                // Act
                Action act = () => localDate.Should().BeGreaterThanOrEqualTo(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be greater than or equal to {other}, but found {localDate}.");
            }
        }

        public class BeLessThan
        {
            [Fact]
            public void When_a_local_date_is_less_than_an_other_local_date_it_succeeds()
            {
                // Arrange
                LocalDate other = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDate localDate = other - Period.FromDays(1);

                // Act
                Action act = () => localDate.Should().BeLessThan(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_is_greater_than_an_other_local_date_it_fails()
            {
                // Arrange
                LocalDate other = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDate localDate = other + Period.FromDays(1);

                // Act
                Action act = () => localDate.Should().BeLessThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be less than {other}, but found {localDate}.");
            }

            [Fact]
            public void When_a_local_date_is_equal_to_an_other_local_date_it_fails()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate localDate = LocalDate.FromDateTime(now, RandomCalendarSystem());
                LocalDate other = LocalDate.FromDateTime(now, localDate.Calendar);

                // Act
                Action act = () => localDate.Should().BeLessThan(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be less than {other}, but found {localDate}.");
            }

            [Fact]
            public void When_asserting_a_local_date_is_less_than_itself_it_fails()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().BeLessThan(localDate);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be less than {localDate}, but found {localDate}.");
            }
        }

        public class BeLessThanOrEqualTo
        {
            [Fact]
            public void When_asserting_a_local_date_is_less_than_or_equal_to_itself_it_succeeds()
            {
                // Arrange
                LocalDate localDate = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());

                // Act
                Action act = () => localDate.Should().BeLessThanOrEqualTo(localDate);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_is_equal_to_an_other_local_date_it_succeeds()
            {
                // Arrange
                DateTime now = DateTime.Now;
                LocalDate localDate = LocalDate.FromDateTime(now, RandomCalendarSystem());
                LocalDate other = LocalDate.FromDateTime(now, localDate.Calendar);

                // Act
                Action act = () => localDate.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_is_less_than_an_other_local_date_it_succeeds()
            {
                // Arrange
                LocalDate other = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDate localDate = other - Period.FromDays(1);

                // Act
                Action act = () => localDate.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_local_date_is_greater_than_an_other_local_date_it_fails()
            {
                // Arrange
                LocalDate other = LocalDate.FromDateTime(DateTime.Now, RandomCalendarSystem());
                LocalDate localDate = other + Period.FromDays(1);

                // Act
                Action act = () => localDate.Should().BeLessThanOrEqualTo(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(localDate)} to be less than or equal to {other}, but found {localDate}.");
            }
        }
    }
}
