using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions.Execution;
using FluentAssertions.Primitives;

using NodaTime;
using NodaTime.Calendars;

namespace FluentAssertions.NodaTime
{
    /// <summary>
    ///     Contains assertions for <see cref="LocalDateTime" />.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public sealed class LocalDateTimeAssertions : ReferenceTypeAssertions<LocalDateTime?, LocalDateTimeAssertions>
    {
        /// <summary>
        ///     Initializes a new <see cref="LocalDateTimeAssertions" />.
        /// </summary>
        /// <param name="subject">The <see cref="LocalDateTime" /> that is being asserted.</param>
        public LocalDateTimeAssertions(LocalDateTime? subject)
            : base(subject)
        {
        }

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        protected override string Identifier => "LocalDateTime";

        /// <summary>
        ///     Asserts that this <see cref="LocalDateTime" /> is equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalDateTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> Be(LocalDateTime? other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(Subject.HasValue && Subject.Equals(other) || !Subject.HasValue && !other.HasValue)
                .FailWith("Expected {context:LocalDateTime} to be equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalDateTime" /> is equal to <paramref name="dateTime" />.
        /// </summary>
        /// <param name="dateTime">The <see cref="LocalDateTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> Be(DateTime? dateTime, string because = "", params object[] becauseArgs)
        {
            return Be(dateTime.HasValue ? LocalDateTime.FromDateTime(dateTime.Value) : null, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalDateTime" /> is equal to <paramref name="dateTime" /> in <paramref name="calendar" />.
        /// </summary>
        /// <param name="dateTime">The <see cref="LocalDateTime" /> to compare to.</param>
        /// <param name="calendar">The <see cref="CalendarSystem" /> to convert <paramref name="dateTime" /> to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> Be(DateTime? dateTime, CalendarSystem calendar, string because = "", params object[] becauseArgs)
        {
            return Be(dateTime.HasValue ? LocalDateTime.FromDateTime(dateTime.Value, calendar) : null, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalDateTime" /> is not equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalDateTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotBe(LocalDateTime? other, string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(Subject.HasValue && !Subject.Equals(other) || !Subject.HasValue && other.HasValue)
                .FailWith("Did not expect {context:LocalDateTime} to be equal to {0}{reason}.", other, Subject);

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalDateTime" /> is not equal to <paramref name="dateTime" />.
        /// </summary>
        /// <param name="dateTime">The <see cref="LocalDateTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotBe(DateTime? dateTime, string because = "", params object[] becauseArgs)
        {
            return NotBe(dateTime.HasValue ? LocalDateTime.FromDateTime(dateTime.Value) : null, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalDateTime" /> is not equal to <paramref name="dateTime" /> in <paramref name="calendar" />.
        /// </summary>
        /// <param name="dateTime">The <see cref="LocalDateTime" /> to compare to.</param>
        /// <param name="calendar">The <see cref="CalendarSystem" /> to convert <paramref name="dateTime" /> to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotBe(DateTime? dateTime, CalendarSystem calendar, string because = "", params object[] becauseArgs)
        {
            return NotBe(dateTime.HasValue ? LocalDateTime.FromDateTime(dateTime.Value, calendar) : null, because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified <see cref="CalendarSystem" />.
        /// </summary>
        /// <param name="calendar">
        ///     The <see cref="CalendarSystem" /> that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;LocalDateTimeAssertions, CalendarSystem&gt;</see>
        ///     which can be used to assert the <see cref="CalendarSystem" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<LocalDateTimeAssertions, CalendarSystem> BeInCalendar(CalendarSystem calendar,
            string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to be in calendar {0}{reason}", calendar);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Calendar.Equals(calendar))
                    .FailWith(", but found {0}.", Subject.Value.Calendar);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndWhichConstraint<LocalDateTimeAssertions, CalendarSystem>(this, calendar);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified <see cref="CalendarSystem" />.
        /// </summary>
        /// <param name="calendar">
        ///     The <see cref="CalendarSystem" /> that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotBeInCalendar(CalendarSystem calendar, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to be in calendar {0}{reason}", calendar);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Calendar.Equals(calendar))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified <see cref="LocalDate" />.
        /// </summary>
        /// <param name="date">
        ///     The <see cref="LocalDate" /> that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;LocalDateTimeAssertions, LocalDate&gt;</see>
        ///     which can be used to assert the <see cref="LocalDate" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<LocalDateTimeAssertions, LocalDate> HaveDate(LocalDate date, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have date {0}{reason}", date);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Date.Equals(date))
                    .FailWith(", but found {0}.", Subject.Value.Date);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndWhichConstraint<LocalDateTimeAssertions, LocalDate>(this, date);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified <see cref="LocalDate" />.
        /// </summary>
        /// <param name="date">
        ///     The <see cref="LocalDate" /> that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveDate(LocalDate date, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have date {0}{reason}", date);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Date.Equals(date))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified <see cref="LocalTime" />.
        /// </summary>
        /// <param name="timeOfDay">
        ///     The <see cref="LocalTime" /> that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;LocalDateTimeAssertions, LocalTime&gt;</see>
        ///     which can be used to assert the <see cref="LocalTime" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<LocalDateTimeAssertions, LocalTime> HaveTimeOfDay(LocalTime timeOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have time of day {0}{reason}", timeOfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.TimeOfDay.Equals(timeOfDay))
                    .FailWith(", but found {0}.", Subject.Value.TimeOfDay);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndWhichConstraint<LocalDateTimeAssertions, LocalTime>(this, timeOfDay);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified <see cref="LocalTime" />.
        /// </summary>
        /// <param name="timeOfDay">
        ///     The <see cref="LocalTime" /> that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveTimeOfDay(LocalTime timeOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have time of day {0}{reason}", timeOfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.TimeOfDay.Equals(timeOfDay))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified hour of the half-day.
        /// </summary>
        /// <param name="clockHourOfHalfDay">
        ///     The hour of the half-day that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> HaveClockHourOfHalfDay(int clockHourOfHalfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have clock hour of the half-day of {0}{reason}",
                        clockHourOfHalfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.ClockHourOfHalfDay.Equals(clockHourOfHalfDay))
                    .FailWith(", but found {0}.", Subject.Value.ClockHourOfHalfDay);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified hour of the half-day.
        /// </summary>
        /// <param name="clockHourOfHalfDay">
        ///     The hour of the half-day that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveClockHourOfHalfDay(int clockHourOfHalfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have clock hour of the half-day of {0}{reason}",
                        clockHourOfHalfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.ClockHourOfHalfDay.Equals(clockHourOfHalfDay))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified day of the month.
        /// </summary>
        /// <param name="day">
        ///     The day of the month that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> HaveDay(int day, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have day {0}{reason}", day);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Day.Equals(day))
                    .FailWith(", but found {0}.", Subject.Value.Day);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified day of the month.
        /// </summary>
        /// <param name="day">
        ///     The day of the month that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveDay(int day, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have day {0}{reason}", day);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Day.Equals(day))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified day of the week.
        /// </summary>
        /// <param name="dayOfWeek">
        ///     The day of the week that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> HaveDayOfWeek(IsoDayOfWeek dayOfWeek, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have day of week {0}{reason}", dayOfWeek);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.DayOfWeek.Equals(dayOfWeek))
                    .FailWith(", but found {0}.", Subject.Value.DayOfWeek);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified day of the week.
        /// </summary>
        /// <param name="dayOfWeek">
        ///     The day of the week that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveDayOfWeek(IsoDayOfWeek dayOfWeek, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have day of week {0}{reason}", dayOfWeek);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.DayOfWeek.Equals(dayOfWeek))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified day of the year.
        /// </summary>
        /// <param name="dayOfYear">
        ///     The day of the year that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> HaveDayOfYear(int dayOfYear, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have day of year {0}{reason}", dayOfYear);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.DayOfYear.Equals(dayOfYear))
                    .FailWith(", but found {0}.", Subject.Value.DayOfYear);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified day of the year.
        /// </summary>
        /// <param name="dayOfYear">
        ///     The day of the year that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveDayOfYear(int dayOfYear, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have day of year {0}{reason}", dayOfYear);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.DayOfYear.Equals(dayOfYear))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified hour of the day.
        /// </summary>
        /// <param name="hourOfDay">
        ///     The hour of the day that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> HaveHour(int hourOfDay, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have hour of day {0}{reason}", hourOfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Hour.Equals(hourOfDay))
                    .FailWith(", but found {0}.", Subject.Value.Hour);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified hour of the day.
        /// </summary>
        /// <param name="hourOfDay">
        ///     The hour of the day that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveHour(int hourOfDay, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have hour of day {0}{reason}", hourOfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Hour.Equals(hourOfDay))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified year.
        /// </summary>
        /// <param name="year">
        ///     The year that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> HaveYear(int year, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have year {0}{reason}", year);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Year.Equals(year))
                    .FailWith(", but found {0}.", Subject.Value.Year);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified year.
        /// </summary>
        /// <param name="year">
        ///     The year that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveYear(int year, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have year {0}{reason}", year);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Year.Equals(year))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified second.
        /// </summary>
        /// <param name="second">
        ///     The second that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> HaveSecond(int second, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have second {0}{reason}", second);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Second.Equals(second))
                    .FailWith(", but found {0}.", Subject.Value.Second);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified second.
        /// </summary>
        /// <param name="second">
        ///     The second that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveSecond(int second, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have second {0}{reason}", second);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Second.Equals(second))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified month.
        /// </summary>
        /// <param name="month">
        ///     The month that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> HaveMonth(int month, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have month {0}{reason}", month);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Month.Equals(month))
                    .FailWith(", but found {0}.", Subject.Value.Month);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified month.
        /// </summary>
        /// <param name="month">
        ///     The month that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveMonth(int month, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have month {0}{reason}", month);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Month.Equals(month))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified minute.
        /// </summary>
        /// <param name="minute">
        ///     The minute that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> HaveMinute(int minute, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have minute {0}{reason}", minute);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Minute.Equals(minute))
                    .FailWith(", but found {0}.", Subject.Value.Minute);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified minute.
        /// </summary>
        /// <param name="minute">
        ///     The minute that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveMinute(int minute, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have minute {0}{reason}", minute);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Minute.Equals(minute))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified millisecond.
        /// </summary>
        /// <param name="millisecond">
        ///     The millisecond that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> HaveMillisecond(int millisecond, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have millisecond {0}{reason}", millisecond);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Millisecond.Equals(millisecond))
                    .FailWith(", but found {0}.", Subject.Value.Millisecond);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified millisecond.
        /// </summary>
        /// <param name="millisecond">
        ///     The millisecond that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveMillisecond(int millisecond, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have millisecond {0}{reason}", millisecond);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Millisecond.Equals(millisecond))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified nanosecond of day.
        /// </summary>
        /// <param name="nanosecondOfDay">
        ///     The nanosecond of day that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> HaveNanosecondOfDay(long nanosecondOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have nanosecond of day {0}{reason}", nanosecondOfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.NanosecondOfDay.Equals(nanosecondOfDay))
                    .FailWith(", but found {0}.", Subject.Value.NanosecondOfDay);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified nanosecond of day.
        /// </summary>
        /// <param name="nanosecondOfDay">
        ///     The nanosecond of day that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveNanosecondOfDay(long nanosecondOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have nanosecond of day {0}{reason}",
                        nanosecondOfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.NanosecondOfDay.Equals(nanosecondOfDay))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified nanosecond of second.
        /// </summary>
        /// <param name="nanosecondOfSecond">
        ///     The nanosecond of second that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> HaveNanosecondOfSecond(int nanosecondOfSecond, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have nanosecond of second {0}{reason}", nanosecondOfSecond);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.NanosecondOfSecond.Equals(nanosecondOfSecond))
                    .FailWith(", but found {0}.", Subject.Value.NanosecondOfSecond);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified nanosecond of second.
        /// </summary>
        /// <param name="nanosecondOfSecond">
        ///     The nanosecond of second that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveNanosecondOfSecond(int nanosecondOfSecond, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have nanosecond of second {0}{reason}", nanosecondOfSecond);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.NanosecondOfSecond.Equals(nanosecondOfSecond))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified tick of second.
        /// </summary>
        /// <param name="tickOfSecond">
        ///     The tick of second that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> HaveTickOfSecond(int tickOfSecond, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have tick of second {0}{reason}", tickOfSecond);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.TickOfSecond.Equals(tickOfSecond))
                    .FailWith(", but found {0}.", Subject.Value.TickOfSecond);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified tick of second.
        /// </summary>
        /// <param name="tickOfSecond">
        ///     The tick of second that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveTickOfSecond(int tickOfSecond, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have tick of second {0}{reason}", tickOfSecond);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.TickOfSecond.Equals(tickOfSecond))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified tick of day.
        /// </summary>
        /// <param name="tickOfDay">
        ///     The tick of day that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> HaveTickOfDay(long tickOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have tick of day {0}{reason}", tickOfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.TickOfDay.Equals(tickOfDay))
                    .FailWith(", but found {0}.", Subject.Value.TickOfDay);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified tick of day.
        /// </summary>
        /// <param name="tickOfDay">
        ///     The tick of day that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveTickOfDay(long tickOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have tick of day {0}{reason}", tickOfDay);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.TickOfDay.Equals(tickOfDay))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified year of era.
        /// </summary>
        /// <param name="yearOfEra">
        ///     The year of era that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> HaveYearOfEra(int yearOfEra, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have year of era {0}{reason}", yearOfEra);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.YearOfEra.Equals(yearOfEra))
                    .FailWith(", but found {0}.", Subject.Value.YearOfEra);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified year of era.
        /// </summary>
        /// <param name="yearOfEra">
        ///     The year of era that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveYearOfEra(int yearOfEra, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have year of era {0}{reason}", yearOfEra);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.YearOfEra.Equals(yearOfEra))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> has the specified era.
        /// </summary>
        /// <param name="era">
        ///     The era that the current <see cref="LocalDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> HaveEra(Era era, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:LocalDateTime} to have era {0}{reason}", era);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Era.Equals(era))
                    .FailWith(", but found {0}.", Subject.Value.Era);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="LocalDateTime" /> does not have the specified era.
        /// </summary>
        /// <param name="era">
        ///     The era that the current <see cref="LocalDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> NotHaveEra(Era era, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:LocalDateTime} to have era {0}{reason}", era);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Era.Equals(era))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but {context:LocalDateTime} was <null>.");
            }

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalDateTime" /> is greater than <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalDateTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> BeGreaterThan(LocalDateTime other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject > other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:LocalDateTime} to be greater than {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalDateTime" /> is on or after <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalDateTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> BeGreaterThanOrEqualTo(LocalDateTime other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject >= other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:LocalDateTime} to be greater than or equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalDateTime" /> is less than <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalDateTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> BeLessThan(LocalDateTime other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject < other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:LocalDateTime} to be less than {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="LocalDateTime" /> is less than or equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="LocalDateTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;LocalDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<LocalDateTimeAssertions> BeLessThanOrEqualTo(LocalDateTime other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .ForCondition(Subject <= other)
                .BecauseOf(because, becauseArgs)
                .FailWith("Expected {context:LocalDateTime} to be less than or equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<LocalDateTimeAssertions>(this);
        }
    }
}
