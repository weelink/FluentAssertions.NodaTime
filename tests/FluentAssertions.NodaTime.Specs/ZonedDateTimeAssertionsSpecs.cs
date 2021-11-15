﻿using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions.NodaTime.Specs.Extensions;

using NodaTime;
using NodaTime.Calendars;

using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.NodaTime.Specs
{
    public static class ZonedDateTimeAssertionsSpecs
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
            public void When_a_zoned_date_time_is_equal_to_an_other_zoned_date_time_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem());
                ZonedDateTime other = ZonedDateTime.FromDateTimeOffset(now).WithCalendar(zonedDateTime.Calendar);

                // Act
                Action act = () => zonedDateTime.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_zoned_date_time_is_equal_to_itself_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().Be(zonedDateTime);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                ZonedDateTime? zonedDateTime = default;
                ZonedDateTime? other = default;

                // Act
                Action act = () => zonedDateTime.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_fails()
            {
                // Arrange
                ZonedDateTime? zonedDateTime = default;
                ZonedDateTime other = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to be equal to {other}, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                ZonedDateTime? other = default;

                // Act
                Action act = () => zonedDateTime.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to be equal to <null>, but found {zonedDateTime}.");
            }
        }

        public class NotBe
        {
            [Fact]
            public void When_a_zoned_date_time_is_equal_to_an_other_zoned_date_time_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                ZonedDateTime other = ZonedDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem());
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(now).WithCalendar(other.Calendar);

                // Act
                Action act = () => zonedDateTime.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to be equal to {other}.");
            }

            [Fact]
            public void When_asserting_a_zoned_date_time_is_not_equal_to_itself_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotBe(zonedDateTime);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to be equal to {zonedDateTime}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_null_it_fails()
            {
                // Arrange
                ZonedDateTime? zonedDateTime = default;
                ZonedDateTime? other = default;

                // Act
                Action act = () => zonedDateTime.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to be equal to <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_not_null_it_succeeds()
            {
                // Arrange
                ZonedDateTime? zonedDateTime = default;
                ZonedDateTime other = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                ZonedDateTime? other = default;

                // Act
                Action act = () => zonedDateTime.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }
        }

        public class HaveLocalDateTime
        {
            [Fact]
            public void When_a_zoned_local_date_time_has_the_specified_local_date_time_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                LocalDateTime localDateTime = zonedDateTime.LocalDateTime;

                // Act
                Action act = () => zonedDateTime.Should().HaveLocalDateTime(localDateTime);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_date()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                LocalDateTime localDateTime = zonedDateTime.LocalDateTime;

                // Act
                LocalDateTime returned = zonedDateTime.Should().HaveLocalDateTime(localDateTime).Which;

                // Assert
                returned.Should().Be(localDateTime);
            }

            [Fact]
            public void When_a_zoned_local_date_time_does_not_have_the_specified_local_date_time_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                LocalDateTime localDateTime = zonedDateTime.PlusSeconds(1).LocalDateTime;

                // Act
                Action act = () => zonedDateTime.Should().HaveLocalDateTime(localDateTime);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have local date time {localDateTime}, but found {zonedDateTime.LocalDateTime}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_local_date_time_has_the_specified_local_date_time_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).LocalDateTime;
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveLocalDateTime(localDateTime);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have local date time {localDateTime}, but found <null>.");
            }
        }

        public class NotHaveLocalDateTime
        {
            [Fact]
            public void When_a_zoned_local_date_time_has_the_specified_local_date_time_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                LocalDateTime localDateTime = zonedDateTime.LocalDateTime;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveLocalDateTime(localDateTime);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have local date time {localDateTime}.");
            }

            [Fact]
            public void When_a_zoned_local_date_time_does_not_have_the_specified_local_date_time_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now);
                LocalDateTime localDateTime = zonedDateTime.PlusSeconds(1).LocalDateTime;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveLocalDateTime(localDateTime);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_local_date_time_does_not_have_the_specified_local_date_time_it_fails()
            {
                // Arrange
                LocalDateTime localDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).LocalDateTime;
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveLocalDateTime(localDateTime);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have local date time {localDateTime}, but found <null>.");
            }
        }

        public class HaveOffset
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_offset_it_succeeds()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                Offset offset = zonedDateTime.Offset;

                // Act
                Action act = () => zonedDateTime.Should().HaveOffset(offset);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_zoned_date()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                Offset offset = zonedDateTime.Offset;

                // Act
                Offset returned = zonedDateTime.Should().HaveOffset(offset).Which;

                // Assert
                returned.Should().Be(offset);
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_offset_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                Offset offset = zonedDateTime.Offset.Plus(Offset.FromSeconds(1));

                // Act
                Action act = () => zonedDateTime.Should().HaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have offset {offset}, but found {zonedDateTime.Offset}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_offset_it_fails()
            {
                // Arrange
                Offset offset = Offset.FromSeconds(1);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have offset {offset}, but found <null>.");
            }
        }

        public class NotHaveOffset
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_offset_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                Offset offset = zonedDateTime.Offset;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have offset {offset}.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_offset_it_succeeds()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                Offset offset = zonedDateTime.Offset.Plus(Offset.FromSeconds(1));

                // Act
                Action act = () => zonedDateTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_offset_it_fails()
            {
                // Arrange
                Offset offset = Offset.FromSeconds(1);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have offset {offset}, but found <null>.");
            }
        }

        public class HaveOffsetTimeSpan
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_offset_it_succeeds()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                TimeSpan offset = zonedDateTime.Offset.ToTimeSpan();

                // Act
                Action act = () => zonedDateTime.Should().HaveOffset(offset);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_zoned_date()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                TimeSpan offset = zonedDateTime.Offset.ToTimeSpan();

                // Act
                Offset returned = zonedDateTime.Should().HaveOffset(offset).Which;

                // Assert
                returned.Should().Be(offset);
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_offset_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                TimeSpan offset = zonedDateTime.Offset.Plus(Offset.FromSeconds(1)).ToTimeSpan();

                // Act
                Action act = () => zonedDateTime.Should().HaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have offset {Offset.FromTimeSpan(offset)}, but found {zonedDateTime.Offset}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_offset_it_fails()
            {
                // Arrange
                TimeSpan offset = TimeSpan.FromSeconds(1);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have offset {Offset.FromTimeSpan(offset)}, but found <null>.");
            }
        }

        public class NotHaveOffsetTimeSpan
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_offset_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                TimeSpan offset = zonedDateTime.Offset.ToTimeSpan();

                // Act
                Action act = () => zonedDateTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have offset {Offset.FromTimeSpan(offset)}.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_offset_it_succeeds()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);
                TimeSpan offset = zonedDateTime.Offset.Plus(Offset.FromSeconds(1)).ToTimeSpan();

                // Act
                Action act = () => zonedDateTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_offset_it_fails()
            {
                // Arrange
                TimeSpan offset = TimeSpan.FromSeconds(1);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveOffset(offset);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have offset {Offset.FromTimeSpan(offset)}, but found <null>.");
            }
        }

        public class BeInCalendar
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_calendar_it_succeeds()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);

                // Act
                Action act = () => zonedDateTime.Should().BeInCalendar(calendar);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_calendar()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);

                // Act
                CalendarSystem returned = zonedDateTime.Should().BeInCalendar(calendar).Which;

                // Assert
                returned.Should().Be(calendar);
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_calendar_it_fails()
            {
                // Arrange
                (CalendarSystem calendar, CalendarSystem other) = TwoRandomCalendarSystems();
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);

                // Act
                Action act = () => zonedDateTime.Should().BeInCalendar(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to be in calendar {other}, but found {calendar}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_a_calendar_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                ZonedDateTime? zonedDateTime = default;

                // Act
                Action act = () => zonedDateTime.Should().BeInCalendar(calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to be in calendar {calendar}, but found <null>.");
            }
        }

        public class NotBeInCalendar
        {
            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_calendar_it_succeeds()
            {
                // Arrange
                (CalendarSystem calendar, CalendarSystem other) = TwoRandomCalendarSystems();
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);

                // Act
                Action act = () => zonedDateTime.Should().NotBeInCalendar(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_zoned_date_time_has_the_specified_calendar_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar);

                // Act
                Action act = () => zonedDateTime.Should().NotBeInCalendar(calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to be in calendar {calendar}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_a_calendar_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                ZonedDateTime? zonedDateTime = default;

                // Act
                Action act = () => zonedDateTime.Should().NotBeInCalendar(calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to be in calendar {calendar}, but found <null>.");
            }
        }

        public class HaveDate
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_date_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                LocalDate date = zonedDateTime.Date;

                // Act
                Action act = () => zonedDateTime.Should().HaveDate(date);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_zoned_date()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                LocalDate date = zonedDateTime.Date;

                // Act
                LocalDate returned = zonedDateTime.Should().HaveDate(date).Which;

                // Assert
                returned.Should().Be(date);
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_date_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                LocalDate date = zonedDateTime.Date.PlusDays(1);

                // Act
                Action act = () => zonedDateTime.Should().HaveDate(date);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have date {date}, but found {zonedDateTime.Date}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_date_it_fails()
            {
                // Arrange
                LocalDate date = LocalDate.FromDateTime(DateTime.Now);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveDate(date);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have date {date}, but found <null>.");
            }
        }

        public class NotHaveDate
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_date_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                LocalDate date = zonedDateTime.Date;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveDate(date);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have date {date}.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_date_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                LocalDate date = zonedDateTime.Date.PlusDays(1);

                // Act
                Action act = () => zonedDateTime.Should().NotHaveDate(date);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_date_it_fails()
            {
                // Arrange
                LocalDate date = LocalDate.FromDateTime(DateTime.Now);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveDate(date);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have date {date}, but found <null>.");
            }
        }

        public class HaveTimeOfDay
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_time_of_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().HaveTimeOfDay(zonedDateTime.TimeOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_zoned_time()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                LocalTime returned = zonedDateTime.Should().HaveTimeOfDay(zonedDateTime.TimeOfDay).Which;

                // Assert
                returned.Should().Be(zonedDateTime.TimeOfDay);
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_time_of_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                LocalTime time = zonedDateTime.TimeOfDay + Period.FromSeconds(1);

                // Act
                Action act = () => zonedDateTime.Should().HaveTimeOfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have time of day {time}, but found {zonedDateTime.TimeOfDay}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_time_of_day_it_fails()
            {
                // Arrange
                LocalTime time = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem()).TimeOfDay;
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveTimeOfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have time of day {time}, but found <null>.");
            }
        }

        public class NotHaveTimeOfDay
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_time_of_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotHaveTimeOfDay(zonedDateTime.TimeOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have time of day {zonedDateTime.TimeOfDay}.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_time_of_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                LocalTime time = zonedDateTime.TimeOfDay + Period.FromSeconds(1);

                // Act
                Action act = () => zonedDateTime.Should().NotHaveTimeOfDay(time);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_time_of_day_it_fails()
            {
                // Arrange
                LocalTime time = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem()).TimeOfDay;
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveTimeOfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have time of day {time}, but found <null>.");
            }
        }

        public class HaveClockHourOfHalfDay
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_clock_hour_of_half_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().HaveClockHourOfHalfDay(zonedDateTime.ClockHourOfHalfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int time = zonedDateTime.PlusHours(1).ClockHourOfHalfDay;

                // Act
                Action act = () => zonedDateTime.Should().HaveClockHourOfHalfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have clock hour of the half-day of {time}, but found {zonedDateTime.ClockHourOfHalfDay}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                int time = new Random().Next(12);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveClockHourOfHalfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have clock hour of the half-day of {time}, but found <null>.");
            }
        }

        public class NotHaveClockHourOfHalfDay
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotHaveClockHourOfHalfDay(zonedDateTime.ClockHourOfHalfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have clock hour of the half-day of {zonedDateTime.ClockHourOfHalfDay}.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_clock_hour_of_half_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int time = zonedDateTime.PlusHours(1).ClockHourOfHalfDay;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveClockHourOfHalfDay(time);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_clock_hour_of_half_day_it_fails()
            {
                // Arrange
                int time = new Random().Next(12);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveClockHourOfHalfDay(time);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have clock hour of the half-day of {time}, but found <null>.");
            }
        }

        public class HaveDay
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().HaveDay(zonedDateTime.Day);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int day = zonedDateTime.Plus(Duration.FromDays(1)).Day;

                // Act
                Action act = () => zonedDateTime.Should().HaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have day {day}, but found {zonedDateTime.Day}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_day_it_fails()
            {
                // Arrange
                int day = new Random().Next(1, 28);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have day {day}, but found <null>.");
            }
        }

        public class NotHaveDay
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotHaveDay(zonedDateTime.Day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have day {zonedDateTime.Day}.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int day = zonedDateTime.Plus(Duration.FromDays(1)).Day;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveDay(day);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_day_it_fails()
            {
                // Arrange
                int day = new Random().Next(1, 28);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have day {day}, but found <null>.");
            }
        }

        public class HaveDayOfWeek
        {
            [Fact]
            public void When_a_zoned_date_has_the_specified_day_of_week_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().HaveDayOfWeek(zonedDateTime.DayOfWeek);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_zoned_date_does_not_have_the_specified_day_of_week_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                IsoDayOfWeek dayOfWeek = zonedDateTime.Plus(Duration.FromDays(1)).DayOfWeek;

                // Act
                Action act = () => zonedDateTime.Should().HaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have day of week {dayOfWeek.AsFormatted()}, but found {zonedDateTime.DayOfWeek.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_has_the_specified_day_of_week_it_fails()
            {
                // Arrange
                IsoDayOfWeek dayOfWeek = RandomDayOfWeek();
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have day of week {dayOfWeek.AsFormatted()}, but found <null>.");
            }
        }

        public class NotHaveDayOfWeek
        {
            [Fact]
            public void When_a_zoned_date_has_the_specified_day_of_week_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotHaveDayOfWeek(zonedDateTime.DayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have day of week {zonedDateTime.DayOfWeek.AsFormatted()}.");
            }

            [Fact]
            public void When_a_zoned_date_does_not_have_the_specified_day_of_week_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                IsoDayOfWeek dayOfWeek = zonedDateTime.Plus(Duration.FromDays(1)).DayOfWeek;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_does_not_have_the_specified_day_of_week_it_fails()
            {
                // Arrange
                IsoDayOfWeek dayOfWeek = RandomDayOfWeek();
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have day of week {dayOfWeek.AsFormatted()}, but found <null>.");
            }
        }

        public class HaveDayOfYear
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_day_of_year_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().HaveDayOfYear(zonedDateTime.DayOfYear);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_day_of_year_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int dayOfYear = zonedDateTime.Plus(Duration.FromDays(1)).DayOfYear;

                // Act
                Action act = () => zonedDateTime.Should().HaveDayOfYear(dayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have day of year {dayOfYear}, but found {zonedDateTime.DayOfYear}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_day_of_year_it_fails()
            {
                // Arrange
                int dayOfYear = new Random().Next(1, 365);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveDayOfYear(dayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have day of year {dayOfYear}, but found <null>.");
            }
        }

        public class NotHaveDayOfYear
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_day_of_year_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotHaveDayOfYear(zonedDateTime.DayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have day of year {zonedDateTime.DayOfYear}.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_day_of_year_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int dayOfYear = zonedDateTime.Plus(Duration.FromDays(1)).DayOfYear;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveDayOfYear(dayOfYear);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_day_of_year_it_fails()
            {
                // Arrange
                int dayOfYear = new Random().Next(1, 365);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveDayOfYear(dayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have day of year {dayOfYear}, but found <null>.");
            }
        }

        public class HaveHour
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_hour_of_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().HaveHour(zonedDateTime.Hour);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int hourOfDay = zonedDateTime.PlusHours(1).Hour;

                // Act
                Action act = () => zonedDateTime.Should().HaveHour(hourOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have hour of day {hourOfDay}, but found {zonedDateTime.Hour}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                int hourOfDay = new Random().Next(1, 23);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveHour(hourOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have hour of day {hourOfDay}, but found <null>.");
            }
        }

        public class NotHaveHour
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotHaveHour(zonedDateTime.Hour);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have hour of day {zonedDateTime.Hour}.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_hour_of_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int hourOfDay = zonedDateTime.PlusHours(1).Hour;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveHour(hourOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_hour_of_day_it_fails()
            {
                // Arrange
                int hourOfDay = new Random().Next(1, 23);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveHour(hourOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have hour of day {hourOfDay}, but found <null>.");
            }
        }

        public class HaveEra
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_era_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().HaveEra(zonedDateTime.Era);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_era_it_fails()
            {
                // Arrange
                ZonedDateTime ad = new LocalDate(Era.Common, 1966, 9, 8, CalendarSystem.Iso).AtMidnight().InUtc();
                ZonedDateTime bc = new LocalDate(Era.BeforeCommon, 384, 4, 16, CalendarSystem.Iso).AtMidnight().InUtc();

                // Act
                Action act = () => ad.Should().HaveEra(bc.Era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(ad)} to have era {bc.Era}, but found {ad.Era}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_era_it_fails()
            {
                // Arrange
                Era era = Era.Common;
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveEra(era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have era {era}, but found <null>.");
            }
        }

        public class NotHaveEra
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_era_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotHaveEra(zonedDateTime.Era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have era {zonedDateTime.Era}.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_era_it_succeeds()
            {
                // Arrange
                ZonedDateTime ad = new LocalDate(Era.Common, 1966, 9, 8, CalendarSystem.Iso).AtMidnight().InUtc();
                ZonedDateTime bc = new LocalDate(Era.BeforeCommon, 384, 4, 16, CalendarSystem.Iso).AtMidnight().InUtc();

                // Act
                Action act = () => ad.Should().NotHaveEra(bc.Era);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_era_it_fails()
            {
                // Arrange
                Era era = Era.Common;
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveEra(era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have era {era}, but found <null>.");
            }
        }

        public class HaveMillisecond
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_millisecond_of_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().HaveMillisecond(zonedDateTime.Millisecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int millisecondOfDay = zonedDateTime.PlusMilliseconds(1).Millisecond;

                // Act
                Action act = () => zonedDateTime.Should().HaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have millisecond {millisecondOfDay}, but found {zonedDateTime.Millisecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                int millisecondOfDay = new Random().Next(1, 999);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have millisecond {millisecondOfDay}, but found <null>.");
            }
        }

        public class NotHaveMillisecond
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotHaveMillisecond(zonedDateTime.Millisecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have millisecond {zonedDateTime.Millisecond}.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_millisecond_of_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int millisecondOfDay = zonedDateTime.PlusMilliseconds(1).Millisecond;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_millisecond_of_day_it_fails()
            {
                // Arrange
                int millisecondOfDay = new Random().Next(1, 999);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveMillisecond(millisecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have millisecond {millisecondOfDay}, but found <null>.");
            }
        }

        public class HaveMinute
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_minute_of_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().HaveMinute(zonedDateTime.Minute);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int minuteOfDay = zonedDateTime.PlusMinutes(1).Minute;

                // Act
                Action act = () => zonedDateTime.Should().HaveMinute(minuteOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have minute {minuteOfDay}, but found {zonedDateTime.Minute}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                int minuteOfDay = new Random().Next(1, 59);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveMinute(minuteOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have minute {minuteOfDay}, but found <null>.");
            }
        }

        public class NotHaveMinute
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotHaveMinute(zonedDateTime.Minute);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have minute {zonedDateTime.Minute}.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_minute_of_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int minuteOfDay = zonedDateTime.PlusMinutes(1).Minute;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveMinute(minuteOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_minute_of_day_it_fails()
            {
                // Arrange
                int minuteOfDay = new Random().Next(1, 59);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveMinute(minuteOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have minute {minuteOfDay}, but found <null>.");
            }
        }

        public class HaveMonth
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_month_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().HaveMonth(zonedDateTime.Month);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_month_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem());
                int month = zonedDateTime.Month + 1;

                // Act
                Action act = () => zonedDateTime.Should().HaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have month {month}, but found {zonedDateTime.Month}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_month_it_fails()
            {
                // Arrange
                int month = new Random().Next(1, 12);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have month {month}, but found <null>.");
            }
        }

        public class NotHaveMonth
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_month_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotHaveMonth(zonedDateTime.Month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have month {zonedDateTime.Month}.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_month_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem());
                int month = zonedDateTime.Month + 1;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveMonth(month);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_month_it_fails()
            {
                // Arrange
                int month = new Random().Next(1, 12);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have month {month}, but found <null>.");
            }
        }

        public class HaveNanosecondsWithinDay
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_nanoseconds_within_the_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().HaveNanosecondsWithinDay(zonedDateTime.NanosecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                long nanosecondOfDay = zonedDateTime.PlusNanoseconds(1).NanosecondOfDay;

                // Act
                Action act = () => zonedDateTime.Should().HaveNanosecondsWithinDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have {nanosecondOfDay.AsFormatted()} nanoseconds within the day, but found {zonedDateTime.NanosecondOfDay.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                long nanosecondOfDay = new Random().Next(1, 999_999_999);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveNanosecondsWithinDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have {nanosecondOfDay.AsFormatted()} nanoseconds within the day, but found <null>.");
            }
        }

        public class NotHaveNanosecondsWithinDay
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotHaveNanosecondsWithinDay(zonedDateTime.NanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have {zonedDateTime.NanosecondOfDay.AsFormatted()} nanoseconds within the day.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_nanoseconds_within_the_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                long nanosecondOfDay = zonedDateTime.PlusNanoseconds(1).NanosecondOfDay;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveNanosecondsWithinDay(nanosecondOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                long nanosecondOfDay = new Random().Next(1, 999_999_999);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveNanosecondsWithinDay(nanosecondOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have {nanosecondOfDay.AsFormatted()} nanoseconds within the day, but found <null>.");
            }
        }

        public class HaveNanosecondsWithinSecond
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_nanoseconds_within_the_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().HaveNanosecondsWithinSecond(zonedDateTime.NanosecondOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int nanosecondOfSecond = zonedDateTime.PlusNanoseconds(1).NanosecondOfSecond;

                // Act
                Action act = () => zonedDateTime.Should().HaveNanosecondsWithinSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have {nanosecondOfSecond} nanoseconds within the second, but found {zonedDateTime.NanosecondOfSecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                int nanosecondOfSecond = new Random().Next(1, 999_999_999);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveNanosecondsWithinSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have {nanosecondOfSecond} nanoseconds within the second, but found <null>.");
            }
        }

        public class NotHaveNanosecondsWithinSecond
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotHaveNanosecondsWithinSecond(zonedDateTime.NanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have {zonedDateTime.NanosecondOfSecond} nanoseconds within the second.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_nanoseconds_within_the_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int nanosecondOfSecond = zonedDateTime.PlusNanoseconds(1).NanosecondOfSecond;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveNanosecondsWithinSecond(nanosecondOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_nanoseconds_within_the_day_it_fails()
            {
                // Arrange
                int nanosecondOfSecond = new Random().Next(1, 999_999_999);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveNanosecondsWithinSecond(nanosecondOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have {nanosecondOfSecond} nanoseconds within the second, but found <null>.");
            }
        }

        public class HaveSecond
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_second_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().HaveSecond(zonedDateTime.Second);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_second_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int second = zonedDateTime.PlusSeconds(1).Second;

                // Act
                Action act = () => zonedDateTime.Should().HaveSecond(second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have second {second}, but found {zonedDateTime.Second}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_second_it_fails()
            {
                // Arrange
                int second = new Random().Next(1, 59);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveSecond(second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have second {second}, but found <null>.");
            }
        }

        public class NotHaveSecond
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_second_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotHaveSecond(zonedDateTime.Second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have second {zonedDateTime.Second}.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_second_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int second = zonedDateTime.PlusSeconds(1).Second;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveSecond(second);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_second_it_fails()
            {
                // Arrange
                int second = new Random().Next(1, 59);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveSecond(second);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have second {second}, but found <null>.");
            }
        }

        public class HaveYear
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_year_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().HaveYear(zonedDateTime.Year);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_year_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem());
                int year = now.AddYears(1).Year;

                // Act
                Action act = () => zonedDateTime.Should().HaveYear(year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have year {year}, but found {zonedDateTime.Year}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_year_it_fails()
            {
                // Arrange
                int year = new Random().Next(2001, 2020);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveYear(year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have year {year}, but found <null>.");
            }
        }

        public class NotHaveYear
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_year_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotHaveYear(zonedDateTime.Year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have year {zonedDateTime.Year}.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_year_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem());
                int year = now.AddYears(1).Year;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveYear(year);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_year_it_fails()
            {
                // Arrange
                int year = new Random().Next(2001, 2020);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveYear(year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have year {year}, but found <null>.");
            }
        }

        public class HaveTicksWithinDay
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_ticks_within_the_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().HaveTicksWithinDay(zonedDateTime.TickOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_ticks_within_the_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                long tickOfDay = zonedDateTime.PlusTicks(1).TickOfDay;

                // Act
                Action act = () => zonedDateTime.Should().HaveTicksWithinDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have {tickOfDay.AsFormatted()} ticks within the day, but found {zonedDateTime.TickOfDay.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_ticks_within_the_day_it_fails()
            {
                // Arrange
                long tickOfDay = new Random().Next(1, 999_999_999);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveTicksWithinDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have {tickOfDay.AsFormatted()} ticks within the day, but found <null>.");
            }
        }

        public class NotHaveTicksWithinDay
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_ticks_within_the_day_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotHaveTicksWithinDay(zonedDateTime.TickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have {zonedDateTime.TickOfDay.AsFormatted()} ticks within the day.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_ticks_within_the_day_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                long tickOfDay = zonedDateTime.PlusTicks(1).TickOfDay;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveTicksWithinDay(tickOfDay);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_ticks_within_the_day_it_fails()
            {
                // Arrange
                long tickOfDay = new Random().Next(1, 999_999_999);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveTicksWithinDay(tickOfDay);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have {tickOfDay.AsFormatted()} ticks within the day, but found <null>.");
            }
        }

        public class HaveTicksWithinSecond
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_tick_of_second_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().HaveTicksWithinSecond(zonedDateTime.TickOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int tickOfSecond = zonedDateTime.PlusTicks(1).TickOfSecond;

                // Act
                Action act = () => zonedDateTime.Should().HaveTicksWithinSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have {tickOfSecond} ticks within the second, but found {zonedDateTime.TickOfSecond}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                int tickOfSecond = new Random().Next(1, 9_999_999);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveTicksWithinSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have {tickOfSecond} ticks within the second, but found <null>.");
            }
        }

        public class NotHaveTicksWithinSecond
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotHaveTicksWithinSecond(zonedDateTime.TickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have {zonedDateTime.TickOfSecond} ticks within the second.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_tick_of_second_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int tickOfSecond = zonedDateTime.PlusTicks(1).TickOfSecond;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveTicksWithinSecond(tickOfSecond);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_tick_of_second_it_fails()
            {
                // Arrange
                int tickOfSecond = new Random().Next(1, 9_999_999);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveTicksWithinSecond(tickOfSecond);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have {tickOfSecond} ticks within the second, but found <null>.");
            }
        }

        public class HaveYearWithinEra
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_as_the_year_within_the_era_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().HaveYearWithinEra(zonedDateTime.YearOfEra);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_as_the_year_within_the_era_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int yearOfEra = zonedDateTime.YearOfEra + 1;

                // Act
                Action act = () => zonedDateTime.Should().HaveYearWithinEra(yearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have {yearOfEra} as the year within the era, but found {zonedDateTime.YearOfEra}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_has_the_specified_as_the_year_within_the_era_it_fails()
            {
                // Arrange
                int yearOfEra = new Random().Next(1, 100);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().HaveYearWithinEra(yearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(zonedDateTime)} to have {yearOfEra} as the year within the era, but found <null>.");
            }
        }

        public class NotHaveYearWithinEra
        {
            [Fact]
            public void When_a_zoned_date_time_has_the_specified_as_the_year_within_the_era_it_fails()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());

                // Act
                Action act = () => zonedDateTime.Should().NotHaveYearWithinEra(zonedDateTime.YearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have {zonedDateTime.YearOfEra} as the year within the era.");
            }

            [Fact]
            public void When_a_zoned_date_time_does_not_have_the_specified_as_the_year_within_the_era_it_succeeds()
            {
                // Arrange
                ZonedDateTime zonedDateTime = ZonedDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(RandomCalendarSystem());
                int yearOfEra = zonedDateTime.YearOfEra + 1;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveYearWithinEra(yearOfEra);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_zoned_date_time_does_not_have_the_specified_as_the_year_within_the_era_it_fails()
            {
                // Arrange
                int yearOfEra = new Random().Next(1, 100);
                ZonedDateTime? zonedDateTime = null;

                // Act
                Action act = () => zonedDateTime.Should().NotHaveYearWithinEra(yearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(zonedDateTime)} to have {yearOfEra} as the year within the era, but found <null>.");
            }
        }
    }
}
