using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions.Execution;
using FluentAssertions.Primitives;

using NodaTime;
using NodaTime.Calendars;

namespace FluentAssertions.NodaTime
{
    /// <summary>
    ///     Contains assertions for <see cref="ZonedDateTime" />.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public sealed class ZonedDateTimeAssertions : ReferenceTypeAssertions<ZonedDateTime?, ZonedDateTimeAssertions>
    {
        /// <summary>
        ///     Initializes a new <see cref="ZonedDateTimeAssertions" />.
        /// </summary>
        /// <param name="subject">The <see cref="ZonedDateTime" /> that is being asserted.</param>
        public ZonedDateTimeAssertions(ZonedDateTime? subject)
            : base(subject)
        {
        }

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        protected override string Identifier => "ZonedDateTime";

        /// <summary>
        ///     Asserts that this <see cref="ZonedDateTime" /> is equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="ZonedDateTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> Be(ZonedDateTime? other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(Nullable.Equals(Subject, other))
                .FailWith("Expected {context:ZonedDateTime} to be equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="ZonedDateTime" /> is not equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="ZonedDateTime" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotBe(ZonedDateTime? other, string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(!Nullable.Equals(Subject, other))
                .FailWith("Did not expect {context:ZonedDateTime} to be equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified <see cref="CalendarSystem" />.
        /// </summary>
        /// <param name="calendar">
        ///     The <see cref="CalendarSystem" /> that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;ZonedDateTimeAssertions, CalendarSystem&gt;</see>
        ///     which can be used to assert the <see cref="CalendarSystem" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<ZonedDateTimeAssertions, CalendarSystem> BeInCalendar(CalendarSystem calendar,
            string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to be in calendar {0}{reason}", calendar);

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
                    .FailWith(", but found <null>.");
            }

            return new AndWhichConstraint<ZonedDateTimeAssertions, CalendarSystem>(this, calendar);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified <see cref="CalendarSystem" />.
        /// </summary>
        /// <param name="calendar">
        ///     The <see cref="CalendarSystem" /> that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotBeInCalendar(CalendarSystem calendar, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to be in calendar {0}{reason}", calendar);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified <see cref="LocalDate" />.
        /// </summary>
        /// <param name="date">
        ///     The <see cref="LocalDate" /> that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;ZonedDateTimeAssertions, LocalDate&gt;</see>
        ///     which can be used to assert the <see cref="LocalDate" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<ZonedDateTimeAssertions, LocalDate> HaveDate(LocalDate date, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have date {0}{reason}", date);

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
                    .FailWith(", but found <null>.");
            }

            return new AndWhichConstraint<ZonedDateTimeAssertions, LocalDate>(this, date);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified <see cref="LocalDate" />.
        /// </summary>
        /// <param name="date">
        ///     The <see cref="LocalDate" /> that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveDate(LocalDate date, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have date {0}{reason}", date);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified <see cref="LocalTime" />.
        /// </summary>
        /// <param name="timeOfDay">
        ///     The <see cref="LocalTime" /> that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;ZonedDateTimeAssertions, LocalTime&gt;</see>
        ///     which can be used to assert the <see cref="LocalTime" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<ZonedDateTimeAssertions, LocalTime> HaveTimeOfDay(LocalTime timeOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have time of day {0}{reason}", timeOfDay);

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
                    .FailWith(", but found <null>.");
            }

            return new AndWhichConstraint<ZonedDateTimeAssertions, LocalTime>(this, timeOfDay);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified <see cref="LocalTime" />.
        /// </summary>
        /// <param name="timeOfDay">
        ///     The <see cref="LocalTime" /> that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveTimeOfDay(LocalTime timeOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have time of day {0}{reason}", timeOfDay);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified <see cref="LocalDateTime" />.
        /// </summary>
        /// <param name="localDateTime">
        ///     The <see cref="LocalDateTime" /> that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;ZonedDateTimeAssertions, LocalDateTime&gt;</see>
        ///     which can be used to assert the <see cref="LocalDateTime" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<ZonedDateTimeAssertions, LocalDateTime> HaveLocalDateTime(LocalDateTime localDateTime, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have local date time {0}{reason}", localDateTime);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.LocalDateTime.Equals(localDateTime))
                    .FailWith(", but found {0}.", Subject.Value.LocalDateTime);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndWhichConstraint<ZonedDateTimeAssertions, LocalDateTime>(this, localDateTime);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified <see cref="LocalDateTime" />.
        /// </summary>
        /// <param name="date">
        ///     The <see cref="LocalDateTime" /> that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveLocalDateTime(LocalDateTime date, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have local date time {0}{reason}", date);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.LocalDateTime.Equals(date))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }


        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified <see cref="Offset" />.
        /// </summary>
        /// <param name="offset">
        ///     The <see cref="Offset" /> that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;ZonedDateTimeAssertions, ZonedDateTime&gt;</see>
        ///     which can be used to assert the <see cref="ZonedDateTime" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<ZonedDateTimeAssertions, Offset> HaveOffset(Offset offset, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have offset {0}{reason}", offset);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(Subject.Value.Offset.Equals(offset))
                    .FailWith(", but found {0}.", Subject.Value.Offset);
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndWhichConstraint<ZonedDateTimeAssertions, Offset>(this, offset);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified <see cref="TimeSpan" />.
        /// </summary>
        /// <param name="timeSpan">
        ///     The <see cref="Offset" /> that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;ZonedDateTimeAssertions, ZonedDateTime&gt;</see>
        ///     which can be used to assert the <see cref="ZonedDateTime" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<ZonedDateTimeAssertions, Offset> HaveOffset(TimeSpan timeSpan, string because = "",
            params object[] becauseArgs)
        {
            return HaveOffset(Offset.FromTimeSpan(timeSpan), because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified <see cref="Offset" />.
        /// </summary>
        /// <param name="offset">
        ///     The <see cref="Offset" /> that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveOffset(Offset offset, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have offset {0}{reason}", offset);

            if (Subject.HasValue)
            {
                scope
                    .ForCondition(!Subject.Value.Offset.Equals(offset))
                    .FailWith(".");
            }
            else
            {
                scope
                    .ForCondition(false)
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified <see cref="TimeSpan" />.
        /// </summary>
        /// <param name="timeSpan">
        ///     The <see cref="Offset" /> that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveOffset(TimeSpan timeSpan, string because = "",
            params object[] becauseArgs)
        {
            return NotHaveOffset(Offset.FromTimeSpan(timeSpan), because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified hour of the half-day.
        /// </summary>
        /// <param name="clockHourOfHalfDay">
        ///     The hour of the half-day that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> HaveClockHourOfHalfDay(int clockHourOfHalfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have clock hour of the half-day of {0}{reason}",
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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified hour of the half-day.
        /// </summary>
        /// <param name="clockHourOfHalfDay">
        ///     The hour of the half-day that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveClockHourOfHalfDay(int clockHourOfHalfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have clock hour of the half-day of {0}{reason}",
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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified day of the month.
        /// </summary>
        /// <param name="day">
        ///     The day of the month that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> HaveDay(int day, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have day {0}{reason}", day);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified day of the month.
        /// </summary>
        /// <param name="day">
        ///     The day of the month that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveDay(int day, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have day {0}{reason}", day);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified day of the week.
        /// </summary>
        /// <param name="dayOfWeek">
        ///     The day of the week that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> HaveDayOfWeek(IsoDayOfWeek dayOfWeek, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have day of week {0}{reason}", dayOfWeek);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified day of the week.
        /// </summary>
        /// <param name="dayOfWeek">
        ///     The day of the week that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveDayOfWeek(IsoDayOfWeek dayOfWeek, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have day of week {0}{reason}", dayOfWeek);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified day of the year.
        /// </summary>
        /// <param name="dayOfYear">
        ///     The day of the year that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> HaveDayOfYear(int dayOfYear, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have day of year {0}{reason}", dayOfYear);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified day of the year.
        /// </summary>
        /// <param name="dayOfYear">
        ///     The day of the year that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveDayOfYear(int dayOfYear, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have day of year {0}{reason}", dayOfYear);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified hour of the day.
        /// </summary>
        /// <param name="hourOfDay">
        ///     The hour of the day that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> HaveHour(int hourOfDay, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have hour of day {0}{reason}", hourOfDay);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified hour of the day.
        /// </summary>
        /// <param name="hourOfDay">
        ///     The hour of the day that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveHour(int hourOfDay, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have hour of day {0}{reason}", hourOfDay);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified year.
        /// </summary>
        /// <param name="year">
        ///     The year that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> HaveYear(int year, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have year {0}{reason}", year);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified year.
        /// </summary>
        /// <param name="year">
        ///     The year that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveYear(int year, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have year {0}{reason}", year);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified second.
        /// </summary>
        /// <param name="second">
        ///     The second that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> HaveSecond(int second, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have second {0}{reason}", second);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified second.
        /// </summary>
        /// <param name="second">
        ///     The second that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveSecond(int second, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have second {0}{reason}", second);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified month.
        /// </summary>
        /// <param name="month">
        ///     The month that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> HaveMonth(int month, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have month {0}{reason}", month);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified month.
        /// </summary>
        /// <param name="month">
        ///     The month that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveMonth(int month, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have month {0}{reason}", month);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified minute.
        /// </summary>
        /// <param name="minute">
        ///     The minute that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> HaveMinute(int minute, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have minute {0}{reason}", minute);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified minute.
        /// </summary>
        /// <param name="minute">
        ///     The minute that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveMinute(int minute, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have minute {0}{reason}", minute);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified millisecond.
        /// </summary>
        /// <param name="millisecond">
        ///     The millisecond that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> HaveMillisecond(int millisecond, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have millisecond {0}{reason}", millisecond);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified millisecond.
        /// </summary>
        /// <param name="millisecond">
        ///     The millisecond that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveMillisecond(int millisecond, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have millisecond {0}{reason}", millisecond);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified nanoseconds within the day.
        /// </summary>
        /// <param name="nanosecondOfDay">
        ///     The nanoseconds within the day that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> HaveNanosecondsWithinDay(long nanosecondOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have {0} nanoseconds within the day{reason}", nanosecondOfDay);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified nanoseconds within the day.
        /// </summary>
        /// <param name="nanosecondOfDay">
        ///     The nanoseconds within the day that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveNanosecondsWithinDay(long nanosecondOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have {0} nanoseconds within the day{reason}",
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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified nanoseconds within the second.
        /// </summary>
        /// <param name="nanosecondOfSecond">
        ///     The nanoseconds within the second that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> HaveNanosecondsWithinSecond(int nanosecondOfSecond, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have {0} nanoseconds within the second{reason}", nanosecondOfSecond);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified nanoseconds within the second.
        /// </summary>
        /// <param name="nanosecondOfSecond">
        ///     The nanoseconds within the second that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveNanosecondsWithinSecond(int nanosecondOfSecond, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have {0} nanoseconds within the second{reason}", nanosecondOfSecond);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified tick of second.
        /// </summary>
        /// <param name="tickOfSecond">
        ///     The tick of second that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> HaveTicksWithinSecond(int tickOfSecond, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have {0} ticks within the second{reason}", tickOfSecond);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified tick of second.
        /// </summary>
        /// <param name="tickOfSecond">
        ///     The tick of second that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveTicksWithinSecond(int tickOfSecond, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have {0} ticks within the second{reason}", tickOfSecond);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified tick of day.
        /// </summary>
        /// <param name="tickOfDay">
        ///     The tick of day that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> HaveTicksWithinDay(long tickOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have {0} ticks within the day{reason}", tickOfDay);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified tick of day.
        /// </summary>
        /// <param name="tickOfDay">
        ///     The tick of day that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveTicksWithinDay(long tickOfDay, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have {0} ticks within the day{reason}", tickOfDay);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified year of era.
        /// </summary>
        /// <param name="yearOfEra">
        ///     The year of era that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> HaveYearWithinEra(int yearOfEra, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have {0} as the year within the era{reason}", yearOfEra);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified year of era.
        /// </summary>
        /// <param name="yearOfEra">
        ///     The year of era that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveYearWithinEra(int yearOfEra, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have {0} as the year within the era{reason}", yearOfEra);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> has the specified era.
        /// </summary>
        /// <param name="era">
        ///     The era that the current <see cref="ZonedDateTime" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> HaveEra(Era era, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:ZonedDateTime} to have era {0}{reason}", era);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="ZonedDateTime" /> does not have the specified era.
        /// </summary>
        /// <param name="era">
        ///     The era that the current <see cref="ZonedDateTime" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;ZonedDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<ZonedDateTimeAssertions> NotHaveEra(Era era, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:ZonedDateTime} to have era {0}{reason}", era);

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
                    .FailWith(", but found <null>.");
            }

            return new AndConstraint<ZonedDateTimeAssertions>(this);
        }
    }
}
