using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions.NodaTime.Specs.Extensions;

using NodaTime;
using NodaTime.Calendars;

using Xunit;
using Xunit.Sdk;

namespace FluentAssertions.NodaTime.Specs
{
    public static class OffsetDateAssertionsSpecs
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
            public void When_a_offset_date_is_equal_to_an_other_offset_date_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();
                OffsetDate other = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(offsetDate.Calendar).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_asserting_a_offset_date_is_equal_to_itself_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().Be(offsetDate);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                OffsetDate? offsetDate = default;
                OffsetDate? other = default;

                // Act
                Action act = () => offsetDate.Should().Be(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_equal_to_not_null_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate? offsetDate = default;
                OffsetDate other = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDate)} to be equal to {other}, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();
                OffsetDate? other = default;

                // Act
                Action act = () => offsetDate.Should().Be(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDate)} to be equal to <null>, but found {offsetDate}.");
            }
        }

        public class NotBe
        {
            [Fact]
            public void When_a_offset_date_is_equal_to_an_other_offset_date_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate other = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(other.Calendar).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to be equal to {other}, but found {offsetDate}.");
            }

            [Fact]
            public void When_asserting_a_offset_date_is_not_equal_to_itself_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().NotBe(offsetDate);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to be equal to {offsetDate}, but found {offsetDate}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_null_it_fails()
            {
                // Arrange
                OffsetDate? offsetDate = default;
                OffsetDate? other = default;

                // Act
                Action act = () => offsetDate.Should().NotBe(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to be equal to <null>, but found <null>.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_null_is_not_equal_to_not_null_it_succeeds()
            {
                // Arrange
                OffsetDate? offsetDate = default;
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate other = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_not_null_is_equal_to_null_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();
                OffsetDate? other = default;

                // Act
                Action act = () => offsetDate.Should().NotBe(other);

                // Assert
                act.Should().NotThrow();
            }
        }

        public class BeInCalendar
        {
            [Fact]
            public void When_a_offset_date_has_the_specified_calendar_it_succeeds()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().BeInCalendar(calendar);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_it_succeeds_it_returns_the_calendar()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar).ToOffsetDate();

                // Act
                CalendarSystem returned = offsetDate.Should().BeInCalendar(calendar).Which;

                // Assert
                returned.Should().Be(calendar);
            }

            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_calendar_it_fails()
            {
                // Arrange
                (CalendarSystem calendar, CalendarSystem other) = TwoRandomCalendarSystems();
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().BeInCalendar(other);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDate)} to be in calendar {other}, but found {calendar}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_has_a_calendar_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDate? offsetDate = default;

                // Act
                Action act = () => offsetDate.Should().BeInCalendar(calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDate)} to be in calendar {calendar}, but {nameof(offsetDate)} was <null>.");
            }
        }

        public class NotBeInCalendar
        {
            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_calendar_it_succeeds()
            {
                // Arrange
                (CalendarSystem calendar, CalendarSystem other) = TwoRandomCalendarSystems();
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().NotBeInCalendar(other);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_has_the_specified_calendar_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(DateTimeOffset.Now).WithCalendar(calendar).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().NotBeInCalendar(calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to be in calendar {calendar}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_has_a_calendar_it_fails()
            {
                // Arrange
                CalendarSystem calendar = RandomCalendarSystem();
                OffsetDate? offsetDate = default;

                // Act
                Action act = () => offsetDate.Should().NotBeInCalendar(calendar);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to be in calendar {calendar}, but {nameof(offsetDate)} was <null>.");
            }
        }

        public class HaveDay
        {
            [Fact]
            public void When_a_offset_date_has_the_specified_day_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().HaveDay(offsetDate.Day);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_day_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem());
                OffsetDate offsetDate = offsetDateTime.ToOffsetDate();
                int day = offsetDate.With(date => date.PlusDays(1)).Day;

                // Act
                Action act = () => offsetDate.Should().HaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDate)} to have day {day}, but found {offsetDate.Day}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_has_the_specified_day_it_fails()
            {
                // Arrange
                int day = new Random().Next(1, 28);
                OffsetDate? offsetDate = null;

                // Act
                Action act = () => offsetDate.Should().HaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDate)} to have day {day}, but {nameof(offsetDate)} was <null>.");
            }
        }

        public class NotHaveDay
        {
            [Fact]
            public void When_a_offset_date_has_the_specified_day_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().NotHaveDay(offsetDate.Day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to have day {offsetDate.Day}.");
            }

            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_day_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem());
                OffsetDate offsetDate = offsetDateTime.ToOffsetDate();
                int day = offsetDateTime.With(date => date.PlusDays(1)).Day;

                // Act
                Action act = () => offsetDate.Should().NotHaveDay(day);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_does_not_have_the_specified_day_it_fails()
            {
                // Arrange
                int day = new Random().Next(1, 28);
                OffsetDate? offsetDate = null;

                // Act
                Action act = () => offsetDate.Should().NotHaveDay(day);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to have day {day}, but {nameof(offsetDate)} was <null>.");
            }
        }

        public class HaveDayOfWeek
        {
            [Fact]
            public void When_a_offset_date_has_the_specified_day_of_week_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().HaveDayOfWeek(offsetDate.DayOfWeek);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_day_of_week_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem());
                OffsetDate offsetDate = offsetDateTime.ToOffsetDate();
                IsoDayOfWeek dayOfWeek = offsetDateTime.With(date => date.PlusDays(1)).DayOfWeek;

                // Act
                Action act = () => offsetDate.Should().HaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDate)} to have day of week {dayOfWeek.AsFormatted()}, but found {offsetDate.DayOfWeek.AsFormatted()}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_has_the_specified_day_of_week_it_fails()
            {
                // Arrange
                IsoDayOfWeek dayOfWeek = RandomDayOfWeek();
                OffsetDate? offsetDate = null;

                // Act
                Action act = () => offsetDate.Should().HaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDate)} to have day of week {dayOfWeek.AsFormatted()}, but {nameof(offsetDate)} was <null>.");
            }
        }

        public class NotHaveDayOfWeek
        {
            [Fact]
            public void When_a_offset_date_has_the_specified_day_of_week_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().NotHaveDayOfWeek(offsetDate.DayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to have day of week {offsetDate.DayOfWeek.AsFormatted()}.");
            }

            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_day_of_week_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem());
                OffsetDate offsetDate = offsetDateTime.ToOffsetDate();
                IsoDayOfWeek dayOfWeek = offsetDateTime.With(date => date.PlusDays(1)).DayOfWeek;

                // Act
                Action act = () => offsetDate.Should().NotHaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_does_not_have_the_specified_day_of_week_it_fails()
            {
                // Arrange
                IsoDayOfWeek dayOfWeek = RandomDayOfWeek();
                OffsetDate? offsetDate = null;

                // Act
                Action act = () => offsetDate.Should().NotHaveDayOfWeek(dayOfWeek);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to have day of week {dayOfWeek.AsFormatted()}, but {nameof(offsetDate)} was <null>.");
            }
        }

        public class HaveDayOfYear
        {
            [Fact]
            public void When_a_offset_date_has_the_specified_day_of_year_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().HaveDayOfYear(offsetDate.DayOfYear);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_day_of_year_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem());
                OffsetDate offsetDate = offsetDateTime.ToOffsetDate();
                int dayOfYear = offsetDateTime.With(date => date.PlusDays(1)).DayOfYear;

                // Act
                Action act = () => offsetDate.Should().HaveDayOfYear(dayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDate)} to have day of year {dayOfYear}, but found {offsetDate.DayOfYear}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_has_the_specified_day_of_year_it_fails()
            {
                // Arrange
                int dayOfYear = new Random().Next(1, 365);
                OffsetDate? offsetDate = null;

                // Act
                Action act = () => offsetDate.Should().HaveDayOfYear(dayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDate)} to have day of year {dayOfYear}, but {nameof(offsetDate)} was <null>.");
            }
        }

        public class NotHaveDayOfYear
        {
            [Fact]
            public void When_a_offset_date_has_the_specified_day_of_year_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().NotHaveDayOfYear(offsetDate.DayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to have day of year {offsetDate.DayOfYear}.");
            }

            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_day_of_year_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDateTime offsetDateTime = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem());
                OffsetDate offsetDate = offsetDateTime.ToOffsetDate();
                int dayOfYear = offsetDateTime.With(date => date.PlusDays(1)).DayOfYear;

                // Act
                Action act = () => offsetDate.Should().NotHaveDayOfYear(dayOfYear);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_does_not_have_the_specified_day_of_year_it_fails()
            {
                // Arrange
                int dayOfYear = new Random().Next(1, 365);
                OffsetDate? offsetDate = null;

                // Act
                Action act = () => offsetDate.Should().NotHaveDayOfYear(dayOfYear);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to have day of year {dayOfYear}, but {nameof(offsetDate)} was <null>.");
            }
        }

        public class HaveEra
        {
            [Fact]
            public void When_a_offset_date_has_the_specified_era_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().HaveEra(offsetDate.Era);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_era_it_fails()
            {
                // Arrange
                OffsetDate ad = new OffsetDate(new LocalDate(Era.Common, 1966, 9, 8, CalendarSystem.Iso), Offset.Zero).At(LocalTime.Midnight).ToOffsetDate();
                OffsetDate bc = new OffsetDate(new LocalDate(Era.BeforeCommon, 384, 4, 16, CalendarSystem.Iso), Offset.Zero).At(LocalTime.Midnight).ToOffsetDate();

                // Act
                Action act = () => ad.Should().HaveEra(bc.Era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(ad)} to have era {bc.Era}, but found {ad.Era}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_has_the_specified_era_it_fails()
            {
                // Arrange
                Era era = Era.Common;
                OffsetDate? offsetDate = null;

                // Act
                Action act = () => offsetDate.Should().HaveEra(era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDate)} to have era {era}, but {nameof(offsetDate)} was <null>.");
            }
        }

        public class NotHaveEra
        {
            [Fact]
            public void When_a_offset_date_has_the_specified_era_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().NotHaveEra(offsetDate.Era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to have era {offsetDate.Era}.");
            }

            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_era_it_succeeds()
            {
                // Arrange
                OffsetDate ad = new OffsetDate(new LocalDate(Era.Common, 1966, 9, 8, CalendarSystem.Iso), Offset.Zero).At(LocalTime.Midnight).ToOffsetDate();
                OffsetDate bc = new OffsetDate(new LocalDate(Era.BeforeCommon, 384, 4, 16, CalendarSystem.Iso), Offset.Zero).At(LocalTime.Midnight).ToOffsetDate();

                // Act
                Action act = () => ad.Should().NotHaveEra(bc.Era);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_does_not_have_the_specified_era_it_fails()
            {
                // Arrange
                Era era = Era.Common;
                OffsetDate? offsetDate = null;

                // Act
                Action act = () => offsetDate.Should().NotHaveEra(era);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to have era {era}, but {nameof(offsetDate)} was <null>.");
            }
        }

        public class HaveMonth
        {
            [Fact]
            public void When_a_offset_date_has_the_specified_month_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().HaveMonth(offsetDate.Month);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_month_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();
                int month = offsetDate.With(date => date.PlusMonths(1)).Month;

                // Act
                Action act = () => offsetDate.Should().HaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDate)} to have month {month}, but found {offsetDate.Month}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_has_the_specified_month_it_fails()
            {
                // Arrange
                int month = new Random().Next(1, 12);
                OffsetDate? offsetDate = null;

                // Act
                Action act = () => offsetDate.Should().HaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDate)} to have month {month}, but {nameof(offsetDate)} was <null>.");
            }
        }

        public class NotHaveMonth
        {
            [Fact]
            public void When_a_offset_date_has_the_specified_month_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().NotHaveMonth(offsetDate.Month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to have month {offsetDate.Month}.");
            }

            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_month_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();
                int month = offsetDate.With(date => date.PlusMonths(1)).Month;

                // Act
                Action act = () => offsetDate.Should().NotHaveMonth(month);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_does_not_have_the_specified_month_it_fails()
            {
                // Arrange
                int month = new Random().Next(1, 12);
                OffsetDate? offsetDate = null;

                // Act
                Action act = () => offsetDate.Should().NotHaveMonth(month);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to have month {month}, but {nameof(offsetDate)} was <null>.");
            }
        }

        public class HaveYear
        {
            [Fact]
            public void When_a_offset_date_has_the_specified_year_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().HaveYear(offsetDate.Year);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_year_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();
                int year = offsetDate.With(date => date.PlusYears(1)).Year;

                // Act
                Action act = () => offsetDate.Should().HaveYear(year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDate)} to have year {year}, but found {offsetDate.Year}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_has_the_specified_year_it_fails()
            {
                // Arrange
                int year = new Random().Next(2001, 2020);
                OffsetDate? offsetDate = null;

                // Act
                Action act = () => offsetDate.Should().HaveYear(year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDate)} to have year {year}, but {nameof(offsetDate)} was <null>.");
            }
        }

        public class NotHaveYear
        {
            [Fact]
            public void When_a_offset_date_has_the_specified_year_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().NotHaveYear(offsetDate.Year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to have year {offsetDate.Year}.");
            }

            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_year_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();
                int year = offsetDate.With(date => date.PlusYears(1)).Year;

                // Act
                Action act = () => offsetDate.Should().NotHaveYear(year);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_does_not_have_the_specified_year_it_fails()
            {
                // Arrange
                int year = new Random().Next(2001, 2020);
                OffsetDate? offsetDate = null;

                // Act
                Action act = () => offsetDate.Should().NotHaveYear(year);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to have year {year}, but {nameof(offsetDate)} was <null>.");
            }
        }

        public class HaveYearOfEra
        {
            [Fact]
            public void When_a_offset_date_has_the_specified_year_of_era_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().HaveYearOfEra(offsetDate.YearOfEra);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_year_of_era_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();
                int yearOfEra = offsetDate.With(date => date.PlusYears(1)).YearOfEra;

                // Act
                Action act = () => offsetDate.Should().HaveYearOfEra(yearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDate)} to have year of era {yearOfEra}, but found {offsetDate.YearOfEra}.");
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_has_the_specified_year_of_era_it_fails()
            {
                // Arrange
                int yearOfEra = new Random().Next(1, 100);
                OffsetDate? offsetDate = null;

                // Act
                Action act = () => offsetDate.Should().HaveYearOfEra(yearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Expected {nameof(offsetDate)} to have year of era {yearOfEra}, but {nameof(offsetDate)} was <null>.");
            }
        }

        public class NotHaveYearOfEra
        {
            [Fact]
            public void When_a_offset_date_has_the_specified_year_of_era_it_fails()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();

                // Act
                Action act = () => offsetDate.Should().NotHaveYearOfEra(offsetDate.YearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to have year of era {offsetDate.YearOfEra}.");
            }

            [Fact]
            public void When_a_offset_date_does_not_have_the_specified_year_of_era_it_succeeds()
            {
                // Arrange
                DateTimeOffset now = DateTimeOffset.Now;
                OffsetDate offsetDate = OffsetDateTime.FromDateTimeOffset(now).WithCalendar(RandomCalendarSystem()).ToOffsetDate();
                int yearOfEra = offsetDate.With(date => date.PlusYears(1)).YearOfEra;

                // Act
                Action act = () => offsetDate.Should().NotHaveYearOfEra(yearOfEra);

                // Assert
                act.Should().NotThrow();
            }

            [Fact]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull", Justification = "It is supposed to be null for the test.")]
            public void When_asserting_a_null_offset_date_does_not_have_the_specified_year_of_era_it_fails()
            {
                // Arrange
                int yearOfEra = new Random().Next(1, 100);
                OffsetDate? offsetDate = null;

                // Act
                Action act = () => offsetDate.Should().NotHaveYearOfEra(yearOfEra);

                // Assert
                act.Should().Throw<XunitException>()
                    .WithMessage($"Did not expect {nameof(offsetDate)} to have year of era {yearOfEra}, but {nameof(offsetDate)} was <null>.");
            }
        }
    }
}
