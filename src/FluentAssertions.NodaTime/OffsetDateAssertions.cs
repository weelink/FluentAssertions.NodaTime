using System;
using System.Diagnostics.CodeAnalysis;

using FluentAssertions.Execution;
using FluentAssertions.Primitives;

using NodaTime;
using NodaTime.Calendars;

namespace FluentAssertions.NodaTime
{
    /// <summary>
    ///     Contains assertions for <see cref="OffsetDate" />.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    public sealed class OffsetDateAssertions : ReferenceTypeAssertions<OffsetDate?, OffsetDateAssertions>
    {
        /// <summary>
        ///     Initializes a new <see cref="OffsetDateAssertions" />.
        /// </summary>
        /// <param name="subject">The <see cref="OffsetDate" /> that is being asserted.</param>
        public OffsetDateAssertions(OffsetDate? subject)
            : base(subject)
        {
        }

        /// <inheritdoc />
        [ExcludeFromCodeCoverage]
        protected override string Identifier => "OffsetDate";

        /// <summary>
        ///     Asserts that this <see cref="OffsetDate" /> is equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="OffsetDate" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> Be(OffsetDate? other, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(Subject.HasValue && Subject.Equals(other) || !Subject.HasValue && !other.HasValue)
                .FailWith("Expected {context:OffsetDate} to be equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that this <see cref="OffsetDate" /> is not equal to <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="OffsetDate" /> to compare to.</param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> NotBe(OffsetDate? other, string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(Subject.HasValue && !Subject.Equals(other) || !Subject.HasValue && other.HasValue)
                .FailWith("Did not expect {context:OffsetDate} to be equal to {0}{reason}, but found {1}.", other, Subject);

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> has the specified <see cref="CalendarSystem" />.
        /// </summary>
        /// <param name="calendar">
        ///     The <see cref="CalendarSystem" /> that the current <see cref="OffsetDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;OffsetDateAssertions, CalendarSystem&gt;</see>
        ///     which can be used to assert the <see cref="CalendarSystem" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<OffsetDateAssertions, CalendarSystem> BeInCalendar(CalendarSystem calendar,
            string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetDate} to be in calendar {0}{reason}", calendar);

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

            return new AndWhichConstraint<OffsetDateAssertions, CalendarSystem>(this, calendar);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> does not have the specified <see cref="CalendarSystem" />.
        /// </summary>
        /// <param name="calendar">
        ///     The <see cref="CalendarSystem" /> that the current <see cref="OffsetDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> NotBeInCalendar(CalendarSystem calendar, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetDate} to be in calendar {0}{reason}", calendar);

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

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> has the specified <see cref="OffsetDate" />.
        /// </summary>
        /// <param name="date">
        ///     The <see cref="OffsetDate" /> that the current <see cref="OffsetDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;OffsetDateTimeAssertions, OffsetDate&gt;</see>
        ///     which can be used to assert the <see cref="OffsetDate" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<OffsetDateAssertions, LocalDate> HaveDate(LocalDate date, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetDate} to have date {0}{reason}", date);

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

            return new AndWhichConstraint<OffsetDateAssertions, LocalDate>(this, date);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> does not have the specified <see cref="OffsetDate" />.
        /// </summary>
        /// <param name="date">
        ///     The <see cref="OffsetDate" /> that the current <see cref="OffsetDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> NotHaveDate(LocalDate date, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetDate} to have date {0}{reason}", date);

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

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> has the specified <see cref="Offset" />.
        /// </summary>
        /// <param name="offset">
        ///     The <see cref="OffsetDate" /> that the current <see cref="OffsetDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;OffsetDateTimeAssertions, OffsetDate&gt;</see>
        ///     which can be used to assert the <see cref="OffsetDate" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<OffsetDateAssertions, Offset> HaveOffset(Offset offset, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetDate} to have offset {0}{reason}", offset);

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

            return new AndWhichConstraint<OffsetDateAssertions, Offset>(this, offset);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> has the specified <see cref="TimeSpan" />.
        /// </summary>
        /// <param name="timeSpan">
        ///     The <see cref="OffsetDate" /> that the current <see cref="OffsetDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndWhichConstraint{TParentConstraint, TMatchedElement}">AndWhichConstraint&lt;OffsetDateTimeAssertions, OffsetDate&gt;</see>
        ///     which can be used to assert the <see cref="OffsetDate" />.
        /// </returns>
        [CustomAssertion]
        public AndWhichConstraint<OffsetDateAssertions, Offset> HaveOffset(TimeSpan timeSpan, string because = "",
            params object[] becauseArgs)
        {
            return HaveOffset(Offset.FromTimeSpan(timeSpan), because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> does not have the specified <see cref="Offset" />.
        /// </summary>
        /// <param name="offset">
        ///     The <see cref="OffsetDate" /> that the current <see cref="OffsetDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> NotHaveOffset(Offset offset, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetDate} to have offset {0}{reason}", offset);

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

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> does not have the specified <see cref="TimeSpan" />.
        /// </summary>
        /// <param name="timeSpan">
        ///     The <see cref="OffsetDate" /> that the current <see cref="OffsetDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateTimeAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> NotHaveOffset(TimeSpan timeSpan, string because = "",
            params object[] becauseArgs)
        {
            return NotHaveOffset(Offset.FromTimeSpan(timeSpan), because, becauseArgs);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> has the specified day of the month.
        /// </summary>
        /// <param name="day">
        ///     The day of the month that the current <see cref="OffsetDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> HaveDay(int day, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetDate} to have day {0}{reason}", day);

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

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> does not have the specified day of the month.
        /// </summary>
        /// <param name="day">
        ///     The day of the month that the current <see cref="OffsetDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> NotHaveDay(int day, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetDate} to have day {0}{reason}", day);

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

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> has the specified day of the week.
        /// </summary>
        /// <param name="dayOfWeek">
        ///     The day of the week that the current <see cref="OffsetDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> HaveDayOfWeek(IsoDayOfWeek dayOfWeek, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetDate} to have day of week {0}{reason}", dayOfWeek);

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

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> does not have the specified day of the week.
        /// </summary>
        /// <param name="dayOfWeek">
        ///     The day of the week that the current <see cref="OffsetDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> NotHaveDayOfWeek(IsoDayOfWeek dayOfWeek, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetDate} to have day of week {0}{reason}", dayOfWeek);

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

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> has the specified day of the year.
        /// </summary>
        /// <param name="dayOfYear">
        ///     The day of the year that the current <see cref="OffsetDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> HaveDayOfYear(int dayOfYear, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetDate} to have day of year {0}{reason}", dayOfYear);

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

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> does not have the specified day of the year.
        /// </summary>
        /// <param name="dayOfYear">
        ///     The day of the year that the current <see cref="OffsetDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> NotHaveDayOfYear(int dayOfYear, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetDate} to have day of year {0}{reason}", dayOfYear);

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

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> has the specified year.
        /// </summary>
        /// <param name="year">
        ///     The year that the current <see cref="OffsetDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> HaveYear(int year, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetDate} to have year {0}{reason}", year);

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

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> does not have the specified year.
        /// </summary>
        /// <param name="year">
        ///     The year that the current <see cref="OffsetDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> NotHaveYear(int year, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetDate} to have year {0}{reason}", year);

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

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> has the specified month.
        /// </summary>
        /// <param name="month">
        ///     The month that the current <see cref="OffsetDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> HaveMonth(int month, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetDate} to have month {0}{reason}", month);

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

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> does not have the specified month.
        /// </summary>
        /// <param name="month">
        ///     The month that the current <see cref="OffsetDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> NotHaveMonth(int month, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetDate} to have month {0}{reason}", month);

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

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> has the specified year of era.
        /// </summary>
        /// <param name="yearOfEra">
        ///     The year of era that the current <see cref="OffsetDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> HaveYearWithinEra(int yearOfEra, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetDate} to have {0} as the year within the era{reason}", yearOfEra);

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

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> does not have the specified year of era.
        /// </summary>
        /// <param name="yearOfEra">
        ///     The year of era that the current <see cref="OffsetDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> NotHaveYearWithinEra(int yearOfEra, string because = "",
            params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetDate} to have {0} as the year within the era{reason}", yearOfEra);

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

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> has the specified era.
        /// </summary>
        /// <param name="era">
        ///     The era that the current <see cref="OffsetDate" /> is expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> HaveEra(Era era, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Expected {context:OffsetDate} to have era {0}{reason}", era);

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

            return new AndConstraint<OffsetDateAssertions>(this);
        }

        /// <summary>
        ///     Asserts that the current <see cref="OffsetDate" /> does not have the specified era.
        /// </summary>
        /// <param name="era">
        ///     The era that the current <see cref="OffsetDate" /> is not expected to have.
        /// </param>
        /// <param name="because">
        ///     A formatted phrase as is supported by <see cref="string.Format(string,object[])" /> explaining why the assertion
        ///     is needed. If the phrase does not start with the word <i>because</i>, it is prepended automatically.
        /// </param>
        /// <param name="becauseArgs">
        ///     Zero or more objects to format using the placeholders in <paramref name="because" />.
        /// </param>
        /// <returns>
        ///     An <see cref="AndConstraint{T}">AndConstraint&lt;OffsetDateAssertions&gt;</see> which can be used to chain assertions.
        /// </returns>
        [CustomAssertion]
        public AndConstraint<OffsetDateAssertions> NotHaveEra(Era era, string because = "", params object[] becauseArgs)
        {
            AssertionScope scope =
                Execute.Assertion
                    .BecauseOf(because, becauseArgs)
                    .WithExpectation("Did not expect {context:OffsetDate} to have era {0}{reason}", era);

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

            return new AndConstraint<OffsetDateAssertions>(this);
        }
    }
}
